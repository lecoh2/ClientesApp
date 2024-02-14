using ClientesApp.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientesApp.Repositories
{
    public class ClienteRepository
    {
        private string _connectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBCLIENTES;Integrated Security=True;";

        public void INSERT(Clientes c)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var transcrtion = connection.BeginTransaction();
                connection.Execute(
                @"INSERT INTO CLIENTE (IDCLIENTE, NOME, CPF, TELEFONE,EMAIL,
                            DATANASCIMENTO, DATACADASTRO, IDADE)
                            VALUES(@IDCLIENTE, @NOME, @CPF, @TELEFONE,@EMAIL,
                            @DATANASCIMENTO, @DATACADASTRO, @IDADE)", new
                {
                    @IDCLIENTE = c.IdCliente,
                    @NOME = c.Nome,
                    @CPF = c.Cpf,
                    @TELEFONE = c.Telefone,
                    @EMAIL = c.Email,
                    @DATANASCIMENTO = c.DataNascimento,
                    @DATACADASTRO = c.DataCadastro,
                    @IDADE = c.Idade

                }, transcrtion);
                connection.Execute(@"INSERT INTO ENDERECO(
                                    IDENDERECO, CEP, LOGRADOURO, NUMERO, COMPLEMENTO,
                                    CIDADE, UF, IDCLIENTE)
                                    VALUES (@IDENDERECO, @CEP, @LOGRADOURO, @NUMERO, @COMPLEMENTO,
                                    @CIDADE, @UF, @IDCLIENTE)", new
                {
                    @IDENDERECO = c.Endereco?.IdEndereco,
                    @CEP = c.Endereco?.Cep,
                    @LOGRADOURO = c.Endereco?.Logradouro,
                    @NUMERO = c.Endereco?.Numero,
                    @COMPLEMENTO = c.Endereco?.Complemento,
                    @CIDADE = c.Endereco?.Cidade,
                    @UF = c.Endereco?.Uf,
                    @IDCLIENTE = c.IdCliente
                }, transcrtion);
                transcrtion.Commit();
            }
        }
        public void UPDATE(Clientes c)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(
                    @"UPDATE CLIENTE SET NOME=@NOME, CPF=@CPF,TELEFONE=@TELEFONE,
                    DATANASCIMENTO = @DATANASCIMENTO, IDADE=@IDADE,
                    DATAATUALIZACAOM=@DATAATUALIZACAOM  WHERE IDCLIENTE =@IDCLIENTE", new
                    {

                        @NOME = c.Nome,
                        @CPF = c.Cpf,
                        @TELEFONE = c.Telefone,
                        @DATANASCIMENTO = c.DataNascimento,
                        @IDADE = c.Idade,
                        @DATAATUALIZACAOM = c.DataAlteracao,
                        @IDCLIENTE = c.IdCliente
                    });

            }
        }
        public void DELETE(Clientes c)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"UPDATE CLIENTE SET SITUACAO = 0 WHERE IDCLIENTE=@IDCLIENTE", new
                {
                    @IDCLIENTE = c.IdCliente


                });
            }
        }

        public List<Clientes> GETALL()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Clientes>(@"SELECT 
                        IDCLIENTE, NOME, CPF, TELEFONE,EMAIL, DATANASCIMENTO, IDADE,
                        DATACADASTRO, SITUACAO FROM CLIENTE WHERE SITUACAO = 1").ToList();

            }
        }
        public Clientes? GETBYID(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Clientes>(@"SELECT 
                        IDCLIENTE, NOME, CPF, TELEFONE,EMAIL, DATANASCIMENTO, IDADE,
                        DATACADASTRO, SITUACAO FROM CLIENTE WHERE SITUACAO = 1 AND IDCLIENTE=@IDCLIENTE",
                        new
                        {
                            @IDCLIENTE = id
                        }).FirstOrDefault();
            }
        }

    }
}

