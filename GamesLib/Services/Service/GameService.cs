using ErrorOr;

using GamesLib.Models.GamesModel;
using GamesLib.Services.Errors;

namespace GamesLib.Services.Service.GamesService;

public class GameService : IGameService {
    static readonly Dictionary<Guid, GameModel> Games = new();

    public ErrorOr<Created> CreateGame(GameModel game){
        Games.Add(game.Id, game);

        return Result.Created;
    }

    public ErrorOr<GameModel> GetGame(Guid id){
        if(Games.TryGetValue(id, out var game)){
            return game;
        }
        return GameErrors.Errors.NotFound;
    }

    public ErrorOr<UpdatedGame> UpdateGame(GameModel game){
        Games[game.Id] = game;

        return new UpdatedGame(Games.ContainsKey(game.Id));
    }

    public ErrorOr<Deleted> DeleteGame(Guid id){
        Games.Remove(id);

        return Result.Deleted;
    }
}