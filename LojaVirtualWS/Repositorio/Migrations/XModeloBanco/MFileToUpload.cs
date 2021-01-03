using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class MFileToUpload
    {
        public static void FileToUpload()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("FileToUpload", "ChaveFile"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `FileToUpload` (
                                            `ChaveFile` BIGINT NOT NULL AUTO_INCREMENT,
                                            `FileName` text(21845) COLLATE utf8_bin DEFAULT NULL,
                                            `FileSize` text(21845) COLLATE utf8_bin DEFAULT NULL,
                                            `FileType` text(21845) COLLATE utf8_bin DEFAULT NULL,
                                            `FileAsBase64` text(21845) COLLATE utf8_bin DEFAULT NULL,
                                            `LastModifiedDate` datetime NULL,
                                            PRIMARY KEY (`ChaveFile`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela FileToUpload.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela FileToUpload: {error.Message}");
                    }
                }
            }
        }
    }
}
