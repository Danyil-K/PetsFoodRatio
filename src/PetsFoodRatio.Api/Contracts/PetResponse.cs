namespace PetsFoodRatio.Api.Contracts;

/// <summary>
/// Response model for pet data
/// </summary>
public class PetResponse
{
    /// <summary>
    /// Unique identifier for the pet
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Pet's name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Pet's breed
    /// </summary>
    public string Breed { get; set; } = string.Empty;

    /// <summary>
    /// Pet's gender
    /// </summary>
    public string Gender { get; set; } = string.Empty;

    /// <summary>
    /// Pet's color
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Pet's weight in kilograms
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// Pet's birth date
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Pet's microchip number
    /// </summary>
    public string? ChipNumber { get; set; }

    /// <summary>
    /// Pet's death date (null if pet is alive)
    /// </summary>
    public DateTime? DeathDate { get; set; }

    /// <summary>
    /// Pet's age in years (calculated from birth date to death date or current date)
    /// </summary>
    public int Age => CalculateAge(BirthDate, DeathDate);

    /// <summary>
    /// Whether the pet is alive
    /// </summary>
    public bool IsAlive => DeathDate == null;

    /// <summary>
    /// Pet's age in months (calculated from birth date to death date or current date)
    /// </summary>
    public int AgeMonths => CalculateAgeInMonths(BirthDate, DeathDate);

    /// <summary>
    /// When the pet was created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the pet was last updated
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Calculate age in years from birth date to death date or current date
    /// </summary>
    private static int CalculateAge(DateTime birthDate, DateTime? deathDate)
    {
        var endDate = deathDate ?? DateTime.Now;
        var age = endDate.Year - birthDate.Year;
        
        if (endDate.Month < birthDate.Month || 
            (endDate.Month == birthDate.Month && endDate.Day < birthDate.Day))
        {
            age--;
        }
        
        return age;
    }

    /// <summary>
    /// Calculate age in months from birth date to death date or current date
    /// </summary>
    private static int CalculateAgeInMonths(DateTime birthDate, DateTime? deathDate)
    {
        var endDate = deathDate ?? DateTime.Now;
        return ((endDate.Year - birthDate.Year) * 12) + endDate.Month - birthDate.Month;
    }
}
