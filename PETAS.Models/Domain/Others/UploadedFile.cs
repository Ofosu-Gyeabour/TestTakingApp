using System.IO;

namespace PETAS.Models.Domain.Others
{
    public class UploadedFile
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        public string FilePath { get; set; }

        public string QuestionType { get; set; }
        public string ResourceType { get; set; }
        public string inputter { get; set; }
        public string authorizer { get; set; }

    }
}
