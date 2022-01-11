using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        //TODO ForeignKey
        [Required]
        public Category Category { get; set; }

        //TODO ForeignKey
        [Required]
        public List<RecipeIngredient> RecipeIngredients { get; set; }
        //TODO ForeignKey
        [Required]
        public User Owner { get; set; }
        //[DisplayFormat(DataFormatString = "{HH:mm}")]
        public TimeSpan CookingTime { get; set; }

  
    }
}
