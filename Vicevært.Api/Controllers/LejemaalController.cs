using Microsoft.AspNetCore.Mvc;
using Vicevært.Application.Contract;
using Vicevært.Contract.Dtos;

namespace Vicevært.Api.Controllers
{

        [Route("/api/Lejemaal")]
        [ApiController]
        public class LejemaalController : ControllerBase
        {

            private readonly ILejemaalQuery _lejemaalQuery;

            public LejemaalController( ILejemaalQuery lejemaalQuery)
            {

                 _lejemaalQuery = lejemaalQuery;
            }


            [HttpGet]
            public async Task<ActionResult<IEnumerable<LejemaalDto>>> GetAsync()
            {
                var result = new List<LejemaalDto>();
                var lejemaal = await _lejemaalQuery.GetLejemaalAsync();
                lejemaal.ToList()
                    .ForEach(a => result.Add(new LejemaalDto
                    {
                        LejemålId = a.LejemålId,
                        StreetName = a.StreetName,
                        BuildingNumber = a.BuildingNumber,
                        SecondaryAddress = a.SecondaryAddress,
                        Postcode = a.Postcode,
                        City = a.City,
                        State = a.State,
                        CountryCode = a.CountryCode,
                        IsBookable = a.IsBookable
                    }));
                return result;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<LejemaalDto?>> GetAsync(int id)
            {
                var lejemaal = await _lejemaalQuery.GetLejemaalAsync(id);
                if (lejemaal is null) return BadRequest();
                return new LejemaalDto
                {
                    LejemålId = lejemaal.LejemålId,
                    StreetName = lejemaal.StreetName,
                    BuildingNumber = lejemaal.BuildingNumber,
                    SecondaryAddress = lejemaal.SecondaryAddress,
                    Postcode = lejemaal.Postcode,
                    City = lejemaal.City,
                    State = lejemaal.State,
                    CountryCode = lejemaal.CountryCode,
                    IsBookable = lejemaal.IsBookable
                };
            }

        }
    }

