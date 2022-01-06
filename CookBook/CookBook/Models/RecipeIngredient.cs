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
        [Required]
        public int recipe_id { get; set; }

        [Required]
        public int ingredient_id { get; set; }
        public int measure_id { get; set; }
        public int amount { get; set; }

    }
}
}
