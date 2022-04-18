using AulaSavino_RestAPINETFRamework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AulaSavino_RestAPINETFRamework.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController: ApiController
    {
        private static List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarUsuario")]
        public string CadastrarUsuario(UsuarioModel usuario)
        {
            listaUsuarios.Add(usuario);
            return "Usuário cadastrado com sucesso!";
        }


        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public string AlterarUsuario(UsuarioModel usuario)
        {
            listaUsuarios.Where(n => n.CodigoUsuario ==
            usuario.CodigoUsuario)
            .Select(s =>
            {
                s.CodigoUsuario = usuario.CodigoUsuario;
                s.Nome = usuario.Nome;
                s.Senha = usuario.Senha;
                s.Telefone = usuario.Telefone;
                s.Perfil = usuario.Perfil;
                s.Email = usuario.Email;
                s.Usuario = usuario.Usuario;
                return s;
            }).ToList();
            return "Usuário alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{codigo}")]
        public string ExcluirUsuario(int codigo)
        {
            UsuarioModel usuario = listaUsuarios.Where(n => n.CodigoUsuario == codigo)
            .Select(n => n)
            .First();
            listaUsuarios.Remove(usuario);
            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ListarUsuarioPorCodigo/{codigo}")]
        public UsuarioModel ConsultarUsuarioPorCodigo(int codigo)
        {
            UsuarioModel usuario = listaUsuarios.Where(n => n.CodigoUsuario == codigo)
            .Select(n => n)
            .FirstOrDefault();
            return usuario;
        }

        [AcceptVerbs("GET")]
        [Route("ListarUsuarios")]
        public List<UsuarioModel> ConsultarUsuarios()
        {
            CarregarUsuarios();
            return listaUsuarios;
        }
        private void CarregarUsuarios()
        {
            listaUsuarios.Clear();
            listaUsuarios.Add(new UsuarioModel(1, "Pedro", "ped","123","Estudante","(11)97864-5647", "ped@teste.com.br"));
            listaUsuarios.Add(new UsuarioModel(1, "Milena", "mi","123","Estudante","(11)97864-1198", "mi@teste.com.br"));
        }

    }
}