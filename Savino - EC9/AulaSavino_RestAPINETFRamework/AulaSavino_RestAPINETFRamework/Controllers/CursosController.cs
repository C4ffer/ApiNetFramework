using AulaSavino_RestAPINETFRamework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace AulaSavino_RestAPINETFRamework.Controllers
{
    [RoutePrefix("api/curso")]
    public class CursosController : ApiController
    {
        private static List<CursosModel> listaCursos = new List<CursosModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarCurso")]
        public string CadastrarCurso(CursosModel curso)
        {
            listaCursos.Add(curso);
            return JsonConvert.SerializeObject("Curso cadastrado com sucesso!");
        }


        [AcceptVerbs("PUT")]
        [Route("AlterarCurso")]
        public string AlterarCurso(CursosModel curso)
        {
            listaCursos.Where(n => n.CodigoCurso ==
            curso.CodigoCurso)
            .Select(s =>
            {
                s.CodigoCurso = curso.CodigoCurso;
                s.Nome = curso.Nome;
                s.Descricao = curso.Descricao;
                s.EmpresaFornecedora = curso.EmpresaFornecedora;
                return s;

            }).ToList();
            return JsonConvert.SerializeObject("Curso alterado com sucesso!");
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirCurso/{codigo}")]
        public string ExcluirCurso(int codigo)
        {
            try
            {
                CursosModel curso = listaCursos.Where(n => n.CodigoCurso == codigo)
                .Select(n => n)
                .First();
                listaCursos.Remove(curso);
                return JsonConvert.SerializeObject("Registro excluido com sucesso!");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject($"Codigo de curso inexistente ou inválido! \nErro: {ex}");
            }

        }

        [AcceptVerbs("GET")]
        [Route("ListarCursoPorCodigo/{codigo}")]
        public string ConsultarCursoPorCodigo(int codigo)
        {
            CursosModel curso = listaCursos.Where(n => n.CodigoCurso == codigo)
            .Select(n => n)
            .FirstOrDefault();
            return JsonConvert.SerializeObject(curso);
        }

        [AcceptVerbs("GET")]
        [Route("ListarCursos")]
        public string ConsultarCursos()
        {
            CarregarCursos();
            return JsonConvert.SerializeObject(listaCursos);
        }
        private void CarregarCursos()
        {
            if (!listaCursos.Any())
            {
                listaCursos.Clear();
                listaCursos.Add(new CursosModel(1, "Java", "Curso de Java POO", "Microsoft"));
                listaCursos.Add(new CursosModel(2, "Python", "Curso de Python", "Google"));
            }
        }
    }
}