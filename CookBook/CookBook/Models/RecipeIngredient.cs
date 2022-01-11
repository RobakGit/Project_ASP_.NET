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
        public Ingredient IngredientId { get; set; }
        [Required]
        public Measure MeasureId { get; set; }
        [Required]
        public int Amount { get; set; }


    }
}
