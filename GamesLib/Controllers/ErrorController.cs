using Microsoft.AspNetCore.Mvc;

namespace GamesLib.Controller;


public class ErrorController : ControllerBase{
    [Route("/error")]
    public IActionResult Error(){
        return Problem();
    }
}