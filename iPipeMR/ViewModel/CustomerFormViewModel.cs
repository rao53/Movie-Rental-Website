using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iPipeMR.Models;

namespace iPipeMR.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customers { get; set; }
    }
}