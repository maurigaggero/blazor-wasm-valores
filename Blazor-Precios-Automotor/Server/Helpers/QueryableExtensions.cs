using Blazor_Precios_Automotor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Precios_Automotor.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<t> Paginar<t>(this IQueryable<t> queryable, Paginacion paginacion)
        {
            return queryable
                .Skip((paginacion.Pagina - 1) * paginacion.CantidadMostrar)
                .Take(paginacion.CantidadMostrar);
        }
    }
}