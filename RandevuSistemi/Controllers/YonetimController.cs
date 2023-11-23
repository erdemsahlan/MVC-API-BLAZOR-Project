using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using RandevuSistemi.Data;
using Microsoft.EntityFrameworkCore;

namespace RandevuSistemi.Controllers
{
    [Authorize(Roles = "SistemAdmin")]
    public class YonetimController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext db;
        public YonetimController(RoleManager<IdentityRole> rm, ApplicationDbContext database)
        {
            roleManager = rm;
            db = database;
        }

        public IActionResult Index()
        {
            var roller = roleManager.Roles.ToList();

            return View(roller);
        }

        public async Task<IActionResult> RolSil(string RolAdi)
        {

            var silinecek = roleManager.Roles.Where(x => x.Name == RolAdi).FirstOrDefault();
            if (silinecek != null)
            {
                await roleManager.DeleteAsync(silinecek);
            }


            return RedirectToAction("Index");
        }


        [HttpGet]
        public  IActionResult RolDuzenle(string RolAdi)
        {
            var duzenlenecek = roleManager.Roles.Where(x => x.Name == RolAdi).FirstOrDefault();
            if (duzenlenecek != null)
            {
                duzenlenecek.Name= RolAdi;
               
            }
            return View("YeniRol",duzenlenecek);
        }

        [HttpPost]
        public async Task<IActionResult> YeniRol(IdentityRole kaydedilecek)
        {
            IdentityRole yeniRol = new IdentityRole();
            yeniRol.Name = kaydedilecek.Name;

            if (roleManager.Roles.Any(x=>x.Id==kaydedilecek.Id))
            {
                var duzenlenecek= roleManager.Roles.Where(x => x.Id == kaydedilecek.Id).FirstOrDefault();
                duzenlenecek.Name = kaydedilecek.Name;
                await roleManager.UpdateAsync(duzenlenecek);
            }
            else
            {
                await roleManager.CreateAsync(yeniRol);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult YeniRol()
        {
            return View();
        }

        
        public IActionResult HarfGecenRolleriSil(string harf)
        {
            db.Roles.Where(x => x.Name.Contains(harf)).ExecuteDelete();

           

            return RedirectToAction("Index");
        }
    }
}
