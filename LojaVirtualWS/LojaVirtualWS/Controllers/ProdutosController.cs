using Dominio.Contratos;
using Dominio.Entidades;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LojaVirtualWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowsCors")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepository _contexto;
        private IHttpContextAccessor _httpContextAccessor;
        private IWebHostEnvironment _hostEnvironment;

        public ProdutosController(IProdutosRepository contexto,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostingEnvironment)
        {
            _contexto = contexto;
            _httpContextAccessor = httpContextAccessor;
            _hostEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pToken"></param>
        /// <returns></returns>
        /// <response code="200">Retorno Ok</response>
        /// <response code="404">Item Null</response>  
        [EnableCors("AlowsCors")]
        //[ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Get")]
        public ActionResult Get()
        {
            try
            {
                return Ok(_contexto.ObterTodos());
            }
            catch (Exception error)
            {
                return BadRequest($@"Erro: {error.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="produto"></param>
        /// <returns></returns>
        [EnableCors("AlowsCors")]
        //[ApiVersion("1.0")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody]Produtos produto)
        {
            try
            {
                _contexto.Adicionar(produto);
                return Created("api/produtos", produto);
            }
            catch (Exception ex)
            {   
                return BadRequest($"Erro: {ex.ToString()}");
            }
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
        public IActionResult EnviarArquivo()
        {
            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                var nomeArquivo = formFile.FileName;
                var extensao = nomeArquivo.Split(".").Last();
                string novoNomeArquivo = GerarNovoNomeAruivo(nomeArquivo, extensao);
                //var pastaArquivos = _hostEnvironment.WebRootFileProvider + "\\arquivos\\";
                var pastaArquivos = "D:\\ExcluirImagem\\";
                var nomeCompleto = pastaArquivos + novoNomeArquivo;

                using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);
                }

                return Ok(novoNomeArquivo);
            }
            catch (Exception eX)
            {
                return BadRequest(eX.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="produto"></param>
        /// <returns></returns>
        [EnableCors("AlowsCors")]
        //[ApiVersion("1.0")]
        [HttpPost("ConverteImagem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ConverteImagem()
        {
            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];                
                var nomeArquivo = BityImagem(formFile.FileName);

                var t = nomeArquivo;

                //var extensao = nomeArquivo.Split(".").Last();
                //string novoNomeArquivo = GerarNovoNomeAruivo(nomeArquivo, extensao);
                ////var pastaArquivos = _hostEnvironment.WebRootFileProvider + "\\arquivos\\";
                //var pastaArquivos = "D:\\ExcluirImagem\\";
                //var nomeCompleto = pastaArquivos + novoNomeArquivo;

                //using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                //{
                //    formFile.CopyTo(streamArquivo);
                //}

                return Ok(nomeArquivo);
            }
            catch (Exception eX)
            {
                return BadRequest(eX.Message);
            }
        }

        private object BityImagem(string fileName)
        {
            try
            {
                var teste = Convert.ToByte(fileName);
                return teste;

            }
            catch (Exception eX)
            {

                throw new Exception(eX.Message);
            }
        }
        //private byte BityImagem(byte nomeImagem)
        //{
        //    var imagem = Convert.ToByte(nomeImagem);
        //    return imagem;
        //}

        private static string GerarNovoNomeAruivo(string nomeArquivo, string extensao)
        {
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
            var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ","-");
            nomeArquivo = $"{novoNomeArquivo}_{DateTime.Now.ToString("yyyyMMddHHmm")}.{extensao}";
            return nomeArquivo;
        }
    }
}
