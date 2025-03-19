using System;

namespace GameStore.Api.Entities;

public class Developer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Country { get; set; }
    public string? Founded { get; set; }
    public string? Description { get; set; }
    public string? Website { get; set; }
    public string? LogoUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
