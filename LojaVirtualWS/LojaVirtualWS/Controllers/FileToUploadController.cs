using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Contratos;
using Dominio.Entidades;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtualWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowsCors")]
    public class FileToUploadController : ControllerBase
    {

        private readonly IFileToUploadRepository _contexto;

        public FileToUploadController(IFileToUploadRepository contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="produto"></param>
        /// <returns></returns>
        [EnableCors("AlowsCors")]
        //[ApiVersion("1.0")]
        [HttpPost("EnviarArquivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Upload( FileToUpload theFile)
        {

            try
            {               
                _contexto.AdicionarFile(theFile);
                return Created("api/FileToUpload", theFile);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.ToString()}");
            }
        }
    }
}
