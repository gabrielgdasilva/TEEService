using DAO.Models;
using DAO.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class Usuario
    {
        public static bool CadastrarUsuario(UsuarioModel _Usuario)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO " +
                                  "usuarios " +
                                  "(" +
                                  "email," +
                                  "id_cliente," +
                                  "cpf," +
                                  "nome," +
                                  "senha," +
                                  "ativo," +
                                  "data_registro," +
                                  "tipo" +
                                  ")" +
                                  " VALUES " +
                                  "(" +
                                  "@email," +
                                  "@id_cliente," +
                                  "@cpf," +
                                  "@nome," +
                                  "@senha," +
                                  "@ativo," +
                                  "@data_registro," +
                                  "@tipo" +
                                  ");";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = _Usuario.Email;
                cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = _Usuario.ClienteID;
                cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = (_Usuario.Cpf != null) ? _Usuario.Cpf : "";
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = (_Usuario.Nome != null) ? _Usuario.Nome : "";
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = _Usuario.Senha;
                cmd.Parameters.Add("@ativo", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@data_registro", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = 2;

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public static UsuarioModel VerificaAutenticacao(string email)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT " +
                                 "u.email," +
                                 "u.id_cliente, " +
                                 "u.cpf, " +
                                 "u.nome, " +
                                 "u.senha, " +
                                 "u.ativo, " +
                                 "u.data_registro, " +
                                 "u.tipo " +
                                 "FROM " +
                                 "usuarios u " +
                                 "WHERE " +
                                 "u.email = @email";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                UsuarioModel _Usuario = new UsuarioModel();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    using (dr)
                    {

                        _Usuario.Email = (dr["email"]).ToString();
                        _Usuario.ClienteID = Convert.ToInt32(dr["id_cliente"]);
                        _Usuario.Cpf = (dr["cpf"]).ToString();
                        _Usuario.Nome = (dr["nome"]).ToString();
                        _Usuario.Senha = (dr["senha"]).ToString();
                        _Usuario.Ativo = Convert.ToBoolean(dr["ativo"]);
                        _Usuario.DataRegistro = Convert.ToDateTime(dr["data_registro"]);
                        _Usuario.Tipo = Convert.ToInt32(dr["tipo"]);

                    }

                    return _Usuario;
                }
                else
                {
                    return null;
                }
                
            }
        }

        public static UsuarioModel DestalhesDoUsuario(string email)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT " +
                                 "u.email," +
                                 "u.id_cliente," +
                                 "u.cpf," +
                                 "u.nome," +
                                 "u.senha," +
                                 "u.ativo," +
                                 "u.data_registro," +
                                 "u.tipo " +
                                 "FROM " +
                                 "usuarios u " +
                                 "WHERE " +
                                 "u.email = @email";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                UsuarioModel _Usuario = new UsuarioModel();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        _Usuario.Email = (dr["email"]).ToString();
                        _Usuario.ClienteID = Convert.ToInt32(dr["id_cliente"]);
                        _Usuario.Cpf = (dr["cpf"]).ToString();
                        _Usuario.Nome = (dr["nome"]).ToString();
                        _Usuario.Senha = (dr["senha"]).ToString();
                        _Usuario.Ativo = Convert.ToBoolean(dr["ativo"]);
                        _Usuario.DataRegistro = Convert.ToDateTime(dr["data_registro"]);
                        _Usuario.Tipo = Convert.ToInt32(dr["tipo"]);

                    }
                }
                dr.Close();
                return _Usuario;
            }
        }

        public static bool AtualizarUsuario(UsuarioModel _Usuario)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE " +
                                  "usuarios " +
                                  "SET " +
                                  //"id_cliente = @id_cliente," +
                                  //"cpf = @cpf," +
                                  "nome = @nome" +
                                  //"senha = @senha," +
                                  //"ativo = @ativo," +
                                  //"data_registro = @data_registro," +
                                  //"tipo = @tipo " +
                                  " WHERE " +
                                  " email = @email;";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = _Usuario.Email;
                //cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = _Usuario.ClienteID;
                //cmd.Parameters.Add("@cpf", SqlDbType.VarChar).Value = _Usuario.Cpf;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = _Usuario.Nome;
                //cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = _Usuario.Senha;
                //cmd.Parameters.Add("@ativo", SqlDbType.Bit).Value = _Usuario.Ativo;
                //cmd.Parameters.Add("@data_registro", SqlDbType.DateTime).Value = _Usuario.DataRegistro;
                //cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = _Usuario.Tipo;



                try
                {
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    //throw;
                    return false;
                }
            }
        }

        public static bool DeletarUsuario(UsuarioModel _Usuario)
        {
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "DELETE FROM usuarios WHERE email = @email";
                cmd.CommandText = "UPDATE usuarios SET Ativo = @ativo WHERE email = @email";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = _Usuario.Email;
                cmd.Parameters.Add("@ativo", SqlDbType.Bit).Value = _Usuario.Ativo;
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }
        public static List<UsuarioModel> TodosUsuarios(int ClienteID)
        {
            List<UsuarioModel> listaSaida = new List<UsuarioModel>();
            using (SqlConnection cnn = Conexoes.ConexaoSQL())
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT " +
                                 "u.email," +
                                 "u.id_cliente," +
                                 "u.cpf," +
                                 "u.nome," +
                                 "u.senha," +
                                 "u.ativo," +
                                 "u.data_registro," +
                                 "u.tipo " +
                                 "FROM " +
                                 "usuarios u " +
                                 "WHERE " +
                                 "u.id_cliente = @id_cliente";
                cmd.Parameters.Add("@id_cliente", SqlDbType.VarChar).Value = ClienteID;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuarioModel _Usuario = new UsuarioModel();
                        _Usuario.Email = dr["email"].ToString();
                        _Usuario.ClienteID = Convert.ToInt32(dr["id_cliente"]);
                        _Usuario.Cpf = dr["cpf"].ToString();
                        _Usuario.Nome = dr["nome"].ToString();
                        _Usuario.Senha = dr["senha"].ToString();
                        _Usuario.Ativo = Convert.ToBoolean(dr["ativo"]);
                        _Usuario.DataRegistro = Convert.ToDateTime(dr["data_registro"]);
                        _Usuario.Tipo = Convert.ToInt32(dr["tipo"]);
                        listaSaida.Add(_Usuario);
                    }
                }
                return listaSaida;
            }
        }
    }
}
