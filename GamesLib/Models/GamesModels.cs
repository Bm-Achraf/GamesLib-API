using ErrorOr;

using GamesLib.Contract.GamesLibRequests;
using GamesLib.Services.Errors;

namespace GamesLib.Models.GamesModel;

public class GameModel{
    public Guid Id { get; }
    public string Title { get; }
    public List<string> Generas { get; }
    public List<string> Platfroms { get; }

    GameModel(Guid id, string title, List<string> generas, List<string> platforms)
    {
        Id = id;
        Title = title;
        Generas = generas;
        Platfroms = platforms;
    }

    public static ErrorOr<GameModel> Create(CreateGameRequest request){

        List<Error> errors = new List<Error>();

        if(request.Title.Length==0 || request.Title==" " || request.Title==null){
            errors.Add(GameErrors.Errors.EmptyTitle);
        }

        if(request.Generas.Count==0){
            errors.Add(GameErrors.Errors.EmptyList);
        }

        if(request.Platforms.Count==0){
            errors.Add(GameErrors.Errors.EmptyList);
        }

        if(errors.Count > 0)return errors;


        return new GameModel(
            Guid.NewGuid(),
            request.Title!,
            request.Generas,
            request.Platforms
        );
    }

    public static ErrorOr<GameModel> Update(Guid id, UpdateGameRequest request){

        List<Error> errors = new List<Error>();

        if(request.Title.Length==0 || request.Title==" " || request.Title==null){
            errors.Add(GameErrors.Errors.NotFound);
        }

        if(request.Generas.Count==0){
            errors.Add(GameErrors.Errors.EmptyList);
        }

        if(request.Platforms.Count==0){
            errors.Add(GameErrors.Errors.EmptyList);
        }

        if(errors.Count > 0)return errors;

        return new GameModel(
            id,
            request.Title!,
            request.Generas,
            request.Platforms
        );

    }
}