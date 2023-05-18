using Microsoft.AspNetCore.Mvc;
using ErrorOr;

using GamesLib.Models.GamesModel;
using GamesLib.Contract.GamesLibRequests;

namespace GamesLib.Controller;

[ApiController]
[Route("Game")]
public class ApiController : ControllerBase{

    public IActionResult Problem(List<Error> errors){

        Error FirstError = errors[0];

        var statusCode = FirstError.Type switch{
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode:statusCode, title: FirstError.Description);
    }

    public GetGameResponse MapGameResult(GameModel game){
        return new GetGameResponse(
            game.Id,
            game.Title,
            game.Generas,
            game.Platfroms
        );
    }

}