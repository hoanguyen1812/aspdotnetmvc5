﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1,20)]
        public byte NumberInStock { get; set; }
    }
}