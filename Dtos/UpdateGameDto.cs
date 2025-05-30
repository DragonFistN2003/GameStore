namespace GameStore.api.Dtos;

public record class UpdateGameDto(
    string Name,
    int GenreId,
    decimal Price,
    Boolean GOTY,
    DateOnly ReleaseDate
);
