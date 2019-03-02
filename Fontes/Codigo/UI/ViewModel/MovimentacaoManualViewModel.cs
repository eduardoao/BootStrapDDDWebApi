using Microsoft.AspNetCore.Mvc.Rendering;
using Movimentacao.Domain.Entities;
using System.Collections.Generic;

namespace Movimentacao.UI.ViewModel
{
    public class MovimentacaoManualViewModel
    {
        public MovimentacaoManualViewModel()
        {
            if (ListaProduto == null) ListaProduto = new List<Produto>();
            //if (ListaCosif == null) ListaCosif = new List<Cosif>();
            if (ListaMovimentacaoProduto == null) ListaMovimentacaoProduto = new List<MovimentacaoProduto>();
        }

        public int Mes { get; set; }

        public int Ano { get; set; }

        public int CodigoProduto { get; set; }

        public int CodigoCosif { get; set; }

        public int Valor { get; set; }

        public string Descricao { get; set; }

        public List<Produto> ListaProduto { get; set; }


        public IEnumerable<SelectListItem> LsProduto { get; set; }

        public IEnumerable<SelectListItem> ListaCosif { get; set; }

        public IList<MovimentacaoProduto> ListaMovimentacaoProduto { get; set; }
    }

    public class MovimentacaoProduto
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public string CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int NumeroLancamento { get; set; }
        public string Descricao { get; set; }
        public int Valor { get; set; }
    }
}
