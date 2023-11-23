using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randevuobject
{
    public class Kuafor
    {
        public int Id { get; set; }

        [Required]
        public string Adi { get; set; }
        [Required]
        public string Adres { get; set; }
        public string? Tel { get; set; }

        public string? Aciklama { get; set; }

        public List<Calisan> Calisanlar { get; set; } = new List<Calisan>();







    }
}
