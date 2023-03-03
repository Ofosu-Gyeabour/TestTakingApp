﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PANTrainerAPI.Models
{
    [Table("TrainingAssessment")]
    public partial class TrainingAssessment
    {
        public TrainingAssessment()
        {
            Qalloteds = new HashSet<Qalloted>();
        }

        [Key]
        public int Id { get; set; }
        /// <summary>
        /// the Id of the training programme
        /// </summary>
        [Column("TrainingID")]
        public int? TrainingId { get; set; }
        /// <summary>
        /// the name of the assessment programme
        /// </summary>
        [StringLength(100)]
        [Unicode(false)]
        public string AssessmentName { get; set; }
        /// <summary>
        /// the marks alloted for the assessment. This mark MAY be a part, or ALL the marks for the training. If training consist of one assessment, alloted_assessment_marks = dbo.Training.mark_to_pass
        /// </summary>
        public int? AllotedAssessmentMarks { get; set; }
        /// <summary>
        /// the pass mark for the assessment
        /// </summary>
        [StringLength(10)]
        public string PassAssessmentMark { get; set; }
        /// <summary>
        /// in case the training comprises more than ONE assessment, this is the mark derived for this assessment in respect of the overall training
        /// </summary>
        [Column(TypeName = "numeric(9, 2)")]
        public decimal? AllotedProratedMark { get; set; }
        /// <summary>
        /// the date the assessment was created
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// the user creating the assessment
        /// </summary>
        [StringLength(50)]
        [Unicode(false)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "date")]
        public DateTime? AuthorizedDate { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string AuthorizedBy { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string LastUpdatedBy { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastUpdatedDate { get; set; }

        [ForeignKey(nameof(TrainingId))]
        [InverseProperty("TrainingAssessments")]
        public virtual Training Training { get; set; }
        [InverseProperty(nameof(Qalloted.TrainingAssessment))]
        public virtual ICollection<Qalloted> Qalloteds { get; set; }
    }
}