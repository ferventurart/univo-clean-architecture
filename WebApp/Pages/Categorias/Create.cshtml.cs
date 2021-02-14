using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Specification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Pages.Categorias
{
    public class CreateModel : PageModel
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IDepartamentoRepository _departamentoRepository;

        public CreateModel(ICategoriaRepository categoriaRepository, IDepartamentoRepository departamentoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _departamentoRepository = departamentoRepository;
        }

        [BindProperty]
        public CategoriaVM CategoriaVM { get; set; }


        public async Task OnGet()
        {
            CategoriaVM = new CategoriaVM();
            CategoriaVM.Departamentos = (await _departamentoRepository.ListAsync(new DepartamentosActivosSpecification()))
            .Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            await _categoriaRepository.AddAsync(CategoriaVM.Categoria);
            return RedirectToPage("Index");
        }
    }
}
