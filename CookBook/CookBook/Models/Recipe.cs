using System;
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
        public int Category { get; set; }
        //TODO ForeignKey
        [Required]
        public int RecipeIngredientId { get; set; }
        //TODO ForeignKey
        [Required]
        public int OwnerId { get; set; }
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public DateTime CookingTime { get; set; }
    }
}
