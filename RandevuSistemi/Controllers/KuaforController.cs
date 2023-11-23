using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Data;
using Randevuobject;
using RandevuSistemi.Services;
using Microsoft.AspNetCore.Authorization;

namespace RandevuSistemi.Controllers
{
    [Authorize(Roles = "SistemAdmin")]
    public class KuaforController : Controller
    {
        private readonly IKuaforServisi kuaforServisi;

        public KuaforController(IKuaforServisi ks)
        {
            kuaforServisi = ks;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int KuaforId)
        {
            Kuafor gonderilen;
            if (KuaforId != 0)
            {
                gonderilen = await kuaforServisi.IdDenKuafor(KuaforId);
            }
            else
            {
                gonderilen = new Kuafor();
            }

            ViewBag.KuaforListe = kuaforServisi.TumKuaforler();
            return View(gonderilen);
        }


        [HttpPost]
        public IActionResult KuaforKaydet(Kuafor kaydedilen)
        { 
            if (kaydedilen != null)
            {
                if (kaydedilen.Id==0)
                {
                    kuaforServisi.KuaforKaydet(kaydedilen);
                }
                else
                {
                    kuaforServisi.KuaforDuzenle(kaydedilen);
                }
            }
            
            return RedirectToAction("Index");
        
        }

        [HttpGet]
        public IActionResult Duzenle(int Id)
        {

            return RedirectToAction("Index", new { KuaforId = Id });

        }

        [HttpGet]
        public IActionResult Sil(int Id)
        {
            kuaforServisi.KuaforSil(Id);

            return RedirectToAction("Index", new { KuaforId = 0 });

        }

    }
}
