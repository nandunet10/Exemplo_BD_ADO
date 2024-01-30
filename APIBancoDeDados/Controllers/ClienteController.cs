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
    public class ClienteController : ControllerBase
    {
        private readonly Context _context;
        public ClienteController(Context context)
        {
            _context = context;
        }

        [HttpGet("ObterTodosClientes")]
        public List<ClienteModel> Get()
        {
            //return new ClienteDB().ObterTodosClientes(); //ADO

            return _context.Clientes.ToList(); //Entity
        }

        [HttpGet("ObterDadosCliente")]
        public ClienteModel Get([FromQuery] string CPF)
        {
            //return new ClienteDB().ObterDadosCliente(CPF);

            return _context.Clientes.Single(x => x.CPF == CPF);

        }

        [HttpPost()]
        public IActionResult Post([FromBody] ClienteModel cliente)
        {
            //new ClienteDB().InserirDadosCliente(cliente);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return Ok("Cliente cadastrado com sucesso!");
        }

        [HttpPut()]
        public IActionResult Put([FromBody] ClienteModel cliente)
        {
            //new ClienteDB().AlterarDadosCliente(cliente);

            _context.Clientes.Update(cliente);
            _context.SaveChanges();

            return Ok("Cliente alterado com sucesso!");
        }


        [HttpDelete()]
        public IActionResult Delete([FromQuery] string CPF)
        {
            //new ClienteDB().DeletarCliente(CPF);

            ClienteModel cliente =  _context.Clientes.Single(x => x.CPF == CPF);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok("Cliente excluido com sucesso!");
        }
    }
}
