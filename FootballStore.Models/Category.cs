﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FootballStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Порядковый номер")]
        public int DisplayOrder { get; set; }
        public DateTime Created { get; set; } = DateTime.Now.ToUniversalTime();

    }
}
