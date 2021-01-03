using System;
using System.Collections.Generic;
using System.IO;
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
    public class PessoasController : ControllerBase
    {
        private readonly IPessoasRepository _contexto;

        public PessoasController(IPessoasRepository contexto)
        {
            _contexto = contexto;
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
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            try
            {
                var teste =_contexto.GetAllPessoas();
                return Ok(teste);
                //if (listaPessoas == null)
                //{
                //    return NotFound($@"Erro ao carregar: {listaPessoas} ");
                //}
                //return Ok(listaPessoas.ToList());
            }
            catch (Exception error)
            {

                return BadRequest($@"Erro: {error.ToString()} ");
            }
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
        [HttpGet("GetId")]
        public ActionResult GetChave(int pChave)
        {
            try
            {
                return Ok(_contexto.ObterChave(pChave));
                //if (listaPessoas == null)
                //{
                //    return NotFound($@"Erro ao carregar: {listaPessoas} ");
                //}
                //return Ok(listaPessoas.ToList());
            }
            catch (Exception error)
            {

                return BadRequest($@"Erro: {error.ToString()} ");
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [EnableCors("AlowsCors")]
        //[ApiVersion("1.0")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post ([FromBody]Pessoas pessoa)
        {
            try
            {
                var usuarioAtivo = _contexto.VerificarUsuario(pessoa.Email);
                if (usuarioAtivo != null)
                {
                    return BadRequest("Usuário já cadastrado!!");
                }
                else
                {
                    _contexto.Adicionar(pessoa);
                    return Created("api/pessoas", pessoa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [EnableCors("AlowsCors")]
        //[ApiVersion("1.0")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put([FromBody] Pessoas pessoa)
        {
            try
            {
                var usuarioAtivo = _contexto.ObterChave(pessoa.ChavePessoa);
                if (usuarioAtivo != null)
                {
                    _contexto.Atualizar(pessoa);
                    return BadRequest("Usuário atualizado com sucesso!!");
                }
                else
                {
                    return BadRequest("Usuário não cadastrado!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <returns></returns>
        /// <returns></returns>
        /// <response code="200">Retorno Ok</response>
        /// <response code="404">Item Null</response>  
        //[ApiVersion("1.0")]
        [EnableCors("AlowsCors")]
        //[ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("VerificarLogin")]
        public IActionResult VerificarLogin([FromBody] Pessoas plogin)
        {
            try
            {
                var pessoaRetorno = _contexto.Login(plogin.Email, plogin.Senha);

                //if (plogin.Email == "jalles" && plogin.Senha == "123")
                //    return Ok(plogin);

                if (pessoaRetorno != null)
                    return Ok(pessoaRetorno);

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.ToString()}");
            }
            return BadRequest("Usuário ou senha inválido");

        }
    }
}