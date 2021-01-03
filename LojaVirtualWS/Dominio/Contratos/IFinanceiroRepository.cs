using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Dominio.Contratos
{
    public interface IFinanceiroRepository: IBaseRepository<CaixaMovimentacao>
    {

        List<CaixaMovimentacao> ObterTodosPelaData(DateTime? pDataInicio, DateTime? pDataFim);
    }
}
