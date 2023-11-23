using Microsoft.AspNetCore.Mvc;
using Randevuobject;
using RandevuSistemi.Services;

namespace RandevuWebApi.Controllers
{
    [ApiController]
    public class KuaforController : ControllerBase
    {
        private readonly IKuaforServisi kuaforServisi;
        public KuaforController(IKuaforServisi serv)
        {
            kuaforServisi= serv;
        }

        [HttpGet("KuaforListesi")]
        public IActionResult KuaforListesi()
        {
            return Ok(kuaforServisi.TumKuaforler());
        }

        [HttpDelete("KuaforSil")]
        public IActionResult KuaforSil(int Id)
        {
            kuaforServisi.KuaforSil(Id);
            return Ok();
        }

        [HttpPost("KuaforDuzenle")]
        public IActionResult KuaforDuzenle(Kuafor duzenlenen)
        {
            Kuafor kaydedilen=kuaforServisi.KuaforDuzenle(duzenlenen);
            return Ok(kaydedilen);
        }

  


    }
}
