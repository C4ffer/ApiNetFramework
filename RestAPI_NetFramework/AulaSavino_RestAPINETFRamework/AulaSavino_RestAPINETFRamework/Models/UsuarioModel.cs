using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaSavino_RestAPINETFRamework.Models
{
    public class UsuarioModel
    {
        private int codigoUsuario;
        private string nome;
        private string usuario;
        private string senha;
        private string perfil;
        private string telefone;
        private string email;

        public UsuarioModel(int codigoUsuario, string Nome, string usuario, string Senha, string Perfil, string Telefone, string Email)
        {
            this.codigoUsuario = codigoUsuario;
            this.nome = Nome;
            this.senha = Senha;
            this.usuario = usuario;
            this.perfil = Perfil;
            this.telefone = Telefone;
            this.email = Email;
        }

        public int CodigoUsuario { get => codigoUsuario; set => codigoUsuario = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Perfil { get => perfil; set => perfil = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
    }
}