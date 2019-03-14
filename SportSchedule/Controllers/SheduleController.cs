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
using Microsoft.Extensions.Logging;
using SportSchedule.Models.Repository;
using ChoETL;
using System.Text;
using System.Net.Http.Headers;

namespace SportSchedule.Controllers
{
    /// <summary>
    /// Main user controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SheduleController : Controller
    {
        private readonly ILogger _logger;
        private readonly ITournamentRepository _repository;
        public SheduleController(ITournamentRepository repository, ILogger<SheduleController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        /// <summary>
        /// Creates a specific tournament.
        /// </summary>
        /// <param name="tour"></param>        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<TournamentModel>> CreateShedule([FromBody] TournamentViewModel tour)
        {
            _logger.LogInformation($"Generate tournament schedule for {tour.TournamentName}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TournamentModel tournament = TournamentModel.GeterateFromView(tour);

            await _repository.AddTournamentAsync(tournament);
            await _repository.SaveChangesAsync();
            tournament.Matches.ToList().ForEach(m => m.Tournament = null);
            return CreatedAtAction(nameof(CreateShedule), tournament.GetShedule());
        }

        /// <summary>
        /// Get a specific tour.
        /// </summary>
        /// <param name="tournamentName"></param> 
        [HttpGet]
        public async Task<ActionResult<List<TournamentModel>>> FindShedule(string tournamentName)
        {
            _logger.LogInformation($"Get tournament schedule by name {tournamentName}");

            var tournament = await _repository.FindTournamentAsync(tournamentName);
            // tournament.Matches.ToList().ForEach(m => m.Tournament = null);
            return new JsonResult(tournament);
        }

        /// <summary>
        /// Get a specific tour results.
        /// </summary>
        /// <param name="name">Tour name</param> 
        [HttpGet("getTourResults/{name}")]
        public async Task<ActionResult<FileResult>> GetTourResults(string name)
        {
            _logger.LogInformation($"Get tournament results by name {name}");
            var result = await _repository.GetTournamentResult(name);

            // var resultJson = JsonConvert.SerializeObject(result);
            // var sb = new StringBuilder();
            // sb.Append(resultJson);
            // var resultSB = new StringBuilder();

            // using (var r = new ChoJSONReader(sb))
            // {
            //     using (var w = new ChoCSVWriter(resultSB).WithFirstLineHeader())
            //     {
            //         w.Write(r);
            //     }
            // }
            return Ok(result);
        }
    }
}