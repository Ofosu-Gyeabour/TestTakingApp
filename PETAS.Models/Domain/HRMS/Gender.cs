﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PETAS.Models.Domain.HRMS
{
    [Table("Gender")]
    public partial class Gender
    {
        [Key]
        [Column("GenderID")]
        public int GenderId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}