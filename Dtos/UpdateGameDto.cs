namespace GameStore.api.Dtos;

public record class UpdateGameDto(
    string Name,
    string Genre,
    decimal Price,
    Boolean GOTY,
    DateOnly ReleaseDate
);
