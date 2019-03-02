using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movimentacao.Domain.Entities;
using Movimentacao.UI.ViewModel;

namespace Movimentacao.UI.Controllers
{
    public class MovimentoManualController : Controller
    {
        MovimentacaoManualViewModel movimentacaomanualVM;

        // GET: MovimentoManual
        public ActionResult Index()
        {
            return NewMethod();
        }

        private ActionResult NewMethod()
        {
            //Todo Refatorar
            movimentacaomanualVM = new MovimentacaoManualViewModel();

            using (var api = new HttpClient())
            {
                api.BaseAddress = new Uri("https://localhost:44332/api/");

                var res = api.GetAsync("produto");
                res.Wait();

                var retorno = res.Result;

                if (retorno.IsSuccessStatusCode)
                {
                    var readTask = retorno.Content.ReadAsAsync<List<Produto>>();                   
                    movimentacaomanualVM.LsProduto = readTask.Result.Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();
                }

                res = api.GetAsync("Cosif");
                res.Wait();

                retorno = res.Result;

                if (retorno.IsSuccessStatusCode)
                {
                    var readTask = retorno.Content.ReadAsAsync<List<Cosif>>();                  
                    movimentacaomanualVM.ListaCosif = readTask.Result.Select(c => new SelectListItem() { Text = c.CodigoClassificacao, Value = c.Id.ToString() }).ToList();
                }


                res = api.GetAsync("Movimento");
                res.Wait();

                retorno = res.Result;

                if (retorno.IsSuccessStatusCode)
                {
                    var readapi = retorno.Content.ReadAsAsync<List<Movimento>>().Result;

                    var listamovimentacao = new List<MovimentacaoProduto>();
                    foreach (var item in readapi)
                    {
                        var movimentacao = new MovimentacaoProduto
                        {
                            Ano = item.DataAno,
                            CodigoProduto = item.CodigoProduto,
                            Descricao = item.DescricaoLancamento,
                            Mes = item.DataMes,
                            Valor = item.ValorMovimento
                        };
                        movimentacaomanualVM.ListaMovimentacaoProduto.Add(movimentacao);
                    }               
                    
                }
            }

            return View(movimentacaomanualVM);
        }


        // GET: MovimentoManual/Create
        public ActionResult Create()
        {
            return NewMethod();
        }

        // POST: MovimentoManual/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovimentacaoManualViewModel movimentacaoManualView)
        {
            try
            {
                var movimento = new Movimento
                {
                    CodigoCosif = movimentacaoManualView.CodigoCosif.ToString(),
                    CodigoProduto = movimentacaoManualView.CodigoProduto.ToString(),
                    CodigoUsuario = "Teste",
                    DataAno = movimentacaoManualView.Ano,
                    DataMes = movimentacaoManualView.Mes,
                    ValorMovimento = movimentacaoManualView.Valor,
                    DataMovimentacaq = DateTime.Now,
                    DescricaoLancamento = movimentacaoManualView.Descricao

                };

                // TODO: Add insert logic here
                using (var api = new HttpClient())
                {
                    api.BaseAddress = new Uri("https://localhost:44332/api/Movimento");

                    var post = api.PostAsJsonAsync("movimento", movimento);
                    post.Wait();

                    var retorno = post.Result;

                    if (retorno.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }                

                }

                ModelState.AddModelError(string.Empty, "Erro!");

                return View();

            }
            catch
            {
                return View();
            }
        }

    }
}