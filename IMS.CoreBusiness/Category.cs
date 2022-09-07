using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(256)]
        public string Image { get;set; }= string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        // Liên kết với bảng product
        public virtual ICollection<Product>? Products { get; set; }
    }
}
