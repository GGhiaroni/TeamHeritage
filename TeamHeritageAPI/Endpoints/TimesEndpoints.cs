using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TeamHeritageShared.Models;

public static class TimesEndpoints
{
    public static void MapTimesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/times", async (IRepository<Time> repository) =>
        {
            var times = await repository.GetAllAsync();
            return Results.Ok(times);
        });
    }
}
