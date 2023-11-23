using Microsoft.EntityFrameworkCore;
using Randevuobject;
using RandevuWebApi.Data;


namespace RandevuSistemi.Services
{
    public interface IKuaforServisi
    {
        public List<Kuafor> TumKuaforler();
        public Task<Kuafor> IdDenKuafor(int id);
        public void KuaforSil(int id);
        public Kuafor KuaforDuzenle(Kuafor duzenlenen);
        public Kuafor KuaforKaydet(Kuafor eklenen);

    }


    public class KuaforServisi : IKuaforServisi
    {
        private readonly ApplicationDbContext db;
        public KuaforServisi(ApplicationDbContext data)
        {
            db = data;
        }

        public async Task<Kuafor> IdDenKuafor(int id)
        {
            var gonderilen = await db.Kuaforler.Where(x => x.Id == id).FirstOrDefaultAsync();
            return gonderilen;
        }

        
        public Kuafor KuaforDuzenle(Kuafor duzenlenen)
        {
            var mevcutKuafor = db.Kuaforler.Where(x => x.Id == duzenlenen.Id).FirstOrDefault();
            if (mevcutKuafor != null)
            {
                mevcutKuafor.Tel = duzenlenen.Tel;
                mevcutKuafor.Aciklama = duzenlenen.Aciklama;
                mevcutKuafor.Adi = duzenlenen.Adi;
                mevcutKuafor.Adres = duzenlenen.Adres;
                db.SaveChanges();
            }
            return mevcutKuafor;
        }

        public Kuafor KuaforKaydet(Kuafor eklenen)
        {
            if(!db.Kuaforler.Any(x=>x.Id==eklenen.Id))
            {
                db.Kuaforler.Add(eklenen);
                db.SaveChanges();
            }
            return eklenen;
        }

        public void KuaforSil(int id)
        {
            //db.Kuaforler.FromSql($"DELETE kuaforler WHERE Id={id}");
            var kuafor= db.Kuaforler.Where(x=>x.Id == id).FirstOrDefault();
            if (kuafor != null)
            {
                db.Kuaforler.Remove(kuafor);
            }
            db.SaveChanges();
        }

        public List<Kuafor> TumKuaforler()
        {
            return db.Kuaforler.ToList();
        }
    }
}
