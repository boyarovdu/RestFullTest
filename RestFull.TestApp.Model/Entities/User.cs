using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rest.Model.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
