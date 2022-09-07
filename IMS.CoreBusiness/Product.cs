using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IMS.CoreBusiness
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; 
        [Required] 
        public int CategoryId { get; set; }
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(256)]
        public string Image { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage ="Giá phải lớn hơn 0")]
        public decimal Price { get; set; }
        public DateTime? Created { get; set; }
        public string CreateBy { get; set; }= string.Empty;
        public DateTime? Updated { get; set; }
        public string UpdateBy { get; set; } = string.Empty ;
        // Liên kết khoá ngoại
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

    }
}
