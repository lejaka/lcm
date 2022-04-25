using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCM.Models;
using LCM.DBContext;

namespace WebApplication1.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/FixedFSEsController")]
    [ApiController]
    public class FixedFSEsController : ControllerBase
    {
        private readonly DBContext _context;

        public FixedFSEsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/FixedFSEs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FixedFSEs>>> GetlistOfFixedFSEs()
        {
            return await _context.FixedFSE.ToListAsync();
        }

        // GET: api/FixedFSEs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FixedFSEs>> GetFixedFSEs(int id)
        {
            var fixedFSEs = await _context.FixedFSE.FindAsync(id);

            if (fixedFSEs == null)
            {
                return NotFound();
            }

            return fixedFSEs;
        }

        // PUT: api/FixedFSEs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFixedFSEs(int id, FixedFSEs fixedFSEs)
        {
            if (id != fixedFSEs.ID)
            {
                return BadRequest();
            }

            _context.Entry(fixedFSEs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixedFSEsExists(id))
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

        // POST: api/FixedFSEs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FixedFSEs>> PostFixedFSEs(FixedFSEs fixedFSEs)
        {
            _context.FixedFSE.Add(fixedFSEs);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetFixedFSEs", new { id = fixedFSEs.ID }, fixedFSEs);
            return CreatedAtAction(nameof(GetFixedFSEs), new { id = fixedFSEs.ID }, fixedFSEs);

        }

        // DELETE: api/FixedFSEs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFixedFSEs(int id)
        {
            var fixedFSEs = await _context.FixedFSE.FindAsync(id);
            if (fixedFSEs == null)
            {
                return NotFound();
            }

            _context.FixedFSE.Remove(fixedFSEs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FixedFSEsExists(int id)
        {
            return _context.FixedFSE.Any(e => e.ID == id);
        }
    }
}
