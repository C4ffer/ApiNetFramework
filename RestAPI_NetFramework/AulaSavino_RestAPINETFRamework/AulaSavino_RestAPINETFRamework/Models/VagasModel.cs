using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaSavino_RestAPINETFRamework.Models
{
    public class VagasModel
    {
        private int codigoVaga;
        private string empresa;
        private string nome;
        private string descricao;
        private string requisitos;
        private string beneficios;

		public VagasModel(int codigoVaga, string empresa, string nome, string descricao, string requisitos, string beneficios)
		{
			this.codigoVaga = codigoVaga;
			this.empresa = empresa;
			this.nome = nome;
			this.descricao = descricao;
			this.requisitos = requisitos;
			this.beneficios = beneficios;
		}

		public int CodigoVaga { get => codigoVaga; set => codigoVaga = value; }
		public string Empresa { get => empresa; set => empresa = value; }
		public string Nome { get => nome; set => nome = value; }
		public string Descricao { get => descricao; set => descricao = value; }
		public string Requisitos { get => requisitos; set => requisitos = value; }
		public string Beneficios { get => beneficios; set => beneficios = value; }
	}
}