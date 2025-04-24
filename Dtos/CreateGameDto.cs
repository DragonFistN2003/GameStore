using System.ComponentModel.DataAnnotations;

namespace GameStore.api.Dtos;

public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Range(0.1, 100)] decimal Price,
    [Required] Boolean GOTY,
    DateOnly ReleaseDate
);
