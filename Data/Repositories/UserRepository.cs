using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(Usuario userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [USUARIO] where Documento=@username and [Clave]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(Usuario userModel)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Usuario> GetByAll()
        {
            throw new NotImplementedException();
        }
        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Usuario GetByUsername(string username)
        {
            Usuario user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select u.IdUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdRol,r.Descripcion from usuario u inner join rol r on r.IdRol = u.IdRol where u.Documento=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(reader[0]),
                            Documento = reader[1].ToString(),
                            NombreCompleto = reader[2].ToString(),
                            Correo = reader[3].ToString(),
                            Clave = reader[4].ToString(),
                            Estado = Convert.ToBoolean(reader[5]),
                            oRol = new Rol() { IdRol = Convert.ToInt32(reader[6]), Descripcion = reader[7].ToString()}
                        };
                    }
                }
            }
            return user;
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
