using ClientesApp.Entities;

namespace SistemaClientes.Services.Models
{
    public class ClientesPostModels
    {
        private Guid? _idCliente;
        private string? _nome;
        private string? _cpf;
        private string? _telefone;
        private string? _email;
        private string? _dataNascimento;
        private int? _idade;
        private DateTime? _dataCadastro;
        private DateTime? _dataAtualizacao;
        private EnderecoPostModels? endereco;

        public Guid? IdCliente { get => _idCliente; set => _idCliente = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Cpf { get => _cpf; set => _cpf = value; }
        public string? Telefone { get => _telefone; set => _telefone = value; }
        public string? DataNascimento { get => _dataNascimento; set => _dataNascimento = value; }
        public int? Idade { get => _idade; set => _idade = value; }
        public string? Email { get => _email; set => _email = value; }
        public EnderecoPostModels? Endereco { get => endereco; set => endereco = value; }
    }
}
