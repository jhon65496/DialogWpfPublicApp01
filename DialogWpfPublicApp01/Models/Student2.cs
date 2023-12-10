using DialogWpfPublicApp01.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DialogWpfPublicApp01.Models
{
    // [Table("Student")]
    public class Student2
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }        
    }
}
