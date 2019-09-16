using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuncionarioApi.Models;

namespace FuncionarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioContext _context;

        public FuncionarioController(FuncionarioContext context)
        {
            _context = context;

            if (_context.Funcionarios.Count() == 0)
            {
                _context.Funcionarios.Add(new Funcionario { Name = "Lucas Augusto Santos", Cargo = "Desenvolvedor", idade = 27});
                _context.SaveChanges();
            }
        }

        // GET: api/Funcionario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionario()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        // GET: api/Funcionario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(long id)
        {
            var Funcionario = await _context.Funcionarios.FindAsync(id);

            if (Funcionario == null)
            {
                return NotFound();
            }
     
            return Funcionario;
        }

        // POST: api/Funcionario
        [HttpPost]
        public async Task<ActionResult<Funcionario>> PostTodoItem(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFuncionario), new { id = funcionario.Id }, funcionario);
        }

        // PUT: api/Funcionario
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(long id, Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Funcionario
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(long id)
        {
            var Funcionario = await _context.Funcionarios.FindAsync(id);

            if (Funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(Funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}


