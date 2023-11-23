using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using RandevuWebApi.Data;
using Randevuobject;
namespace RandevuWebApi.Controllers;

public static class RandevuEndpoints
{
    public static void MapRandevuEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Randevu").WithTags(nameof(Randevu));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Randevular.ToListAsync();
        })
        .WithName("GetAllRandevus")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Randevu>, NotFound>> (int id, ApplicationDbContext db) =>
        {
            return await db.Randevular.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Randevu model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetRandevuById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Randevu randevu, ApplicationDbContext db) =>
        {
            var affected = await db.Randevular
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, randevu.Id)
                    .SetProperty(m => m.CalisanId, randevu.CalisanId)
                    .SetProperty(m => m.MusteriId, randevu.MusteriId)
                    .SetProperty(m => m.IsAktif, randevu.IsAktif)
                    .SetProperty(m => m.IsTamamlandi, randevu.IsTamamlandi)
                    .SetProperty(m => m.TarihSaat, randevu.TarihSaat)
                    .SetProperty(m => m.Aciklama, randevu.Aciklama)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateRandevu")
        .WithOpenApi();

        group.MapPost("/", async (Randevu randevu, ApplicationDbContext db) =>
        {
            db.Randevular.Add(randevu);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Randevu/{randevu.Id}",randevu);
        })
        .WithName("CreateRandevu")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, ApplicationDbContext db) =>
        {
            var affected = await db.Randevular
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteRandevu")
        .WithOpenApi();
    }
}
