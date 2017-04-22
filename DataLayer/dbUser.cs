using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
   public class dbUser
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set;}

        public string pass { get; set; }
        public string mail { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped()]
        [Compare("pass")]
        public string repass { get; set; }
        public int RoleId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("RoleId")]
        public UserRoll UserRoll { get; set; }
    }
}
