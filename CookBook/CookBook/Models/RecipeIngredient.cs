using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Models
{
    public class RecipeIngredient
    {
        [Key]
        public int Recipe_id { get; set; }
        [Required]
        public Ingredient Ingredient { get; set; }
        [Required]
        public Measure Measure { get; set; }
        [Required]
        public double Ammount { get; set; }


    }
}
