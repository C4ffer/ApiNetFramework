using AulaSavino_RestAPINETFRamework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AulaSavino_RestAPINETFRamework.Controllers
{
    [RoutePrefix("api/usuario")]
    public class VagasController : ApiController
    {
        private static List<VagasModel> listaVagas = new List<VagasModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarVaga")]
        public string CadastrarVaga(VagasModel vaga)
        {
            listaVagas.Add(vaga);
            return "Vaga cadastrada com sucesso!";
        }


        [AcceptVerbs("PUT")]
        [Route("AlterarVaga")]
        public string AlterarVaga(VagasModel vagas)
        {
            listaVagas.Where(n => n.CodigoVaga ==
            vagas.CodigoVaga)
            .Select(s =>
            {
                s.CodigoVaga = vagas.CodigoVaga;
                s.Empresa = vagas.Empresa;
                s.Nome = vagas.Nome;
                s.Descricao = vagas.Descricao;
                s.Requisitos = vagas.Requisitos;
                s.Requisitos = vagas.Requisitos;

                return s;
            }).ToList();
            return "Vaga alterada com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirVaga/{codigo}")]
        public string ExcluirVaga(int codigo)
        {
            VagasModel vaga = listaVagas.Where(n => n.CodigoVaga == codigo)
            .Select(n => n)
            .First();
            listaVagas.Remove(vaga);
            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ListarVagaPorCodigo/{codigo}")]
        public VagasModel ConsultarVagaPorCodigo(int codigo)
        {
            VagasModel vaga = listaVagas.Where(n => n.CodigoVaga == codigo)
            .Select(n => n)
            .FirstOrDefault();
            return vaga;
        }

        [AcceptVerbs("GET")]
        [Route("ListarVagas")]
        public List<VagasModel> ConsultarVagas()
        {
            CarregarVagas();
            return listaVagas;
        }
        private void CarregarVagas()
        {
            listaVagas.Clear();
            listaVagas.Add(new VagasModel(1, "Google", "vaga 1", "Trabalhar", "Ensino Médio Completo", "Salário"));
            listaVagas.Add(new VagasModel(2, "Microsoft", "vaga 2", "Trabalhar", "Ensino Médio Completo", "Salário"));
        }
    }
}