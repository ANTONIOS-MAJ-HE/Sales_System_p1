using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CD_Permiso : RepositoryBase
    {

        public List<Permiso> Listar(int idusuario)
        {
            List<Permiso> permiso = new List<Permiso>();
            using (var connection  = GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select p.IdRol,p.NombreMenu from PERMISO p inner join ROL r on r.IdRol = p.IdRol inner join USUARIO u on u.IdRol = r.IdRol where u.IdUsuario = @idusuario";
                command.Parameters.Add("@idusuario", SqlDbType.Int).Value = idusuario;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        permiso.Add(new Permiso()
                        {
                            oRol = new Rol() { IdRol = Convert.ToInt32(reader["IdRol"]) },
                            NombreMenu = reader["NombreMenu"].ToString(),
                        });
                        

                    }
                }
            }          

            return permiso;

        }

    }
}
