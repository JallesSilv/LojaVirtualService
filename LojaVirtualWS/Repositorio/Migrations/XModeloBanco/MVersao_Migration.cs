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
    public class MVersao_Migration
    {

        public static void Versao_Migration()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Versao_Migration", "ChaveVersao"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `Versao_Migration`(
                                                `ChaveVersao` BIGINT NOT NULL AUTO_INCREMENT,
                                                `Data` datetime NOT NULL,
                                                `Versao` BIGINT NOT NULL, 
                                            PRIMARY KEY(ChaveVersao))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela Versao_Migration.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error criação da Tabela Versao_Migration: {error.Message}");
                    }
                }
            }
            if (!VerificarExisteTabela.ExisteRegistro("Versao_Migration", "versao", "1"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"INSERT INTO VERSAO_MIGRATION (DATA, VERSAO) VALUES(NOW(),'1')";
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception eX)
                    {

                        throw new Exception($"Error preencher versão Versao_Migration: {eX.Message}");
                    }
                }
            }
            //var M01 = _contexto.Versao_Migration.FirstOrDefault(px => px.Versao == 1);
            //if (M01 is null)
            //{
            //    try
            //    {
            //        _contexto.Versao_Migration.Add(new Versao_Migration { Data = DateTime.Now, Versao = 1 });
            //        _contexto.SaveChanges();
            //    }
            //    catch (Exception eX)
            //    {
            //        throw new Exception($"Error 'Versao_Migration': {eX.Message}");
            //    }
            //}
        }
    }
}
