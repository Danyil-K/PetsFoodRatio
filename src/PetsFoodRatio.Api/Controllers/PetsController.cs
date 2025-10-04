using Microsoft.AspNetCore.Mvc;
using PetsFoodRatio.Api.Contracts;

namespace PetsFoodRatio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
    /// <summary>
    /// Get all pets
    /// </summary>
    [HttpGet]
    public IActionResult GetPets()
    {
        // TODO: Implement actual service call
        var pets = new List<PetResponse>
        {
            new PetResponse
            {
                Id = 1,
                Name = "Fluffy",
                Breed = "Persian Cat",
                Gender = "Female",
                Color = "White",
                Weight = 4.5m,
                BirthDate = new DateTime(2020, 3, 15),
                ChipNumber = "CHIP123456",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };
        
        return Ok(pets);
    }

    /// <summary>
    /// Get a specific pet by ID
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetPet(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid pet ID");

        // TODO: Implement actual service call
        var pet = new PetResponse
        {
            Id = id,
            Name = "Fluffy",
            Breed = "Persian Cat",
            Gender = "Female",
            Color = "White",
            Weight = 4.5m,
            BirthDate = new DateTime(2020, 3, 15),
            ChipNumber = "CHIP123456",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return Ok(pet);
    }

    /// <summary>
    /// Create a new pet
    /// </summary>
    [HttpPost]
    public IActionResult CreatePet([FromBody] CreatePetRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // TODO: Implement actual service call
        var pet = new PetResponse
        {
            Id = 123, // This would come from the database
            Name = request.Name,
            Breed = request.Breed,
            Gender = request.Gender,
            Color = request.Color,
            Weight = request.Weight,
            BirthDate = request.BirthDate,
            ChipNumber = request.ChipNumber,
            DeathDate = request.DeathDate,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
    }

    /// <summary>
    /// Mark a pet as deceased
    /// </summary>
    [HttpPatch("{id}/death")]
    public IActionResult MarkPetDeceased(int id, [FromBody] DateTime deathDate)
    {
        if (id <= 0)
            return BadRequest("Invalid pet ID");

        if (deathDate > DateTime.Now)
            return BadRequest("Death date cannot be in the future");

        // TODO: Implement actual service call
        var pet = new PetResponse
        {
            Id = id,
            Name = "Fluffy",
            Breed = "Persian Cat",
            Gender = "Female",
            Color = "White",
            Weight = 4.5m,
            BirthDate = new DateTime(2020, 3, 15),
            ChipNumber = "CHIP123456",
            DeathDate = deathDate,
            CreatedAt = DateTime.UtcNow.AddDays(-30),
            UpdatedAt = DateTime.UtcNow
        };

        return Ok(pet);
    }
}
