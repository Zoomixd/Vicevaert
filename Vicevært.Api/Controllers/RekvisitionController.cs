using Microsoft.AspNetCore.Mvc;
using Vicevært.Application.Contract;
using Vicevært.Application.Contract.Dtos;
using Vicevært.Contract.Dtos;

namespace Vicevært.Api.Controllers
{
    [Route("/api/Rekvisition")]
    [ApiController]  
    public class RekvisitionController : ControllerBase
    {
        private readonly IRekvisitionCommand _rekvisitionCommand;
        private readonly IRekvisitionQuery _rekvisitionQuery;

        public RekvisitionController(IRekvisitionCommand rekvisitionCommand, IRekvisitionQuery rekvisitionQuery)
        {
            _rekvisitionCommand = rekvisitionCommand;
            _rekvisitionQuery = rekvisitionQuery;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] RekvisitionDto value)
        {
            await _rekvisitionCommand.CreateAsync(new RekvisitionCommandDto
            { RekvisitionId = value.RekvisitionId, RekvisitionType = value.RekvisitionType, Kommentar = value.Kommentar, LejerId = value.LejerId });
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RekvisitionDto>>> GetAsync()
        {
            var result = new List<RekvisitionDto>();
            var rekvisition = await _rekvisitionQuery.GetRekvisitionAsync();
            rekvisition.ToList()
                .ForEach(a => result.Add(new RekvisitionDto { RekvisitionId = a.RekvisitionId, RekvisitionType = a.RekvisitionType, Kommentar = a.Kommentar, LejerId = a.LejerId }));
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RekvisitionDto?>> GetAsync(int id)
        {
            var rekvisition = await _rekvisitionQuery.GetRekvisitionAsync(id);
            if (rekvisition is null) return BadRequest();
            return new RekvisitionDto { RekvisitionId = rekvisition.RekvisitionId, RekvisitionType = rekvisition.RekvisitionType, Kommentar = rekvisition.Kommentar, LejerId = rekvisition.LejerId };
        }

    }
}
