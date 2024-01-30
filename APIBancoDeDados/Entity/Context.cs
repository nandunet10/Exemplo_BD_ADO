using APIBancoDeDados.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBancoDeDados.Entity
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<FornecedorModel> Fornecedores { get; set; }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
