using APIBancoDeDados.DataBase;
using APIBancoDeDados.Models;
using System.Data.SqlClient;

namespace APIBancoDeDados.Database
{
    internal class FornecedorDB
    {
        private readonly SqlConnection connection;

        public FornecedorDB()
        {
            connection = ConexaoSqlServer.Conectar();
        }

        internal void InserirDadosFornecedor(FornecedorModel modelo)
        {

            try
            {
                string queryString = "INSERT INTO dbo.Fornecedores VALUES (@CNPJ, @Nome, @Telefone, @Logradouro, @Numero, @Complemento, @Cidade, @Estado, @DataInclusao, null, @Ativo);";

                SqlCommand cmd = new(queryString, connection);

                cmd.Parameters.AddWithValue("@CNPJ", modelo.CNPJ);
                cmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                cmd.Parameters.AddWithValue("@Telefone", modelo.Telefone ?? (object)DBNull.Value);
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

        internal FornecedorModel ObterDadosFornecedor(string cnpjDigitado)
        {
            {
                FornecedorModel modelo = new();

                try
                {
                    string queryString = "SELECT * FROM dbo.Fornecedores WHERE CNPJ = @Cnpj";
                    SqlCommand cmd = new(queryString, connection);

                    cmd.Parameters.AddWithValue("@Cnpj", cnpjDigitado);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        modelo.CNPJ = reader["CNPJ"].ToString();
                        modelo.Nome = reader["Nome"].ToString();
                        modelo.Telefone = reader["Telefone"].ToString();
                        modelo.Logradouro = reader["Logradouro"].ToString();
                        modelo.Numero = reader["Numero"].ToString();
                        modelo.Complemento = reader["Complemento"].ToString();
                        modelo.Cidade = reader["Cidade"].ToString();
                        modelo.Estado = reader["Estado"].ToString();
                        modelo.DataInclusao = Convert.ToDateTime(reader["DataInclusao"].ToString());
                        modelo.DataAlteracao = reader["DataAlteracao"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(reader["DataAlteracao"].ToString());
                        modelo.Ativo = Convert.ToBoolean(reader["Ativo"].ToString());
                    }
                    else
                    {
                        reader.Close();
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

                return modelo;
            }
        }

        internal List<FornecedorModel> ObterTodosFornecedores()
        {
            {
                List<FornecedorModel> lFornecedorModel = new();

                try
                {
                    FornecedorModel fornecedorModel;

                    string queryString = "SELECT * FROM dbo.Fornecedores";
                    SqlCommand cmd = new(queryString, connection);


                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        fornecedorModel = new FornecedorModel();

                        if (!reader["CNPJ"].Equals(DBNull.Value)) fornecedorModel.CNPJ = (String)reader["CNPJ"];
                        if (!reader["Nome"].Equals(DBNull.Value)) fornecedorModel.Nome = (String)reader["Nome"];
                        if (!reader["Telefone"].Equals(DBNull.Value)) fornecedorModel.Telefone = (String)reader["Telefone"];
                        if (!reader["Logradouro"].Equals(DBNull.Value)) fornecedorModel.Logradouro = (String)reader["Logradouro"];
                        if (!reader["Numero"].Equals(DBNull.Value)) fornecedorModel.Numero = (String)reader["Numero"];
                        if (!reader["Complemento"].Equals(DBNull.Value)) fornecedorModel.Complemento = (String)reader["Complemento"];
                        if (!reader["Cidade"].Equals(DBNull.Value)) fornecedorModel.Cidade = (String)reader["Cidade"];
                        if (!reader["Estado"].Equals(DBNull.Value)) fornecedorModel.Estado = (String)reader["Estado"];
                        if (!reader["DataInclusao"].Equals(DBNull.Value)) fornecedorModel.DataInclusao = (DateTime)reader["DataInclusao"];
                        if (!reader["DataAlteracao"].Equals(DBNull.Value)) fornecedorModel.DataAlteracao = (DateTime)reader["DataAlteracao"];
                        if (!reader["Ativo"].Equals(DBNull.Value)) fornecedorModel.Ativo = (bool)reader["Ativo"];

                        lFornecedorModel.Add(fornecedorModel);
                    }

                    reader.Close();


                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

                return lFornecedorModel;
            }
        }
        internal void AlterarDadosFornecedor(FornecedorModel modelo)
        {
            {

                try
                {
                    string queryString = "UPDATE dbo.Fornecedores SET Nome = @Nome, Telefone = @Telefone, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Cidade = @Cidade, Estado = @Estado, DataAlteracao = @DataAlteracao, Ativo = @Ativo WHERE CNPJ = @CNPJ";

                    SqlCommand cmd = new(queryString, connection);

                    cmd.Parameters.AddWithValue("@CNPJ", modelo.CNPJ);
                    cmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                    cmd.Parameters.AddWithValue("@Telefone", modelo.Telefone ?? (object)DBNull.Value);
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
                    throw new Exception(ex.Message);

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

            }
        }

        internal void DeletarFornecedor(string cnpjDigitado)
        {
            try
            {
                string queryString = "DELETE dbo.Fornecedores WHERE CNPJ = @CNPJ";
                SqlCommand cmd = new(queryString, connection);

                cmd.Parameters.AddWithValue("@CNPJ", cnpjDigitado);

                connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar excluir funcionario - " + ex.Message);

            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

        }
    }
}
