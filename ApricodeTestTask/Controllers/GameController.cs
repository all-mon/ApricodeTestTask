using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public GameController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            try
            {
                var games = _repository.Game.GetAllGames();
                var gamesResult = _mapper.Map<IEnumerable<GameDto>>(games);
                return Ok(gamesResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}", Name = "GameById")]
        public IActionResult GetGamesById(int id)
        {
            try
            {
                var game = _repository.Game.GetById(id);
                if (game == null)
                {
                    return NotFound();
                }
                else
                {
                    var gameResult = _mapper.Map<GameDto>(game);
                    return Ok(gameResult);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateGame([FromBody] GameForCreationDto game)
        {
            try
            {
                if (game is null)
                {
                    return BadRequest("Game is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var gameEntity = _mapper.Map<Game>(game);
                _repository.Game.AddGenres(gameEntity, game.GenresIds);
                _repository.Game.CreateGame(gameEntity);
                _repository.Save();

                var createdGame = _mapper.Map<GameDto>(gameEntity);

                return CreatedAtRoute("GameById", new { id = createdGame.Id }, createdGame);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, [FromBody] GameForUpdateDto game)
        {
            try
            {
                if (game is null)
                {
                    return BadRequest("Game is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }
                var gameEntity = _repository.Game.GetById(id);
                if (gameEntity is null)
                {
                    return NotFound();
                }
                gameEntity.Name = game.Name;
                gameEntity.Studio = game.Studio;

                _repository.Game.UpdateGenres(gameEntity, game.GenresIds);
                _repository.Game.Update(gameEntity);

                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            try
            {
                var game = _repository.Game.GetById(id);
                if (game is null)
                {
                    return NotFound();
                }
                _repository.Game.DeleteGame(game);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("genre/{genreId}")]
        public IActionResult GetGamesByGenre(int genreId)
        {
            try
            {
                var games = _repository.Game.GetGamesByGenre(genreId);
                var gamesResult = _mapper.Map<IEnumerable<GameDto>>(games);
                return Ok(gamesResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}