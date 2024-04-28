using Data.Repositories;
using Model;
using System;
using System.Data;


namespace Presentation
{
    public class CN_Permiso
    {
        private CD_Permiso objcd_permiso = new CD_Permiso();


        public List<Permiso> Listar(int IdUsuario)
        {
            return objcd_permiso.Listar(IdUsuario);
        }

    }
}