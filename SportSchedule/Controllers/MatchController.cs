using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SportSchedule.Models;
using SportSchedule.Models.Repository;
using Microsoft.Extensions.Logging;

namespace SportSchedule.Controllers
{
    /// <summary>
    /// Main user controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MatchController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMatchRepository _repository;
        public MatchController(IMatchRepository repository, ILogger<MatchController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        [HttpPut("setResult/{id}/{team1Points}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> SetMatchResult(int id, int team1Points)
        {
            _logger.LogInformation($"Set match result fom match: {id}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _repository.SetMatchResult(id, team1Points);

            if (result == -1)
                return NotFound();

            return Ok();
        }

        /// <summary>
        /// Not played a games.
        /// </summary>
        /// <param name="tournamentName"></param> 
        [HttpGet("playedGames/{tournamentName}")]
        [ProducesResponseType(200, Type = typeof(List<TourMatch>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TourMatch>> GetPlayedGames(string tournamentName)
        {
            _logger.LogInformation($"Get played games for tour: {tournamentName}");
            var games = await _repository.GetPlayedGames(tournamentName);

            if (games == null)
                return NotFound();
            return Ok(games);
        }
        /// <summary>
        /// Not played a games.
        /// </summary>
        /// <param name="tournamentName"></param>   
        [HttpGet("notPlayedgames/{tournamentName}")]
        [ProducesResponseType(200, Type = typeof(List<TourMatch>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TourMatch>> GetNotPlayedGames(string tournamentName)
        {
            _logger.LogInformation($"Get not played games for tour: {tournamentName}");
            var games = await _repository.GetNotPlayedGames(tournamentName);

            if (games == null)
                return NotFound();

             return Ok(games);
        }


    }
}