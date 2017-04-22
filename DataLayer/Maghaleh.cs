using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
   public class Maghaleh
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }
        public DateTime Tarikh { get; set; }
        public string writer { get; set; }
        public int Position { get; set; }
        public string KeyWords { get; set; }
        public int MaghId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("MaghId")]
        public MaghalehGroup MaghalehGroup { get; set; }
    }

}
