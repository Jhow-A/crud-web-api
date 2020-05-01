using CrudWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebApi.DAL
{
    public class TipoProdutoDAO
    {
        // Lista criada para armezenar uma lista de ipo de produto simulando o banco de dados
        private static Dictionary<long, TipoProduto> bancoTipoProduto = new Dictionary<long, TipoProduto>();
        private static int contadorBanco = 2;

        // Construtor estático serve para criar objetos do TipoProduto e Produto simulando o banco de dados
        static TipoProdutoDAO()
        {

            TipoProduto energiaSolar = new TipoProduto();
            energiaSolar.IdTipo = 1;
            energiaSolar.DescricaoTipo = "Energia Solar";
            energiaSolar.Comercializado = true;

            Produto FotoVoltatica = new Produto();
            FotoVoltatica.IdProduto = 800;
            FotoVoltatica.NomeProduto = "Energia Solar Fotovoltatica";
            FotoVoltatica.Caracteristicas = @"A tecnologia fotovoltaica (FV) 
                                            converte diretamente os raios 
                                            solares em eletricidade";
            FotoVoltatica.PrecoMedio = 4000.00;
            FotoVoltatica.Logotipo = @"data:image/jpeg;base64";
            FotoVoltatica.Ativo = true;
            FotoVoltatica.IdTipoProduto = energiaSolar.IdTipo = 1;

            //Referência do Novo Produto 
            energiaSolar.Adiciona(FotoVoltatica);

            TipoProduto tinta = new TipoProduto();
            tinta.IdTipo = 2;
            tinta.DescricaoTipo = "Tinta";
            tinta.Comercializado = true;

            //Inserer Registro no Banco
            bancoTipoProduto.Add(1, energiaSolar);
            bancoTipoProduto.Add(2, tinta);
        }

        public void Inserir(TipoProduto tipoProduto)
        {
            contadorBanco++;
            tipoProduto.IdTipo = contadorBanco;
            bancoTipoProduto.Add(contadorBanco, tipoProduto);
        }

        public TipoProduto Consultar(int idTipo)
        {
            return bancoTipoProduto[idTipo];
        }

        public IList<TipoProduto> Listar()
        {
            return new List<TipoProduto>(bancoTipoProduto.Values);
        }

        public void Excluir(int idTipo)
        {
            bancoTipoProduto.Remove(idTipo);
        }

        public void Alterar(TipoProduto tipoProduto)
        {
            bancoTipoProduto[tipoProduto.IdTipo] = tipoProduto;
        }
    }
}