using System.ComponentModel.DataAnnotations;

namespace PetsFoodRatio.Api.Contracts;

/// <summary>
/// Request model for creating a new pet
/// </summary>
public class CreatePetRequest
{
    /// <summary>
    /// Pet's name
    /// </summary>
    [Required(ErrorMessage = "Pet name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Pet's breed
    /// </summary>
    [Required(ErrorMessage = "Breed is required")]
    [StringLength(100, ErrorMessage = "Breed cannot exceed 100 characters")]
    public string Breed { get; set; } = string.Empty;

    /// <summary>
    /// Pet's gender (Male, Female, Unknown)
    /// </summary>
    [Required(ErrorMessage = "Gender is required")]
    [RegularExpression("^(Male|Female|Unknown)$", ErrorMessage = "Gender must be Male, Female, or Unknown")]
    public string Gender { get; set; } = string.Empty;

    /// <summary>
    /// Pet's color
    /// </summary>
    [Required(ErrorMessage = "Color is required")]
    [StringLength(50, ErrorMessage = "Color cannot exceed 50 characters")]
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Pet's weight in kilograms
    /// </summary>
    [Required(ErrorMessage = "Weight is required")]
    [Range(0.1, 200.0, ErrorMessage = "Weight must be between 0.1 and 200.0 kg")]
    public decimal Weight { get; set; }

    /// <summary>
    /// Pet's birth date
    /// </summary>
    [Required(ErrorMessage = "Birth date is required")]
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Pet's microchip number (optional)
    /// </summary>
    [StringLength(20, ErrorMessage = "Chip number cannot exceed 20 characters")]
    public string? ChipNumber { get; set; }

    /// <summary>
    /// Pet's death date (optional - only set if pet has passed away)
    /// </summary>
    public DateTime? DeathDate { get; set; }
}