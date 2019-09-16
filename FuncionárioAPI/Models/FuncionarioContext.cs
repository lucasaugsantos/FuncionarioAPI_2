using Microsoft.EntityFrameworkCore;

namespace FuncionarioApi.Models
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> options)
            : base(options)
        {
        }    
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}