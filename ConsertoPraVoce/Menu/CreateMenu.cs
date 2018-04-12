using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsertoPraVoce.Menu
{
	public class CreateMenu
	{
		public List<Menu> MontarMenu()
		{
			var menu = new List<Menu>();

			menu.Add(CriarMenu("Index", "Fornecedor", "Fornecedores", "fa fa-handshake-o"));
			menu.Add(CriarMenu("Index", "Cliente", "Clientes", "fa fa-users"));
			menu.Add(CriarMenu("Index", "Conta", "Contas", "fa fa-bank"));

			//Serviços
			var srv = CriarMenu("", "", "Serviços", "fa fa-wrench", "has-sub");
			srv.SubMenu.Add(CriarMenu("Index", "OrdemServico", "Ordens de Serviço", ""));
			srv.SubMenu.Add(CriarMenu("Index", "PrecoServico", "Preços de Serviço", ""));
			srv.SubMenu.Add(CriarMenu("Index", "Servico", "Serviços", ""));
			menu.Add(srv);

			//Estoque
			var est = CriarMenu("", "", "Estoque", "fa fa-filter", "has-sub");
			est.SubMenu.Add(CriarMenu("index", "EstoqueProduto", "Estoque", ""));
			est.SubMenu.Add(CriarMenu("index", "HistoricoEstoque", "Histórico Estoque", ""));
			menu.Add(est);

			//Produtos
			var prd = CriarMenu("", "", "Produtos", "fa fa-table", "has-sub");
			prd.SubMenu.Add(CriarMenu("Index", "Marca", "Marcas", ""));
			prd.SubMenu.Add(CriarMenu("Index", "TipoAparelho", "Tipos", ""));
			prd.SubMenu.Add(CriarMenu("Index", "ModeloAparelho", "Produtos", ""));
			prd.SubMenu.Add(CriarMenu("Index", "TipoProduto", "Categorias", ""));
			prd.SubMenu.Add(CriarMenu("Index", "Cor", "Cores", ""));
			prd.SubMenu.Add(CriarMenu("Index", "Produto", "Produto Estoque", ""));
			menu.Add(prd);

			////Aparelhos
			//var apa = CriarMenu("", "", "Aparelhos", "fa fa-mobile", "has-sub");

			//menu.Add(apa);

			var tra = CriarMenu("", "", "Transações", "fa fa-retweet", "has-sub");
			tra.SubMenu.Add(CriarMenu("Index", "Transacao", "Transações", ""));
			tra.SubMenu.Add(CriarMenu("Index", "CategoriaTransacao", "Categorias", ""));
			tra.SubMenu.Add(CriarMenu("Index", "MetodoPagamento", "Metodo Pagamento", ""));
			menu.Add(tra);

			var ord = CriarMenu("", "", "Ordens de", "fa fa-retweet", "has-sub");
			ord.SubMenu.Add(CriarMenu("Index", "OrdemCompra", "Ordem de Compra", "fa fa-user"));
			menu.Add(ord);

			menu.Add(CriarMenu("Index", "Usuario", "Usuários", "fa fa-user"));

			return menu;
		}

		private Menu CriarMenu(string action, string controller, string nome, string icone, string classe = null)
		{
			var m = new Menu();
			m.Nome = nome;
			m.Classe = classe;
			m.Icone = icone;
			m.ActionName = action;
			m.ControllerName = controller;
			return m;
		}
	}
}