using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using ConsertoPraVoce.Menu;

namespace ConsertoPraVoce.Helpers
{
	public static class Helpers
	{
		public static MvcHtmlString GerarMenu(this HtmlHelper htmlHelper)
		{

			var menu = new CreateMenu().MontarMenu();
			var html = new StringBuilder();
			foreach (var item in menu)
			{
				html.AppendLine(GerarHtmlMenu(item, htmlHelper));
			}

			return MvcHtmlString.Create(html.ToString());
		}


		private static string GerarHtmlMenu(Menu.Menu menu, HtmlHelper htmlHelper)
		{
			var highlight = false;
			var currentAction = (string)htmlHelper.ViewContext.RouteData.Values["controller"];
			if (string.Equals(currentAction, menu.ControllerName, StringComparison.CurrentCultureIgnoreCase) || menu.SubMenu.Any(c => c.ControllerName == currentAction))
			{
				highlight = true;
			}

			var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

			var temSubItem = menu.SubMenu.Count() > 0;
			var url = string.Empty;
			if (!temSubItem)
			{
				url = urlHelper.Action(menu.ActionName, menu.ControllerName);
			}
			var writer = new StringWriter();
			using (HtmlTextWriter html = new HtmlTextWriter(writer))
			{
				var classe = temSubItem ? "has-sub" : "";
				classe += highlight ? " highlight active" : "";
				if (!string.IsNullOrEmpty(classe))
					html.AddAttribute(HtmlTextWriterAttribute.Class, classe);

				html.RenderBeginTag(HtmlTextWriterTag.Li);

				if (!temSubItem) html.AddAttribute(HtmlTextWriterAttribute.Href, url);
				if ( highlight) html.AddAttribute(HtmlTextWriterAttribute.Class, "select");
				html.RenderBeginTag(HtmlTextWriterTag.A);

				html.AddAttribute(HtmlTextWriterAttribute.Class, menu.Icone);
				html.RenderBeginTag(HtmlTextWriterTag.I);
				html.RenderEndTag();
				html.RenderBeginTag(HtmlTextWriterTag.Span);
				html.Write(menu.Nome);
				html.RenderEndTag();
				if (!temSubItem && highlight)
				{
					html.AddAttribute(HtmlTextWriterAttribute.Class, "current-page");
					html.RenderBeginTag(HtmlTextWriterTag.Span);
					html.RenderEndTag();
				}
				html.RenderEndTag();
				//Adicionar SubItens
				if (temSubItem)
				{
					if (highlight)
					{
						html.AddAttribute(HtmlTextWriterAttribute.Style, "display: block;");
					}
					html.RenderBeginTag(HtmlTextWriterTag.Ul);
				}
				foreach (var item in menu.SubMenu)
				{
					html.Write(GerarHtmlMenu(item, htmlHelper));
				}
				if (temSubItem) html.RenderEndTag();

			}
			var resultado = writer.ToString();
			return resultado;
		}
	}
}