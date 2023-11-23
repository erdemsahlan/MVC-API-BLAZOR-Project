using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randevuobject
{
    public class CalismaPlani
    {
        public int Id { get; set; }
        public string PlanAdi { get; set; }
        public int MusteriBasinaZaman { get; set; }
        public bool IsHahtasonuCalisma { get; set; }
        public int MesaiBaslamaSaati { get; set; }
        public int MesaiBitisSaati { get; set; }
        public string Aciklama { get; set; }

    }
}
