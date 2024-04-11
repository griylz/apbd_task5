using Tutorial4.Models;

namespace Tutorial4.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        
//GET
        app.MapGet("/animals-minimalapi/{id}", (int id) =>
        {
            //process data
            if (id != 1)
            {
                Results.NotFound();
            }
            Results.Ok("animals");
        });
//200 - ok

//POST
        app.MapPost("/animals-minimalapi", (Animal animal) =>
        {
            // StaticData.Animals.Data;
            return Results.Created("", animal);
        });
    }
}