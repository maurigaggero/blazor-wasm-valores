using Blazor_Precios_Automotor.Server.Helpers;
using Blazor_Precios_Automotor.Shared;
using Blazor_Precios_Automotor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Precios_Automotor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoresController : ControllerBase
    {
        private readonly ValoresContext _context;

        public ValoresController(ValoresContext context)
        {
            _context = context;
        }

        // GET: api/valores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Valores>>> Get()
        {
            return await _context.Valores.ToListAsync();
        }

        // GET: api/valores/pagfilter
        [HttpGet("pagfilter")]
        public async Task<ActionResult<IEnumerable<Valores>>> Get([FromQuery] Paginacion paginacion, [FromQuery] string marca, [FromQuery] string modelo, [FromQuery] string version)
        {
            var queryable = _context.Valores.AsQueryable();
            if (!string.IsNullOrEmpty(marca))
            {
                queryable = queryable.Where(x => x.Marca.Contains(marca));
            }
            if (!string.IsNullOrEmpty(modelo))
            {
                queryable = queryable.Where(x => x.Modelo.Contains(modelo));
            }
            if (!string.IsNullOrEmpty(version))
            {
                queryable = queryable.Where(x => x.Version.Contains(version));
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadMostrar);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

        // GET: api/valores/byid/1
        [HttpGet("byid/{id}")]
        public async Task<ActionResult<Valores>> Get(int id)
        {
            var valores = await _context.Valores.FindAsync(id);

            if (valores == null)
            {
                return NotFound();
            }

            return valores;
        }

        // GET: api/valores/(marca)
        [HttpGet("{marca}")]
        public async Task<List<Valores>> GetValores(string marca)
        {
            var valores = _context.Valores
            .Where(v => v.Marca == marca)
            .ToListAsync();

            return await valores;
        }

        // GET: api/valores/(marca)/(modelo)
        [HttpGet("{marca}/{modelo}")]
        public async Task<List<Valores>> GetValores(string marca, string modelo)
        {
            var valores = _context.Valores
            .Where(v => v.Marca == marca)
            .Where(v => v.Modelo == modelo)
            .ToListAsync();

            return await valores;
        }

        // GET: api/valores/(marca)/(modelo)/(version)
        [HttpGet("{marca}/{modelo}/{version}")]
        public async Task<List<Valores>> GetValores(string marca, string modelo, string version)
        {
            var valores = _context.Valores
            .Where(v => v.Marca == marca)
            .Where(v => v.Modelo == modelo)
            .Where(v => v.Version == version).ToListAsync();

            return await valores;
        }
    }
}