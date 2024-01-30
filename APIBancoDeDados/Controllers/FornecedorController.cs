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
    public class FornecedorController : ControllerBase
    {
        private readonly Context _context;
        public FornecedorController(Context context)
        {
            _context = context;
        }

        [HttpGet("ObterTodosFornecedores")]
        public List<FornecedorModel> GetAll()
        {
            //return new FornecedorDB().ObterTodosFornecedores(); //ADO

            return _context.Fornecedores.ToList();
        }

        [HttpGet("ObterDadosFornecedor")]
        public FornecedorModel Get([FromQuery] string CNPJ)
        {
            //return new FornecedorDB().ObterDadosFornecedor(CNPJ);

            return _context.Fornecedores.Single(x => x.CNPJ == CNPJ);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] FornecedorModel fornecedor)
        {
            //new FornecedorDB().InserirDadosFornecedor(fornecedor);

            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();

            return Ok("Fornecedor cadastrado com sucesso!");
        }

        [HttpPut()]
        public IActionResult Put([FromBody] FornecedorModel fornecedor)
        {
            //new FornecedorDB().AlterarDadosFornecedor(fornecedor);

            _context.Fornecedores.Update(fornecedor);
            _context.SaveChanges();

            return Ok("Fornecedor alterado com sucesso!");

        }

        [HttpDelete()]
        public IActionResult Delete([FromQuery] string CNPJ)
        {
            //new FornecedorDB().DeletarFornecedor(CNPJ);

            FornecedorModel fornecedor = _context.Fornecedores.Single(x => x.CNPJ == CNPJ);
            _context.Fornecedores.Remove(fornecedor);
            _context.SaveChanges();


            return Ok("Fornecedor excluido com sucesso!");

        }
    }
}
