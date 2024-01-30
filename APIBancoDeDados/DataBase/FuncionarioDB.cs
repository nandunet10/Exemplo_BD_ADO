using System.Data.SqlClient;
using APIBancoDeDados.DataBase;
using APIBancoDeDados.Models;

namespace APIBancoDeDados.Database
{
    internal class FuncionarioDB
    {
        private readonly SqlConnection connection;

        public FuncionarioDB()
        {
            connection = ConexaoSqlServer.Conectar();
        }

        internal void InserirDadosFuncionario(FuncionarioModel modelo)
        {

            try
            {
                string queryString = "INSERT INTO dbo.Funcionarios VALUES (@CPF, @RG, @Nome, @DataNascimento, @Telefone, @Celular, @Logradouro, @Numero, @Complemento, @Cidade, @Estado, @DataInclusao, null, @Ativo);";

                SqlCommand cmd = new(queryString, connection);

                cmd.Parameters.AddWithValue("@CPF", modelo.CPF);
                cmd.Parameters.AddWithValue("@RG", modelo.RG);
                cmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", modelo.DataNascimento);
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
                throw new Exception("Erro ao incluir o funcionario - " + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        internal FuncionarioModel ObterDadosFuncionario(string cpfDigitado)
        {
            {
                FuncionarioModel modelo = new();

                try
                {
                    string queryString = "SELECT * FROM dbo.Funcionarios WHERE CPF = @CPF";
                    SqlCommand cmd = new(queryString, connection);

                    cmd.Parameters.AddWithValue("@CPF", cpfDigitado);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        modelo.CPF = reader["CPF"].ToString();
                        modelo.RG = reader["RG"].ToString();
                        modelo.Nome = reader["Nome"].ToString();
                        modelo.DataNascimento = Convert.ToDateTime(reader["DataNascimento"].ToString());
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
                    throw new Exception("Erro ao obter dados do funcionario - " + ex.Message);

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

                return modelo;
            }
        }

        internal List<FuncionarioModel> ObterTodosFuncionarios()
        {
            {
                List<FuncionarioModel> lFuncionarioModel = new();

                try
                {
                    FuncionarioModel funcionarioModel;

                    string queryString = "SELECT * FROM dbo.Funcionarios";
                    SqlCommand command = new(queryString, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        funcionarioModel = new FuncionarioModel();

                        if (!reader["CPF"].Equals(DBNull.Value)) funcionarioModel.CPF = (String)reader["CPF"];
                        if (!reader["RG"].Equals(DBNull.Value)) funcionarioModel.RG = (String)reader["RG"];
                        if (!reader["Nome"].Equals(DBNull.Value)) funcionarioModel.Nome = (String)reader["Nome"];
                        if (!reader["DataNascimento"].Equals(DBNull.Value)) funcionarioModel.DataNascimento = (DateTime)reader["DataNascimento"];
                        if (!reader["Telefone"].Equals(DBNull.Value)) funcionarioModel.Telefone = (String)reader["Telefone"];
                        if (!reader["Celular"].Equals(DBNull.Value)) funcionarioModel.Celular = (String)reader["Celular"];
                        if (!reader["Logradouro"].Equals(DBNull.Value)) funcionarioModel.Logradouro = (String)reader["Logradouro"];
                        if (!reader["Numero"].Equals(DBNull.Value)) funcionarioModel.Numero = (String)reader["Numero"];
                        if (!reader["Complemento"].Equals(DBNull.Value)) funcionarioModel.Complemento = (String)reader["Complemento"];
                        if (!reader["Cidade"].Equals(DBNull.Value)) funcionarioModel.Cidade = (String)reader["Cidade"];
                        if (!reader["Estado"].Equals(DBNull.Value)) funcionarioModel.Estado = (String)reader["Estado"];
                        if (!reader["DataInclusao"].Equals(DBNull.Value)) funcionarioModel.DataInclusao = (DateTime)reader["DataInclusao"];
                        if (!reader["DataAlteracao"].Equals(DBNull.Value)) funcionarioModel.DataAlteracao = (DateTime)reader["DataAlteracao"];
                        if (!reader["Ativo"].Equals(DBNull.Value)) funcionarioModel.Ativo = (bool)reader["Ativo"];

                        lFuncionarioModel.Add(funcionarioModel);
                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter lista de funcionarios - " + ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

                return lFuncionarioModel;
            }
        }

        internal void AlterarDadosFuncionario(FuncionarioModel modelo)
        {
            {

                try
                {
                    string queryString = "UPDATE dbo.Funcionarios SET RG = @RG, Nome = @Nome, DataNascimento = @DataNascimento, Telefone = @Telefone, Celular = @Celular, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Cidade = @Cidade, Estado = @Estado, DataAlteracao = @DataAlteracao, Ativo = @Ativo WHERE CPF = @CPF";

                    SqlCommand cmd = new(queryString, connection);

                    cmd.Parameters.AddWithValue("@CPF", modelo.CPF);
                    cmd.Parameters.AddWithValue("@RG", modelo.RG);
                    cmd.Parameters.AddWithValue("@Nome", modelo.Nome);
                    cmd.Parameters.AddWithValue("@DataNascimento", modelo.DataNascimento);
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
                    throw new Exception("Erro ao tentar alterar dados do funcionario! - " + ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

            }
        }

        internal void DeletarFuncionario(string cpfDigitado)
        {
            try
            {
                string queryString = "DELETE dbo.Funcionarios WHERE CPF = @CPF";
                SqlCommand cmd = new(queryString, connection);

                cmd.Parameters.AddWithValue("@CPF", cpfDigitado);

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
