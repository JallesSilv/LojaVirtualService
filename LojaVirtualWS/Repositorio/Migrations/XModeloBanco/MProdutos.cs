using Dominio.Entidades;
using Repositorio.Config;
using Repositorio.Contexto;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class MProdutos : XMigration
    {
        public MProdutos(LojaVirtualDbContext contexto) : base(contexto) { }

        public override void Executar()
        {
            CriarTabelaSql();
        }
        
        public void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("produtos", "ChaveProduto"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `produtos` (
                                              `ChaveProduto` int NOT NULL AUTO_INCREMENT,
                                              `Nome` varchar(300) DEFAULT NULL,  
                                              `Descricao` varchar(300) DEFAULT NULL,
                                              `Preco` double DEFAULT NULL,
                                            PRIMARY KEY (`ChaveProduto`))";
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Produtos: {error.Message}");
                    }
                }
            }
            var M03 = _contexto.Versao_Migration.FirstOrDefault(px => px.Versao == 3);
            if (M03 is null)
            {
                try
                {
                    _contexto.Versao_Migration.Add(new Versao_Migration { Data = DateTime.Now, Versao = 3 });
                    _contexto.SaveChanges();
                }
                catch (Exception eX)
                {
                    throw new Exception($"Error 'Migration Produtos': {eX.Message}");
                }
            }
        }
    }
}
