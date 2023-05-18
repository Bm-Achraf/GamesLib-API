namespace GamesLib.Contract.GamesLibRequests;

public record GetGameResponse(
    Guid Id,
    string Title,
    List<string> Generas,
    List<string> Platforms
);

public record CreateGameRequest(
    string Title,
    List<string> Generas,
    List<string> Platforms
);

public record UpdateGameRequest(
    string Title,
    List<string> Generas,
    List<string> Platforms
);