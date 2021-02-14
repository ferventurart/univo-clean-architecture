using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Specification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public IndexModel(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [BindProperty]
        public IReadOnlyList<Categoria> Categorias { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Categorias = await _categoriaRepository.ListAsync(new CategoriasFullSpecification());
            return Page();
        }
    }
}
