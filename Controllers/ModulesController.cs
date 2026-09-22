using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyFlowApi.Data;
using StudyFlowApi.Models;

namespace StudyFlowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModulesController : ControllerBase
    {
        private readonly StudyFlowDbContext _context;

        public ModulesController(StudyFlowDbContext context)
        {
            _context = context;
        }

        // Gets all modules stored in the StudyFlow database.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetModules()
        {
            var modules = await _context.Modules
                .AsNoTracking()
                .ToListAsync();

            return Ok(modules);
        }

        // Gets one module using its database ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Module>> GetModule(int id)
        {
            var module = await _context.Modules.FindAsync(id);

            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        // Creates a new module and saves it to PostgreSQL.
        [HttpPost]
        public async Task<ActionResult<Module>> CreateModule(Module module)
        {
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetModule),
                new { id = module.Id },
                module);
        }

        // Updates an existing module.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(int id, Module module)
        {
            if (id != module.Id)
            {
                return BadRequest();
            }

            var existingModule = await _context.Modules.FindAsync(id);

            if (existingModule == null)
            {
                return NotFound();
            }

            existingModule.Name = module.Name;
            existingModule.Code = module.Code;
            existingModule.Lecturer = module.Lecturer;
            existingModule.Colour = module.Colour;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Deletes a module from PostgreSQL.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var module = await _context.Modules.FindAsync(id);

            if (module == null)
            {
                return NotFound();
            }

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}