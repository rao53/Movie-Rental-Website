using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace iPipeMR.Dtos
{
    public class NewRentalsDto
    {
        public int customerId { get; set; }
        public List<int> movieIds { get; set; }
    }
}