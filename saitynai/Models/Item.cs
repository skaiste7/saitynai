using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace saitynai.Models
{
    public class Item
    {
        [Key]
        public int Itid { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Size { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string ItemType { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Composition { get; set; }
        [Required]
        public double Price { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Description { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public double Rating { get; set; }
    }
}
