using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Repositorio.Config;
using Repositorio.Contexto;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class CriarVersaoMigretions : XMigration
    {

        public CriarVersaoMigretions(LojaVirtualDbContext _contexto) : base(_contexto)
        {
            
        }
        public override void Executar()
        {
            CriarTabelaSql();
        }

        public void CriarTabelaSql()
        {


            if (!ExisteColunaNaTabela("versao_migration", "ChaveVersao"))
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
                        throw new Exception($"Não foi possível realizar a criação da coluna . Erro {error.Message}");
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

        //protected override void Up([NotNullAttribute] MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.CreateTable(
        //        name: "VERSAO_MIGRATION",
        //        columns: table => new
        //        {
        //            CHAVE_VERSAO = table.Column<int>(nullable: false),
        //            DATA = table.Column<DateTime>(nullable: false),
        //            VERSAO = table.Column<int>(nullable: false)
        //        }
        //    );
        //}

        private bool ExisteColunaNaTabela(string pTable, string pColumn)
        {
            int resultado = 0;
            using (var cmd = FactoryConnection.NewCommand())
            {
                var strQuery = $@"SELECT Count(*)
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME = '{pTable}'
                                    AND COLUMN_NAME = '{pColumn}'";
                try
                {
                    cmd.CommandText = strQuery;
                    resultado = cmd.ExecuteScalar().AsInt32();
                }
                catch (Exception error)
                {
                    throw new Exception($"Erro ao validar existencia da coluna: \n{pColumn} da tabela {pTable}\n{error.Message}");
                }
                finally
                {
                    cmd.Prepare();
                }
            }


            return resultado > 0;

        }
    }

}
