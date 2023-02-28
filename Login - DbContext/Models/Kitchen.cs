#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Login_DbContext.Models;

[Table("kitchen")]
public partial class Kitchen
{
    [Key]
    [Column("user_name")]
    [StringLength(50)]
    public string UserName { get; set; }

    [Required]
    [Column("pass_word")]
    [StringLength(50)]
    public string PassWord { get; set; }
}