using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaSavino_RestAPINETFRamework.Models
{
    public class CursosModel
    {
        private int codigoCurso;
        private string nome;
        private string descricao;
        private string empresaFornecedora;

		public CursosModel(int codigoCurso, string nome, string descricao, string empresaFornecedora)
		{
			this.codigoCurso = codigoCurso;
			this.nome = nome;
			this.descricao = descricao;
			this.empresaFornecedora = empresaFornecedora;
		}

		public int CodigoCurso { get => codigoCurso; set => codigoCurso = value; }
		public string Nome { get => nome; set => nome = value; }
		public string Descricao { get => descricao; set => descricao = value; }
		public string EmpresaFornecedora { get => empresaFornecedora; set => empresaFornecedora = value; }
	}



}