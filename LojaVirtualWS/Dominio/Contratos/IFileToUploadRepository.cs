using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos
{
    public interface IFileToUploadRepository : IBaseRepository<FileToUpload>
    {
        void AdicionarFile(FileToUpload teste);
    }
}
