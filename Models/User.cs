using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Urfu.Models
{
    public class User
    {
        [Key]
        public Guid uuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User()
        {
            uuid = Guid.NewGuid();
        }
    }
}
