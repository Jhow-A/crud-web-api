using Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Listar();
            //Cadastrar();

            Console.ReadLine();
        }

        static void Cadastrar()
        {
            HttpClient client = new HttpClient();

            TipoProduto tipo = new TipoProduto();
            tipo.IdTipo = 101;
            tipo.DescricaoTipo = "Grid de Energia Solar";
            tipo.Comercializado = true;

            // Convertendo objeto TipoProduto em formato JSON
            var json = JsonConvert.SerializeObject(tipo);

            // Convertendo texto para JSON StringContent. 
            StringContent conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            // Executando POST passando a url da API e o conteúdo do tipo StringContent.
            HttpResponseMessage resposta = client.PostAsync("http://localhost/WebApi/api/TipoProduto", conteudo).Result;

            if (resposta.IsSuccessStatusCode)
            {
                Console.WriteLine("\n\nTipo do produto criado com sucesso: " + json);
                Console.Write("Link para consulta: " + resposta.Headers.Location);
            }
        }

        static void Listar()
        {
            using (var stringContent = new StringContent("{ \"firstName\": \"MaleUser\" }", System.Text.Encoding.UTF8,
            "application/json"))
            using (var client = new HttpClient())
            {
                // HttpClient: classe responsável por criar a conexão com o recurso e executar o método solicitado

                try
                {
                    // Adiciona o header de Authorization na requisição
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        "Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", "MaleUser", "123456"))));

                    //HttpResponseMessage: classe responsável por coletar e deixar o conteúdo da resposta disponível para o uso e manipulação.
                    HttpResponseMessage resposta = client.GetAsync("http://localhost/WebApi/api/TipoProduto").Result;

                    if (resposta.IsSuccessStatusCode)
                    {
                        // Recupera o conteúdo JSON retornado pela API
                        string conteudo = resposta.Content.ReadAsStringAsync().Result;

                        Console.WriteLine("Listando todos os tipos e seus produtos: \n");
                        Console.Write(conteudo.ToString());

                        // Convertendo o conteudo JSON em uma lista de TipoProduto
                        List<TipoProduto> lista = JsonConvert.DeserializeObject<List<TipoProduto>>(conteudo);

                        // Imprime o conteúdo na janela Console
                        foreach (TipoProduto item in lista)
                        {
                            Console.WriteLine("\n\n ========== ");
                            Console.WriteLine("Descrição:" + item.DescricaoTipo);
                            Console.WriteLine("Comercializado:" + item.Comercializado);
                            Console.WriteLine(" ========== ");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
        }
    }
}
