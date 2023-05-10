using Eczane.Connection;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eczane.DataAccess
{
   public class IlacAmbalaj
    {
       
        [Key]
        public int ID { get; set; }
        public  string BARKOD { get; set; }
        public  int FAVORI { get; set; }

    }
}
