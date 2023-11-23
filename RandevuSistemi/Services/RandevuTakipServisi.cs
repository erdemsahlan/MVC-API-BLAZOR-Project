
using Microsoft.AspNetCore.Identity.UI.Services;
using RandevuSistemi.Models;

namespace RandevuSistemi.Services
{
    public class RandevuTakipServisi : BackgroundService
    {
        int sayac = 0;

        private readonly ILogger<RandevuTakipServisi> logger;
        private readonly IMailService mailServisi;

        public RandevuTakipServisi(ILogger<RandevuTakipServisi> log, IMailService mail)
        {
            logger = log;
            mailServisi = mail;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            while (!stoppingToken.IsCancellationRequested)
            {
                if (sayac < 10)
                {
                    logger.Log(LogLevel.Information, "Arka Plan Servisi Çalıştı");
                    sayac++;
                    await Task.Delay(1000);
                }
                else
                {
                   await StopAsync(stoppingToken);
                }

            }
        }

        //public override Task StartAsync(CancellationToken cancellationToken)
        //{
        //    logger.Log(LogLevel.Information, "Arka Plan Servisi Başladı");

        //    return base.StartAsync(cancellationToken);
        //}

        //public override Task StopAsync(CancellationToken cancellationToken)
        //{
        //    logger.Log(LogLevel.Information, "Arka Plan Servisi Bitti");

        //    MailRequest islemSonuMesaji = new();
        //    islemSonuMesaji.ToEmail = "gurkan_guney@hotmail.com";
        //    islemSonuMesaji.Subject = "İşlem Tamamlandı";
        //    islemSonuMesaji.Body = "10 kez mesaj Gönderildi";

        //    mailServisi.SendEmailAsync(islemSonuMesaji).Wait();


        //    return base.StopAsync(cancellationToken);
        //}

    }
}
