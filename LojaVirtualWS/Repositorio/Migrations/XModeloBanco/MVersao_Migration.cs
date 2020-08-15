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
    public class MVersao_Migration : XMigration
    {
        public MVersao_Migration(LojaVirtualDbContext contexto) : base(contexto) { }

        public override void Executar()
        {
            CriarTabelaSql();
        }

        public void CriarTabelaSql()
        {


            if (!VerificarExisteTabela.ExisteColunaNaTabela("versao_migration", "ChaveVersao"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `versao_migration`(
                                                `ChaveVersao` int NOT NULL AUTO_INCREMENT,
                                                `Data` datetime NOT NULL,
                                                `Versao` int NOT NULL, 
                                            PRIMARY KEY(ChaveVersao))";
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Versao_Migration: {error.Message}");
                    }
                }
            }
            var M01 = _contexto.Versao_Migration.FirstOrDefault(px => px.Versao == 1);
            if (M01 is null)
            {
                try
                {
                    _contexto.Versao_Migration.Add(new Versao_Migration { Data = DateTime.Now, Versao = 1 });
                    _contexto.SaveChanges();
                }
                catch (Exception eX)
                {
                    throw new Exception($"Error 'Versao_Migration': {eX.Message}");
                }
            }
        }
    }
}
