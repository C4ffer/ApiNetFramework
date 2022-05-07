using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AulaSavino_ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuCliente();
        }

        public static void ListarUsuariosMockados()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44390/");
            client.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpResponseMessage response =
            client.GetAsync("api/usuario/ListarUsuarios").Result;
            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {//pegando o cabeçalho
                Uri usuarioUri = response.Headers.Location;
                //Pegando os dados do Rest e armazenando na variável usuários
                var usuarios = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(usuarios.ToString());
            }
            else
            {
                Console.WriteLine("Erro de comunicação!!!");
            }
            System.Console.ReadLine();
        }

        public static void MenuCliente()
        {
            Console.WriteLine("----------------Escolha oque deseja fazer----------------------");
            Console.WriteLine("1 - Cadastrar");
            var resposta = Console.ReadLine();

            switch (resposta)
            {
                case "1":

                    break;
            }

        }
    }
}
