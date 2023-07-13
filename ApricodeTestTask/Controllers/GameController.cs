using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServer.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        public GameController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            try
            {
                var games = _repository.Game.GetAllGames();
                return Ok(games);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
