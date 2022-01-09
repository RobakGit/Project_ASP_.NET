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
        //TODO ForeignKey
        [Required]
        public int IngredientId { get; set; }
        //TODO ForeignKey
        [Required]
        public int MeasureId { get; set; }
        [Required]
        public int Amount { get; set; }

    }
}
