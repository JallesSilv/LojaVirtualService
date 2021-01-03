using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("FileToUpload")]
    public partial class FileToUpload
    {
        //public FileToUpload()
        //{
        //    CaixaMovimentacao = new List<CaixaMovimentacao>();
        //}

        [Key]
        public Int64 ChaveFile { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string FileAsBase64 { get; set; }
        //public virtual ICollection<CaixaMovimentacao> CaixaMovimentacao { get; set; }
    }
}