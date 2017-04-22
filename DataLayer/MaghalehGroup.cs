using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
   public class MaghalehGroup
    {
        [Key]
        public int MaghId { get; set; }
        public string Name { get; set; }
    }
}
