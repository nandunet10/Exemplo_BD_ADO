using APIBancoDeDados.Database;
using APIBancoDeDados.Entity;
using APIBancoDeDados.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBancoDeDados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FuncionarioController : ControllerBase
    {
        private readonly Context _context;
        public FuncionarioController(Context context)
        {
            _context = context;
        }

        [HttpGet("ObterTodosFuncionarios")]
        public List<FuncionarioModel> GetAll()
        {
            //return new FuncionarioDB().ObterTodosFuncionarios(); //ADO

            return _context.Funcionarios.ToList();
        }

        [HttpGet("ObterDadosFuncionario")]
        public FuncionarioModel Get([FromQuery] string CPF)
        {
            //return new FuncionarioDB().ObterDadosFuncionario(CPF);

            return _context.Funcionarios.Single(x => x.CPF == CPF);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] FuncionarioModel funcionario)
        {
            //new FuncionarioDB().InserirDadosFuncionario(funcionario);

            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();

            return Ok("Funcionario cadastrado com sucesso!");
        }

        [HttpPut()]
        public IActionResult Put([FromBody] FuncionarioModel funcionario)
        {
            //new FuncionarioDB().AlterarDadosFuncionario(funcionario);

            _context.Funcionarios.Update(funcionario);
            _context.SaveChanges();

            return Ok("Dados funcionario alterado com sucesso!");
        }

        [HttpDelete()]
        public IActionResult Delete([FromQuery] string CPF)
        {
            new FuncionarioDB().DeletarFuncionario(CPF);

            //FuncionarioModel funcionario = _context.Funcionarios.Single(x => x.CPF == CPF);
            //_context.Clientes.Remove(funcionario);
            //_context.SaveChanges();


            return Ok("Funcionario excluido com sucesso!");

        }

    }
}
