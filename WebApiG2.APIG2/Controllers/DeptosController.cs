using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiG2.APIG2.Data;
using WebApiG2.APIG2.Models;

namespace WebApiG2.APIG2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeptosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Deptos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Depto>>> GetDeptos()
        {
            return await _context.Deptos.ToListAsync();
        }

        // GET: api/Deptos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Depto>> GetDepto(int id)
        {
            var depto = await _context.Deptos.FindAsync(id);

            if (depto == null)
            {
                return NotFound();
            }

            return depto;
        }

        // PUT: api/Deptos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepto(int id, Depto depto)
        {
            if (id != depto.Id)
            {
                return BadRequest();
            }

            _context.Entry(depto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptoExists(id))
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

        // POST: api/Deptos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Depto>> PostDepto(Depto depto)
        {
            _context.Deptos.Add(depto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepto", new { id = depto.Id }, depto);
        }

        // DELETE: api/Deptos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Depto>> DeleteDepto(int id)
        {
            var depto = await _context.Deptos.FindAsync(id);
            if (depto == null)
            {
                return NotFound();
            }

            _context.Deptos.Remove(depto);
            await _context.SaveChangesAsync();

            return depto;
        }

        private bool DeptoExists(int id)
        {
            return _context.Deptos.Any(e => e.Id == id);
        }
    }
}
