using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
   private static readonly List<Animal> _animals = new()
   {
      new Animal(1, "Jake", "Dog", "Brown", 20.5f),
      new Animal(2, "Misty", "Cat", "White", 10.2f),
      new Animal(3, "Bella", "Dog", "Black", 15.3f),
      new Animal(4, "Max", "Dog", "Brown", 25.0f),
   };

   private static readonly List<Visit> _visits = new()
   {
      new Visit(1, DateTime.Now, 100.0f, "Annual checkup"),
      new Visit(2, DateTime.Now, 50.0f, "Vaccination"),
      new Visit(3, DateTime.Now, 150.0f, "Surgery"),
   };
   
   [HttpGet]
   public IActionResult GetAnimals()
   {
      return Ok(_animals);
   }
   [HttpGet("{id:int}")]
   public IActionResult GetAnimal(int id)
   {
      var animal = _animals.FirstOrDefault(a => a.Id == id);
      if (animal == null)
      {
         return NotFound();
      }
      return Ok(animal);
   }
   [HttpPut("{id:int}")]
   public IActionResult UpdateAnimal(int id, Animal animal)
   {
      var existingAnimal = _animals.FirstOrDefault(a => a.Id == id);
      if (existingAnimal == null)
      {
         return NotFound();
      }
      existingAnimal.Name = animal.Name;
      existingAnimal.Type = animal.Type;
      existingAnimal.Color = animal.Color;
      existingAnimal.Weight = animal.Weight;
      return NoContent();
   }
   [HttpDelete("{id:int}")]
   public IActionResult DeleteAnimal(int id)
   {
      var existingAnimal = _animals.FirstOrDefault(a => a.Id == id);
      if (existingAnimal == null)
      {
         return NotFound();
      }
      _animals.Remove(existingAnimal);
      return NoContent();
   }
   
   [HttpPost]
   public IActionResult CreateAnimal(Animal animal)
   {
      _animals.Add(animal);
      return StatusCode(StatusCodes.Status201Created);
   }
   
   [HttpGet("{id:int}/visits")]
   public IActionResult GetVisits(int id)
   {
      var visits = _visits.Where(v => v.AnimalId == id);
      if (!visits.Any())
      {
         return NotFound();
      }
      return Ok(visits);
   }
   [HttpPost("visits")]
   public IActionResult CreateVisit(Visit visit)
   {
      _visits.Add(visit);
      return StatusCode(StatusCodes.Status201Created);
   }
}