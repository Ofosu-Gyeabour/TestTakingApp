﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PETAS.Data.Models
{
    [Table("TrainingResourceType")]
    public partial class TrainingResourceType
    {
        public TrainingResourceType()
        {
            TrainingResources = new HashSet<TrainingResource>();
        }

        /// <summary>
        /// primary key to the trainingResource table entity
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// the type of resource (audio/mp3, video/mp4, text or document/pdf)
        /// </summary>
        [Column("TrainingResourceType")]
        [StringLength(50)]
        [Unicode(false)]
        public string TrainingResourceType1 { get; set; }
        /// <summary>
        /// the extension of the training resource to watch before taking tests
        /// </summary>
        [StringLength(10)]
        [Unicode(false)]
        public string TrainingResourceExt { get; set; }
        /// <summary>
        /// the date the resource type was created
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [Column("CreatedByID")]
        public int? CreatedById { get; set; }
        [Column(TypeName = "date")]
        public DateTime? AuthorizedDate { get; set; }
        [Column("AuthorizedByID")]
        public int? AuthorizedById { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastUpdatedDate { get; set; }
        [Column("LastUpdatedByID")]
        public int? LastUpdatedById { get; set; }

        [InverseProperty(nameof(TrainingResource.TrainingResourceNavigation))]
        public virtual ICollection<TrainingResource> TrainingResources { get; set; }
    }
}