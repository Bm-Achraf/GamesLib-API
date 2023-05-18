using Microsoft.AspNetCore.Mvc;
using ErrorOr;

using GamesLib.Services.Service.GamesService;
using GamesLib.Services.Errors;
using GamesLib.Contract.GamesLibRequests;
using GamesLib.Models.GamesModel;

namespace GamesLib.Controller;

public class GamesController : ApiController{

     readonly IGameService _GameService;

     public GamesController(IGameService gameService){
        _GameService = gameService;
     }

     CreatedAtActionResult CreateAsGame(GameModel game){
        
        return CreatedAtAction(
            actionName: "GetGame",
            routeValues: new { id = game.Id },
            value: game
        );
     }

     [HttpPost]
     public IActionResult CreateGame(CreateGameRequest request){
          
          ErrorOr<GameModel> gameResponse = GameModel.Create(request);
          
          ErrorOr<Created> game = _GameService.CreateGame(gameResponse.Value);
          
          if(game.IsError){
            return Problem(game.Errors);
          }

          
          return CreateAsGame(gameResponse.Value);
          
     }



     [HttpGet("{id:guid}")]
     public IActionResult GetGame(Guid id){

        ErrorOr<GameModel> gameResult = _GameService.GetGame(id);

        if(gameResult.IsError && gameResult.FirstError == GameErrors.Errors.NotFound){
            return NotFound();
        }

        return gameResult.Match(
            game => Ok(new GetGameResponse(
                game.Id,
                game.Title,
                game.Generas,
                game.Platfroms
            )),

            error => Problem(error)
        );

     } 



     [HttpPut("{id:guid}")]
     public IActionResult UpdateGame(Guid id, UpdateGameRequest request){

        ErrorOr<GameModel> response = GameModel.Update(
            id,
            request
        );

        return _GameService.UpdateGame(response.Value).Match(
            updated => updated.IsNewlyCreated ? CreateAsGame(response.Value) : NoContent(),
            errors => Problem(errors)
        );

     }



     [HttpDelete("{id:guid}")]
     public IActionResult DeleteGame(Guid id){
        _GameService.DeleteGame(id);

        return NoContent();
     }

}