using ClientesApp.Entities;

namespace SistemaClientes.Services.Models
{
    public class EnderecoPostModels
    {
        private Guid? _idEndereco;
        private string? _cep;
        private string? _logradouro;
        private string? _numero;
        private string? _complemento;
        private string? _cidade;
        private string? _uf;
        private Guid? _idCliente;
      
        public Guid? IdEndereco { get => _idEndereco; set => _idEndereco = value; }
        public string? Cep { get => _cep; set => _cep = value; }
        public string? Logradouro { get => _logradouro; set => _logradouro = value; }
        public string? Numero { get => _numero; set => _numero = value; }
        public string? Complemento { get => _complemento; set => _complemento = value; }
        public string? Cidade { get => _cidade; set => _cidade = value; }
        public string? Uf { get => _uf; set => _uf = value; }
        public Guid? IdCliente { get => _idCliente; set => _idCliente = value; }
      
    }
}
