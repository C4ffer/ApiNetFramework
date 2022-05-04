using AulaSavino_RestAPINETFRamework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace AulaSavino_RestAPINETFRamework.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/vagas")]
    public class VagasController : ApiController
    {
        private static List<VagasModel> listaVagas = new List<VagasModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarVaga")]
        public string CadastrarVaga(VagasModel vaga)
        {
            listaVagas.Add(vaga);
            return JsonConvert.SerializeObject("Vaga cadastrada com sucesso!");
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
            return JsonConvert.SerializeObject("Vaga alterada com sucesso!");
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirVaga/{codigo}")]
        public string ExcluirVaga(int codigo)
        {
            try
            {
            VagasModel vaga = listaVagas.Where(n => n.CodigoVaga == codigo)
            .Select(n => n)
            .First();
            listaVagas.Remove(vaga);
            return JsonConvert.SerializeObject("Registro excluido com sucesso!");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject($"Codigo de vaga inexistente ou inválido! \nErro: {ex}");
            }

        }

        [AcceptVerbs("GET")]
        [Route("ListarVagaPorCodigo/{codigo}")]
        public string ConsultarVagaPorCodigo(int codigo)
        {
            VagasModel vaga = listaVagas.Where(n => n.CodigoVaga == codigo)
            .Select(n => n)
            .FirstOrDefault();
            return JsonConvert.SerializeObject(vaga);
        }

        [AcceptVerbs("GET")]
        [Route("ListarVagas")]
        public string ConsultarVagas()
        {
            CarregarVagas();
            return JsonConvert.SerializeObject(listaVagas);
        }
        private void CarregarVagas()
        {
            if (!listaVagas.Any())
            {
                listaVagas.Clear();
                listaVagas.Add(new VagasModel(1, "Google", "vaga 1", "Trabalhar", "Ensino Médio Completo", "Salário"));
                listaVagas.Add(new VagasModel(2, "Microsoft", "vaga 2", "Trabalhar", "Ensino Médio Completo", "Salário"));
            }
        }
    }
}