using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicevært.Contract;
using Vicevært.Contract.Dtos;
using Vicevært.Domain.Entities;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Web.Pages.Rekvisition
{
    public class IndexModel : PageModel
    {

        private readonly IRekvisitionService _rekvisitionService;

        public IndexModel(IRekvisitionService rekvisitionService)
        {
            _rekvisitionService = rekvisitionService;
        }



        [BindProperty] public IEnumerable<RekvisitionIndexModel> Rekvisition { get; set; } = Enumerable.Empty<RekvisitionIndexModel>();

        public async Task OnGetAsync()
        {
            var rekvisition = new List<RekvisitionIndexModel>();
            var dbRekvisition = await _rekvisitionService.GetAsync();
            dbRekvisition.ToList().ForEach(a => rekvisition.Add(new RekvisitionIndexModel(a)));
            Rekvisition = rekvisition;

        }



        public class RekvisitionIndexModel
        {
            public RekvisitionIndexModel(RekvisitionDto rekvisition)
            {
                RekvisitionId = rekvisition.RekvisitionId;
                RekvisitionType = rekvisition.RekvisitionType;
                Kommentar = rekvisition.Kommentar;
                LejerId = rekvisition.LejerId;
            }

            [DisplayName("Rekvisitions ID")] public int RekvisitionId { get; set; }

            [DisplayName("Rekvisitions Type")] public string RekvisitionType { get; set; }

            public string? Kommentar { get; set; }

            public int? LejerId { get; set; }
        }
    }
}
