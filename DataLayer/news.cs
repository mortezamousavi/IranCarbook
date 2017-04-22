using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
   public class news
    {
        [Key]
        public int newsId { get; set; }
        public string Name { get; set; }
        public string News { get; set; }
        public string Image { get; set; }
        public DateTime Tarikh { get; set; }

    }
}
