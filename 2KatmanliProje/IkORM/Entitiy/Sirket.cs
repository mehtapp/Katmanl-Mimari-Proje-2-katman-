using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkORM.Entitiy
{
    public class Sirket
    {
        public int sirketId { get; set; }
        public string SirketAd { get; set; }
        public string SirketAdres { get; set; }
        public string Stel { get; set; }
        public string Smail { get; set; }
        public int BolumId { get; set; }
        public int PozisyonId { get; set; }
    }
}
