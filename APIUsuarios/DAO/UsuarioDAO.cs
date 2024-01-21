using ApiUsuarios.DTO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ApiUsuarios.DAO
{
    public class UsuarioDAO
    {
        public List<UsuarioDTO> ListarUsuarios()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM Usuarios";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var usuarios = new List<UsuarioDTO>();

            while (dataReader.Read())
            {
                var usuario = new UsuarioDTO();
                usuario.ID = int.Parse(dataReader["ID"].ToString());
                usuario.Nome = dataReader["Nome"].ToString();
                usuario.Email = dataReader["Email"].ToString();
                usuario.Telefone = dataReader["Telefone"].ToString();

                usuarios.Add(usuario);
            }
            conexao.Close();

            return usuarios;
        }

        public void CadastrarUsuario(UsuarioDTO usuario)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "INSERT INTO Usuarios (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone);";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            comando.Parameters.AddWithValue("@Email", usuario.Email);
            comando.Parameters.AddWithValue("@Telefone", usuario.Telefone);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void AlterarUsuario(UsuarioDTO usuario)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"UPDATE Usuarios SET Nome = @Nome, Email = @Email, Telefone = @Telefone WHERE ID = @ID);";

            var comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@ID", usuario.ID);
            comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            comando.Parameters.AddWithValue("@Email", usuario.Email);
            comando.Parameters.AddWithValue("@Telefone", usuario.Telefone);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void RemoverUsuario(UsuarioDTO usuario)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"DELETE FROM Usuarios WHERE ID = @ID;";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@ID", usuario.ID);

            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<UsuarioDTO> ListarUsuariosPorId(int id)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"SELECT*FROM Usuarios WHERE ID = @ID";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@ID",id);
            var dataReader = comando.ExecuteReader();

            var usuarios = new List<UsuarioDTO>();
            var usuario = new UsuarioDTO();

            while (dataReader.Read())
            {
                
                usuario.ID = int.Parse(dataReader["ID"].ToString());
                usuario.Nome = dataReader["Nome"].ToString();
                usuario.Email = dataReader["Email"].ToString();
                usuario.Telefone = dataReader["Telefone"].ToString();

                usuarios.Add(usuario);
            }
            conexao.Close();

            return usuarios;
        }


        public void RemoverUsuario(int id)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"delete from usuarios where ID = @ID";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
