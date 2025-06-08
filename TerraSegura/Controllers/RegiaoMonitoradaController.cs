using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerraSegura.Domain.Entity;
using TerraSegura.DTOs;
using TerraSegura.Infrastructure.Context;

namespace TerraSegura.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegiaoMonitoradaController : ControllerBase
    {
        private readonly TerraSeguraContext _context;

        public RegiaoMonitoradaController(TerraSeguraContext context)
        {
            _context = context;
        }

        // GET: RegiaoMonitorada
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegiaoMonitorada>>> GetregiaoMonitoradas()
        {
            return await _context.regiaoMonitoradas
                .Include(r => r.SensoresLeituras)
                .ToListAsync();
        }


        // GET: RegiaoMonitorada/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegiaoMonitorada>> GetRegiaoMonitorada(Guid id)
        {
            var regiaoMonitorada = await _context.regiaoMonitoradas.FindAsync(id);

            if (regiaoMonitorada == null)
            {
                return NotFound();
            }

            return regiaoMonitorada;
        }

        // PUT: RegiaoMonitorada/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegiaoMonitorada(Guid id, RegiaoMonitorada regiaoMonitorada)
        {
            if (id != regiaoMonitorada.Id)
            {
                return BadRequest();
            }

            _context.Entry(regiaoMonitorada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegiaoMonitoradaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: RegiaoMonitorada
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegiaoMonitorada>> PostRegiaoMonitorada(RegiaoMonitoradaCreateDto dto)
        {
            var regiaoMonitorada = new RegiaoMonitorada(
                dto.Nome,
                dto.Descricao,
                dto.Latitude,
                dto.Longitude,
                dto.NivelRisco
            );

            _context.regiaoMonitoradas.Add(regiaoMonitorada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegiaoMonitorada", new { id = regiaoMonitorada.Id }, regiaoMonitorada);
        }



        // DELETE: RegiaoMonitorada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegiaoMonitorada(Guid id)
        {
            var regiaoMonitorada = await _context.regiaoMonitoradas.FindAsync(id);
            if (regiaoMonitorada == null)
            {
                return NotFound();
            }

            _context.regiaoMonitoradas.Remove(regiaoMonitorada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegiaoMonitoradaExists(Guid id)
        {
            return _context.regiaoMonitoradas.Any(e => e.Id == id);
        }
    }
}
