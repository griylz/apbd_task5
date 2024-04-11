using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers;
[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{
    private static List<Animal> Animals = StaticData.Animals;
    private static List<Visit> Visits = StaticData.Visits;
    
    [HttpGet("{animalId:int}/visits")]
    public IActionResult GetVisitsForAnimal(int animalId)
    {
        var visits = Visits.Where(v => v.AnimalId == animalId).ToList();
        if (!visits.Any())
        {
            return NotFound($"No visits found for animal with ID {animalId}.");
        }
        return Ok(visits);
    }
    
    [HttpPost("/Animals/{animalId}/Visits")]
    public IActionResult AddVisit(int animalId,[FromBody] Visit visit)
    {
        visit.Id = Visits.Max(v => v.Id) + 1;
        visit.AnimalId = animalId;
        Visits.Add(visit);
        return CreatedAtAction(nameof(GetVisitsForAnimal), visit);
    }
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(Animals);
    }
    
    [HttpGet("{id}")]
    public ActionResult GetAnimal(int id)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var index = Animals.FindIndex(a => a.Id == id);
        if (index < 0)
        {
            return NotFound();
        }
        Animals.RemoveAt(index);
        return Ok();
    }

    [HttpPost]
    public IActionResult PostAnimal(Animal animal)
    {
        if (Animals.Count == 0)
        {
            animal.Id = 1;
        }
        else
        {

            animal.Id = Animals.Max(a => a.Id) + 1;
        }
        Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), animal);
    }

    [HttpPut]
    public IActionResult PutAnimal(int id, Animal animal)
    {
        var index = Animals.FindIndex(a => a.Id == id);
        if (index < 0)
        {
            return NotFound();
        }

        animal.Id = id;
        Animals[index] = animal;
        return Ok();
    }
}