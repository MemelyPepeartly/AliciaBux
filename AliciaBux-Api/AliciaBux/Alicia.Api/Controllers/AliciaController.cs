using Alicia.Api.Models.Podcaster_Models;
using Alicia.Logic.Interfaces;
using Alicia.Logic.Objects;
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
            List<Podcaster> logicPodcasters = await aliciatory.GetAllPodcasters();
            return Ok(logicPodcasters);
        }

        // GET: api/<AliciaController>/12345
        [HttpGet("{podcasterID}")]
        public async Task<ActionResult<Podcaster>> GetPodcaster(Guid podcasterID)
        {
            Podcaster logicPodcasters = await aliciatory.GetPodcasterByID(podcasterID);
            return Ok(logicPodcasters);
        }

        // POST api/<AliciaController>
        [HttpPost]
        public async Task<ActionResult<Podcaster>> Post([FromBody] NewPodcasterModel newPodcaster)
        {
            Guid newPodcasterGUID = Guid.NewGuid();
            await aliciatory.CreateNewPodcaster(newPodcaster.name, newPodcasterGUID);
            await aliciatory.SaveAsync();
            return Ok(await aliciatory.GetPodcasterByID(newPodcasterGUID));
        }
    }
}
