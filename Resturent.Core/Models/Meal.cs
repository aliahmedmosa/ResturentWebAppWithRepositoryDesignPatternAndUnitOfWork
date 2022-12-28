using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturent.Core.Models
{
    public class Meal
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Meal Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name ="Image")]
        public string Url { get; set; } = string.Empty;

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Display(Name= "Meal component")]
        public string Discription { get; set; } = string.Empty;

        [Required]
        [ForeignKey("category")]
        public int categoryId { get; set; }

        public virtual Category? category { get; set; }

    }
}
