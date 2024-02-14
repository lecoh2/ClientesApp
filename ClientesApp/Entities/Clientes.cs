using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Entities
{
    public class Clientes
    {
        private Guid? _idCliente;
        private string _nome;
        private string _cpf;
        private string? _telefone;
        private string? _email;
        private int? _idade;
        private int? _situacao;
        private string? _dataNascimento;
        private DateTime? _dataCadastro;
        private DateTime? _dataAltualizacao;
        private Endereco? _endereco;

        public Guid? IdCliente { get => _idCliente; set => _idCliente = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string? Telefone { get => _telefone; set => _telefone = value; }
        public int? Idade { get => _idade; set => _idade = value; }
        public int? Situacao { get => _situacao; set => _situacao = value; }
        public string? DataNascimento { get => _dataNascimento; set => _dataNascimento = value; }
        public DateTime? DataCadastro { get => _dataCadastro; set => _dataCadastro = value; }
        public DateTime? DataAlteracao { get => _dataAltualizacao; set => _dataAltualizacao = value; }
        public string? Email { get => _email; set => _email = value; }
        public Endereco? Endereco { get => _endereco; set => _endereco = value; }
    }
}
