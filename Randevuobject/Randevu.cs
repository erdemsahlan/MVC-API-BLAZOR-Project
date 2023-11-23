using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randevuobject
{
    public class Randevu
    {
        public int Id { get; set; }
        public int CalisanId { get; set; }
        public Calisan CalisanKisi { get; set; }
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }
        public bool IsAktif { get; set; }
        public bool IsTamamlandi { get; set; }
        public DateTime TarihSaat { get; set; }
        public List<Islem> Islemler { get; set; }
        public string  Aciklama { get; set; }


    }
}
