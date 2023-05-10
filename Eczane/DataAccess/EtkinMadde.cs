using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eczane.DataAccess
{
    public class EtkinMadde
    {
        [Key]
        public int ILAC_ID { get; set; }
        public string Adi { get; set; }
        public string Gr { get; set; }
    }
}
