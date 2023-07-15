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
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public GameController(ILoggerManager logger,IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
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
                _logger.LogInfo($"Get all games from database.");
                return Ok(gamesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception inside GetAllGames action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}", Name = "GameById")]
        public IActionResult GetGamesById(int id)
        {
            try
            {
                var game = _repository.Game.GetById(id);
                if (game is null)
                {
                    _logger.LogError($"From GetAllGames action: NotFound Game with id: {id}.");
                    return NotFound();
                }
                else
                {
                    var gameResult = _mapper.Map<GameDto>(game);
                    _logger.LogInfo($"GetGamesById action returned game by id: {id}");
                    return Ok(gameResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception inside GetGamesById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult CreateGame([FromBody] GameForCreationDto game)
        {
            try
            {
                if (game is null)
                {
                    _logger.LogError("Game object sent from client is null.");
                    return BadRequest("Game is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid game object sent from client.");
                    return BadRequest("Invalid model");
                }
                var existingGenresIds = _repository.Genre.GetAll().Select(x => x.Id);
                if (!game.GenresIds.All(existingGenresIds.Contains))
                {
                    return BadRequest($"Attempt to add a non-existent genre id for a game");
                }
                var gameEntity = _mapper.Map<Game>(game);
                _repository.Game.AddGameGenres(gameEntity, game.GenresIds);
                _repository.Game.CreateGame(gameEntity);
                _repository.Save();

                var createdGame = _mapper.Map<GameDto>(gameEntity);
                _logger.LogInfo($"Created game: {createdGame}");
                return CreatedAtRoute("GameById", new { id = createdGame.Id }, createdGame);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception inside CreateGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, [FromBody] GameForUpdateDto game)
        {
            try
            {
                if (game is null)
                {
                    _logger.LogError("Game object is null.");
                    return BadRequest("Game is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid game object sent from client.");
                    return BadRequest("Invalid model");
                }
                var existingGenresIds = _repository.Genre.GetAll().Select(x => x.Id);
                if (!game.GenresIds.All(existingGenresIds.Contains))
                {
                    return BadRequest($"Attempt to add a non-existent genre id for a game");
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
                _logger.LogError($"Exception inside UpdateGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
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
                    _logger.LogError("Game object is null.");
                    return NotFound();
                }
                _repository.Game.DeleteGame(game);
                _repository.Save();
                _logger.LogInfo($"Deleted game with id: {id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception inside UpdateGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        [Route("genre/{genreId}")]
        public IActionResult GetGamesByGenre(int genreId)
        {
            var genre = _repository.Genre.GetById(genreId);
            if (genre is null)
            {
                _logger.LogError($"The genre with the requested id({genreId}) does not exist.");
                return NotFound();
            }
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