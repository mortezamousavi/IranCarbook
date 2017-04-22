using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
   public class UserRoll
    {
        [Key]
        public int RoleId { get; set; }
        public string roleName { get; set; }
    }
}
