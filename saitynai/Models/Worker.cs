using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace saitynai.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(12)")]
        public string Phone { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [ForeignKey("ItemId")]
        public int ItemId { get; set; }
    }
}
