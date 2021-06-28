﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookDetailS.Entity
{
    public partial class BookDetails
    {
        [Key]
        public int Book_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public int Author { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public bool Is_Deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created_Time_Stamp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Updated_Time_Stamp { get; set; }
    }
}