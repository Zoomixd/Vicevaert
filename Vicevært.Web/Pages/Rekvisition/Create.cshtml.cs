using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vicevært.Application.Contract;
using Vicevært.Application.Contract.Dtos;
using Vicevært.Contract;
using Vicevært.Contract.Dtos;
using Vicevært.Domain.Entities;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Web.Pages.Rekvisition
{
    public class CreateModel : PageModel
    {
        private readonly IRekvisitionService _rekvisitionService;

        public CreateModel(IRekvisitionService rekvisitionService)
        {
            _rekvisitionService = rekvisitionService;
        }


        
        //private readonly Vicevært.Infrastructure.Database.DatabaseContext _context;

        //public CreateModel(Vicevært.Infrastructure.Database.DatabaseContext context)
        //{
        //    _context = context;
        //}

        //[BindProperty]
        //public Domain.Entities.Rekvisition Rekvisition { get; set; } = default!;

        [BindProperty] public RekvisitionCreateModel Rekvisition { get; set; } = new();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            
            await _rekvisitionService.CreateAsync(Rekvisition.GetAsRekvisitionDto());
            //_context.Rekvisition.Add(Rekvisition);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");


        }


        public void OnGet()
        {
            Rekvisition = new RekvisitionCreateModel();
        }

        public class RekvisitionCreateModel
        {
            public int RekvisitionId { get; set; }

            public string RekvisitionType { get; set; }

            public string Kommentar { get; set; }

            public int LejerId { get; set; }


            public RekvisitionDto GetAsRekvisitionDto()
            {
                return new RekvisitionDto { RekvisitionType = RekvisitionType, Kommentar = Kommentar, LejerId = LejerId };
            }

        }



    }
}
