using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
   public class CarInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
        public DateTime Tarikh { get; set; }
        public string keyword { get; set; }

    }
}
