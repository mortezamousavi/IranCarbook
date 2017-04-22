using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
   public class Gallery
    {
        [Key]
        public int GalId { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
    }
}
