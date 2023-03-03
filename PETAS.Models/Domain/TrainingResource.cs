﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PETAS.Models.Domain
{
    [Table("TrainingResource")]
    public partial class TrainingResource
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Id of the training being referenced
        /// </summary>
        [Column("TrainingID")]
        public int? TrainingId { get; set; }
        /// <summary>
        /// the name of the resource material 
        /// </summary>
        [StringLength(100)]
        [Unicode(false)]
        public string ResourceName { get; set; }
        /// <summary>
        /// the foreign key depicting the type of resource it is. (could be a PDF material, audio or video)
        /// </summary>
        [Column("TrainingResourceID")]
        public int? TrainingResourceId { get; set; }
        /// <summary>
        /// flag determining if the resource is embedded in the database or not
        /// </summary>
        public int? IsEmbedded { get; set; }
        /// <summary>
        /// the path to the resource if not embedded
        /// </summary>
        [StringLength(100)]
        [Unicode(false)]
        public string ResourcePath { get; set; }
        /// <summary>
        /// holds the resource if it happens to be embedded
        /// </summary>
        [MaxLength(50)]
        public byte[] EmbeddedResource { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [Column("CreatedBy")]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AuthorizedDate { get; set; }

        [Column("AuthorizedBy")]
        public string AuthorizedBy { get; set; }

        [ForeignKey(nameof(TrainingId))]
        [InverseProperty("TrainingResources")]
        public virtual Training Training { get; set; }
        [ForeignKey(nameof(TrainingResourceId))]
        [InverseProperty(nameof(TrainingResourceType.TrainingResources))]
        public virtual TrainingResourceType TrainingResourceNavigation { get; set; }
    }
}