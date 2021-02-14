using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class CategoriaVM
    {
        public Categoria Categoria { get; set; }
        public List<SelectListItem> Departamentos { get; set; }
    }
}
