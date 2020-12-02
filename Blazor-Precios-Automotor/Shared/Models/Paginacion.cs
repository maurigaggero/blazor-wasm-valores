using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor_Precios_Automotor.Shared.Models
{
    public class Paginacion
    {
        public int Pagina { get; set; } = 1;
        public int CantidadMostrar { get; set; } = 10;
    }
}
