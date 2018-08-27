using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiDemo.ViewModal
{
    public class StudentViewModal
    {

        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        [Required]
        public string Email { get; set; }
    }
}