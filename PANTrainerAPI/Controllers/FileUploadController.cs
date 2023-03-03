using Microsoft.AspNetCore.Mvc;
using PETAS.Models.Domain.Others;
using ExcelDataReader;
using ExcelDataReader.Core;
using System.Diagnostics;
using System.IO;
using PETAS.Data.Data;
using PETAS.Models.Domain;
using PANTrainerAPI.Helpers;

using System.Text.Encodings;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PANTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly PantrainerContext config;

        public FileUploadController(PantrainerContext _context)
        {
            config = _context;
        }

        [HttpPost("uploadQuestionFile")]
        public async Task<bool> UploadFileAsync(UploadedFile uploadedFile)
        {
            if (uploadedFile == null)
            {
                return false;
            }

            if (uploadedFile.FilePath == string.Empty)
            {
                return false;
            }

            var path = $"{uploadedFile.FilePath}\\{uploadedFile.FileName}";
            var fs = System.IO.File.Create(path);
            await fs.WriteAsync(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
            fs.Close();

            return true;
        }

        [HttpPost("UploadNonVideoResourceToDb")]
        public async Task<bool> UploadTrainingResource(JObject data)
        {
            try
            {
                var obj = data["uploadedFile"].ToObject<UploadedFile>();
                var ttype = data["ttype"].ToObject<TrainingResourceType>();

                if (obj == null)
                {
                    return false;
                }

                //creating record
                var o = new TrainingResource {
                    ResourceName = obj.FileName,
                    TrainingResourceId = ttype.Id,
                    IsEmbedded = 1,
                    ResourcePath = obj.FilePath,
                    EmbeddedResource = obj.FileContent,
                    CreatedDate = DateTime.Now,
                    CreatedBy = obj.inputter
                };

                await config.TrainingResources.AddAsync(o);
                await config.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        [HttpPost("uploadMCASFileToDatabase")]
        public async Task<string> UploadDbAsync(byte[] b)
        {
            int k = 0; int f = 0;

            if (b == null)
            {
                return String.Empty;
            }

            try
            {
                MemoryStream stream = new MemoryStream(b);

                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    if (reader.RowCount > 1)
                    {
                        do
                        {
                            //read the header
                            reader.Read();

                            while (reader.Read())
                            {
                                try
                                {
                                    using (var t = config.Database.BeginTransaction())
                                    {
                                        //results.Tables[0].Rows[1]["SubjectMatter"]
                                        var subjectObj = await new Utils(config) { }.getAssessmentSubject(reader.GetString(6));
                                        var objQuestionType = await new Utils(config) { }.getQuestionType(@"Multiple Choice (MCANS)");

                                        var objAssessmentQuestionPool = new AssessmentQuestionPool
                                        {
                                            Question = reader.GetString(1),
                                            QuestionType = objQuestionType.Id,
                                            SubjectId = subjectObj.Id,
                                            CreatedDate = DateTime.Now,
                                            CreatedBy = reader.GetString(7)
                                        };

                                        await config.AssessmentQuestionPools.AddAsync(objAssessmentQuestionPool);
                                        await config.SaveChangesAsync();
                                        var qId = objAssessmentQuestionPool.Id;

                                        //build objective class
                                        var obj = new ObjectiveClass
                                        {
                                            QuestionId = qId,
                                            Cobj1 = reader.GetString(2),
                                            Cobj2 = reader.GetString(3),
                                            Cobj3 = reader.GetString(4),
                                            Cobj4 = reader.GetString(5)
                                        };

                                        await config.ObjectiveClasses.AddAsync(obj);
                                        await config.SaveChangesAsync();

                                        await t.CommitAsync();
                                        k++;
                                    }
                                }
                                catch (Exception tx)
                                {
                                    f++;
                                }
                            }

                            return $"Total records: {(reader.RowCount - 1).ToString()} Successful uploads: {k.ToString()} Failed uploads: {f.ToString()}";
                        } while (reader.NextResult());
                    }
                    else { return @"No data"; }
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpPost("uploadWRTANSFileToDatabase")]
        public async Task<string> UploadWrittenQuestionsAsync(byte[] b)
        {
            //method is used to upload written questions to the data store
            int success = 0;
            int failed = 0;

            if (b.Length < 1)
            {
                return $"No data";
            }

            try
            {
                MemoryStream stream = new MemoryStream(b);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    if (reader.RowCount > 1)
                    {
                        do
                        {
                            //read the header line
                            reader.Read();

                            //start iteration
                            while (reader.Read())
                            {
                                //create a transaction for this operation
                                var txn = await config.Database.BeginTransactionAsync();

                                try
                                {
                                    using (txn)
                                    {
                                        var subjectObj = await new Utils(config) { }.getAssessmentSubject(reader.GetString(2));
                                        var objQuestionType = await new Utils(config) { }.getQuestionType(@"Written Questions (WRTANS)");

                                        var objAssessmentQuestionPool = new AssessmentQuestionPool
                                        {
                                            Question = reader.GetString(1),
                                            QuestionType = objQuestionType.Id,
                                            SubjectId = subjectObj.Id,
                                            CreatedDate = DateTime.Now,
                                            CreatedBy = reader.GetString(3)
                                        };

                                        await config.AssessmentQuestionPools.AddAsync(objAssessmentQuestionPool);
                                        await config.SaveChangesAsync();

                                        await txn.CommitAsync();
                                        success++;
                                    }
                                }
                                catch(Exception txnEx)
                                {
                                    failed++;
                                    Debug.Print($"error: {txnEx.Message}");
                                }
                            }

                            return $"Total records: {(reader.RowCount - 1).ToString()} Successful uploads: {success.ToString()} Failed uploads: {failed.ToString()}";

                        } while (reader.NextResult());
                    }
                    else { return $"No data"; }
                }
            }
            catch(Exception x)
            {
                return $"error: {x.Message}";
            }

        }


    }
}
