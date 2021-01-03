using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Contratos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtualWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowsCors")]
    public class FinanceiroController : ControllerBase
    {
        private readonly IFinanceiroRepository _contexto;

        public FinanceiroController(IFinanceiroRepository contexto)
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
        [HttpGet("Get")]
        public ActionResult Get()
        {
            try
            {
                return Ok(_contexto.ObterTodos());
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
        [HttpGet("CaixaMovimentacao")]
        public ActionResult CaixaMovimentacao(DateTime? pDataInicio, DateTime? pDataFim)
        {
            try
            {
                var lista = _contexto.ObterTodosPelaData(pDataInicio, pDataFim);
                return Ok(lista.ToList());
            }
            catch (Exception error)
            {
                return BadRequest($@"Erro: {error.Message}");
            }
        }
    }
}
