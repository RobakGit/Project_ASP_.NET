using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Models
{
    public class Recipes
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public DateTime CookingTime { get; set; }
    }
}
