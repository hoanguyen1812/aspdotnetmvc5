using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC5.Models;

namespace MVC5.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}