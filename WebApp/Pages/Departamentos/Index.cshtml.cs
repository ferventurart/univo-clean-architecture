using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Departamentos
{
    public class IndexModel : PageModel
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public IndexModel(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        [BindProperty]
        public IReadOnlyList<Departamento> Departamentos { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Departamentos = await _departamentoRepository.ListAllAsync();
            return Page();
        }
    }
}
