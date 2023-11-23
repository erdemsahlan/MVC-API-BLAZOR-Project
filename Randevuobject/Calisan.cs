using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randevuobject
{
    public class Calisan
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool IsYetkili { get; set; }
        public string Aciklama { get; set; }

        public int KuaforId { get; set; }
        public Kuafor Kuaforu { get; set; }

        public int CalismaPlaniId { get; set; }
        public CalismaPlani Plan { get; set; }

    }
}
