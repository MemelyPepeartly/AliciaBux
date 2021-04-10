using Alicia.Api.Models.Podcaster_Models;
using Alicia.Logic.Interfaces;
using Alicia.Logic.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alicia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AliciaController : ControllerBase
    {
        private readonly IAliciatory aliciatory;

        public AliciaController(IAliciatory _aliciatory)
        {
            aliciatory = _aliciatory ?? throw new ArgumentNullException(nameof(_aliciatory));
        }

        // GET: api/<AliciaController>
        [HttpGet]
        public async Task<ActionResult<List<Podcaster>>> GetAllPodcasters()
        {
            try
            {
                List<Podcaster> logicPodcasters = await aliciatory.GetAllPodcasters();
                return Ok(logicPodcasters.OrderBy(p => p.podcasterName));
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        // GET: api/<AliciaController>/12345
        [HttpGet("{podcasterID}")]
        public async Task<ActionResult<Podcaster>> GetPodcaster(Guid podcasterID)
        {
            try
            {
                Podcaster logicPodcasters = await aliciatory.GetPodcasterByID(podcasterID);
                return Ok(logicPodcasters);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<AliciaController>
        [HttpPost]
        public async Task<ActionResult<Podcaster>> Post([FromBody] NewPodcasterModel newPodcaster)
        {
            try
            {
                Guid newPodcasterGUID = Guid.NewGuid();
                await aliciatory.CreateNewPodcaster(newPodcaster.podcasterName, newPodcasterGUID);
                await aliciatory.SaveAsync();
                return Ok(await aliciatory.GetPodcasterByID(newPodcasterGUID));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<AliciaController>/GiveBux
        [HttpPut("{podcasterID}/GiveBux")]

        public async Task<ActionResult<Podcaster>> PutGiveBux(Guid podcasterID)
        {
            try
            {
                await aliciatory.GiveBux(podcasterID);
                await aliciatory.SaveAsync();
                return Ok(await aliciatory.GetPodcasterByID(podcasterID));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT api/<AliciaController>/TakeBux
        [HttpPut("{podcasterID}/TakeBux")]
        public async Task<ActionResult<Podcaster>> PutTakeBux(Guid podcasterID)
        {
            try
            {
                await aliciatory.TakeBux(podcasterID);
                await aliciatory.SaveAsync();
                return Ok(await aliciatory.GetPodcasterByID(podcasterID));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
