using ErrorOr;

using GamesLib.Models.GamesModel;

namespace GamesLib.Services.Service.GamesService;

public interface IGameService{
    ErrorOr<Created> CreateGame(GameModel game);
    ErrorOr<GameModel> GetGame(Guid id);
    ErrorOr<UpdatedGame> UpdateGame(GameModel game);
    ErrorOr<Deleted> DeleteGame(Guid id);
}