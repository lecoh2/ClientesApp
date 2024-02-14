using ClientesApp.Entities;
using ClientesApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaClientes.Services.Models;

namespace SistemaClientes.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesControllers : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClientesPostModels model)
        {
            try
            {
                var cliente = new Clientes
                {
                    IdCliente = Guid.NewGuid(),
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Telefone = model.Telefone,
                    Email = model.Email,
                    DataNascimento = model.DataNascimento,
                    DataCadastro = DateTime.Now,
                    Idade = model.Idade

                };
                cliente.Endereco = new Endereco
                {
                    IdEndereco = Guid.NewGuid(),
                    Cep = model.Endereco.Cep,
                    Logradouro=model.Endereco.Logradouro,
                    Numero=model.Endereco.Numero,
                    Complemento=model.Endereco.Complemento,
                    Cidade=model.Endereco.Cidade,
                    Uf=model.Endereco.Uf,
                    IdCliente = Guid.NewGuid()
                
                };

                var clienteRepository = new ClienteRepository();
                clienteRepository.INSERT(cliente);
                return StatusCode(201, new { message = "O cliente " + cliente.Nome + ", foi cadastrado com sucesso" });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.GETALL();
                if (cliente != null)
                {
                    return StatusCode(200, cliente);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var clienteRepositury = new ClienteRepository();
                var cliente = clienteRepositury.GETBYID(id);
                if (cliente != null)
                {
                    return StatusCode(200, cliente);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(ClientesPostModels model)
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.GETBYID(model.IdCliente.Value);
                if (cliente != null)
                {
                    cliente.Nome = model.Nome;
                    cliente.Cpf = model.Cpf;
                    cliente.Telefone = model.Telefone;
                    cliente.Email = model.Email;
                    cliente.DataNascimento = model.DataNascimento;
                    cliente.Idade = model.Idade;
                    cliente.DataAlteracao = DateTime.Now;

                    clienteRepository.UPDATE(cliente);
                    GetALL();

                    return StatusCode(200, new { message = "O cliente " + cliente.Nome + ", foi atualizado." });

                }
                else
                {
                    return StatusCode(400, new { message = "Contato não encontrado" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.GETBYID(id);

                if (cliente != null)
                {
                    clienteRepository.DELETE(cliente);
                    return StatusCode(200, new { message = "Contato " + cliente.Nome + ", excluido" });
                }
                else
                {
                    return StatusCode(400,
new
{
    message = "Contato não encontrado.Verifique o ID."
});
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, new { e.Message });
            }
        }
    }
}