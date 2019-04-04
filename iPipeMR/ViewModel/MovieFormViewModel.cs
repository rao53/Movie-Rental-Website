﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iPipeMR.Models;

namespace iPipeMR.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genres> Genres { get; set; }
        public Movie Movie { get; set; }
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}