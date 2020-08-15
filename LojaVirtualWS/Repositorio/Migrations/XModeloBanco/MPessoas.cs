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
    public class MPessoas : XMigration
    {
        public MPessoas(LojaVirtualDbContext contexto) : base(contexto) { }

        public override void Executar()
        {
            CriarTabelaSql();
        }

        public void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("pessoas", "ChavePessoa"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `pessoas` (
                                              `ChavePessoa` int NOT NULL AUTO_INCREMENT,
                                              `Nome` varchar(100) DEFAULT NULL,
                                              `Email` varchar(100) DEFAULT NULL,
                                              `Senha` varchar(100) DEFAULT NULL,
                                              `CpnjCpf` varchar(14) DEFAULT NULL,
                                              `Telefone` varchar(20) DEFAULT NULL,
                                              `DataCadastro` datetime NOT NULL,
                                              `Endereco` varchar(500) DEFAULT NULL,
                                              `Observacoes` varchar(1000) DEFAULT NULL,
                                              `Ativo` bit(1) NOT NULL,
                                            PRIMARY KEY (`ChavePessoa`))";
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Pessoas: {error.Message}");
                    }
                }
            }
            var M02 = _contexto.Versao_Migration.FirstOrDefault(px => px.Versao == 2);
            if (M02 is null)
            {
                try
                {
                    _contexto.Versao_Migration.Add(new Versao_Migration { Data = DateTime.Now, Versao = 2 });
                    _contexto.SaveChanges();
                }
                catch (Exception eX)
                {
                    throw new Exception($"Error 'Migration Pessoas': {eX.Message}");
                }
            }
        }
    }
}
