using Dominio.Contratos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtualWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowsCors")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepository _contexto;

        public ProdutosController(IProdutosRepository contexto)
        {
            _contexto = contexto;
        }


    }
}
