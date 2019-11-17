using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace saitynai.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string State { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DispatchDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReceivedDate { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string TrackingNr { get; set; }
        [ForeignKey("ItemId")]
        public int ItemId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        //[Required]
        //public Item Item { get; set; }

    }
}
