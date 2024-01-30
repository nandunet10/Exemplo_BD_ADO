using APIBancoDeDados.DataBase;
using APIBancoDeDados.Models;
using System.Data.SqlClient;

namespace APIBancoDeDados.Database
{
    internal class ClienteDB
    {
        private readonly SqlConnection connection;

        public ClienteDB()
        {
            connection = ConexaoSqlServer.Conectar();
        }

        internal void InserirDadosCliente(ClienteModel modelo)
        {

            try
            {
                string queryString = "INSERT INTO dbo.Clientes VALUES (@CPF, @RG, @Nome, @Telefone, @Celular, @Logradouro, @Numero, @Complemento, @Cidade, @Estado, @DataInclusao, null, @Ativo);";

                SqlCommand cmd = new(queryString, connection);

                cmd.Parameters.AddWithValue("@CPF", modelo.CPF);
                cmd.Parameters.AddWithValue("@RG", modelo.RG);
                cmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                cmd.Parameters.AddWithValue("@Telefone", modelo.Telefone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Celular", modelo.Celular);
                cmd.Parameters.AddWithValue("@Logradouro", modelo.Logradouro);
                cmd.Parameters.AddWithValue("@Numero", modelo.Numero);
                cmd.Parameters.AddWithValue("@Complemento", modelo.Complemento ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Cidade", modelo.Cidade);
                cmd.Parameters.AddWithValue("@Estado", modelo.Estado);
                cmd.Parameters.AddWithValue("@DataInclusao", DateTime.Now);
                cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao incluir o cliente - " + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        internal ClienteModel ObterDadosCliente(string cpfDigitado)
        {
            {
                ClienteModel modelo = new();

                try
                {
                    string queryString = "SELECT * FROM dbo.Clientes WHERE CPF = @CPF";
                    SqlCommand cmd = new(queryString, connection);

                    cmd.Parameters.AddWithValue("@CPF", cpfDigitado);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        modelo.CPF = Convert.ToString(reader["CPF"]);
                        modelo.RG = reader["RG"].ToString();
                        modelo.Nome = reader["Nome"].ToString();
                        modelo.Telefone = reader["Telefone"].ToString();
                        modelo.Celular = reader["Celular"].ToString();
                        modelo.Logradouro = reader["Logradouro"].ToString();
                        modelo.Numero = reader["Numero"].ToString();
                        modelo.Complemento = reader["Complemento"].ToString();
                        modelo.Cidade = reader["Cidade"].ToString();
                        modelo.Estado = reader["Estado"].ToString();
                        modelo.DataInclusao = Convert.ToDateTime(reader["DataInclusao"].ToString());
                        modelo.DataAlteracao = reader["DataAlteracao"].ToString() == string.Empty ? DateTime.Now : Convert.ToDateTime(reader["DataAlteracao"].ToString());
                        modelo.Ativo = Convert.ToBoolean(reader["Ativo"].ToString());
                    }
                    else
                    {
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter dados do cliente - " + ex.Message);

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

                return modelo;
            }
        }

        internal void AlterarDadosCliente(ClienteModel modelo)
        {
            {

                try
                {
                    string queryString = "UPDATE dbo.Clientes SET RG = @RG, Nome = @Nome, Telefone = @Telefone, Celular = @Celular, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Cidade = @Cidade, Estado = @Estado, DataAlteracao = @DataAlteracao, Ativo = @Ativo WHERE CPF = @CPF";

                    SqlCommand cmd = new(queryString, connection);

                    cmd.Parameters.AddWithValue("@CPF", modelo.CPF);
                    cmd.Parameters.AddWithValue("@RG", modelo.RG);
                    cmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                    cmd.Parameters.AddWithValue("@Telefone", modelo.Telefone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Celular", modelo.Celular);
                    cmd.Parameters.AddWithValue("@Logradouro", modelo.Logradouro);
                    cmd.Parameters.AddWithValue("@Numero", modelo.Numero);
                    cmd.Parameters.AddWithValue("@Complemento", modelo.Complemento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cidade", modelo.Cidade);
                    cmd.Parameters.AddWithValue("@Estado", modelo.Estado);
                    cmd.Parameters.AddWithValue("@DataAlteracao", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Ativo", modelo.Ativo);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao tentar alterar dados do cliente - " + ex.Message);

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

            }
        }

        internal List<ClienteModel> ObterTodosClientes()
        {
            List<ClienteModel> lClienteModel = new();

            try
            {
                ClienteModel clienteModel;

                string queryString = "SELECT * FROM Clientes";
                SqlCommand command = new(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    clienteModel = new ClienteModel();

                    if (!reader["CPF"].Equals(DBNull.Value)) clienteModel.CPF = (String)reader["CPF"];
                    if (!reader["RG"].Equals(DBNull.Value)) clienteModel.RG = (String)reader["RG"];
                    if (!reader["Nome"].Equals(DBNull.Value)) clienteModel.Nome = (String)reader["Nome"];
                    if (!reader["Telefone"].Equals(DBNull.Value)) clienteModel.Telefone = (String)reader["Telefone"];
                    if (!reader["Celular"].Equals(DBNull.Value)) clienteModel.Celular = (String)reader["Celular"];
                    if (!reader["Logradouro"].Equals(DBNull.Value)) clienteModel.Logradouro = (String)reader["Logradouro"];
                    if (!reader["Numero"].Equals(DBNull.Value)) clienteModel.Numero = (String)reader["Numero"];
                    if (!reader["Complemento"].Equals(DBNull.Value)) clienteModel.Complemento = (String)reader["Complemento"];
                    if (!reader["Cidade"].Equals(DBNull.Value)) clienteModel.Cidade = (String)reader["Cidade"];
                    if (!reader["Estado"].Equals(DBNull.Value)) clienteModel.Estado = (String)reader["Estado"];
                    if (!reader["DataInclusao"].Equals(DBNull.Value)) clienteModel.DataInclusao = (DateTime)reader["DataInclusao"];
                    if (!reader["DataAlteracao"].Equals(DBNull.Value)) clienteModel.DataAlteracao = (DateTime)reader["DataAlteracao"];
                    if (!reader["Ativo"].Equals(DBNull.Value)) clienteModel.Ativo = (bool)reader["Ativo"];

                    lClienteModel.Add(clienteModel);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar obter lista de clientes - " + ex.Message);

            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            return lClienteModel;
        }

        internal void DeletarCliente(string cpfDigitado)
        {

            try
            {
                string queryString = "DELETE dbo.Clientes WHERE CPF = @CPF";
                SqlCommand cmd = new(queryString, connection);

                cmd.Parameters.AddWithValue("@CPF", cpfDigitado);

                connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar excluir cliente - " + ex.Message);

            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

        }

    }
}
