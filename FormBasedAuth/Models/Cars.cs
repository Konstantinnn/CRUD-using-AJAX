using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormBasedAuth.Models
{
    public class Cars
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public int Capability { get; set; }
    }
}