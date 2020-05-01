using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebApi.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public String NomeProduto { get; set; }
        public String Caracteristicas { get; set; }
        public double PrecoMedio { get; set; }
        public String Logotipo { get; set; }
        public bool Ativo { get; set; }
        public int IdTipoProduto { get; set; }

        public Produto() { }

        public Produto(int IdProduto, string NomeProduto, string Caracteristicas, double PrecoMedio, string Logotipo, bool Ativo, int IdTipoProduto)
        {
            this.IdProduto = IdProduto;
            this.NomeProduto = NomeProduto;
            this.Caracteristicas = Caracteristicas;
            this.PrecoMedio = PrecoMedio;
            this.Logotipo = Logotipo;
            this.Ativo = Ativo;
            this.IdTipoProduto = IdTipoProduto;
        }
    }
}