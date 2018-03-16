using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;

namespace ConsertoPraVoce.Helpers
{
	public static class Helpers
	{
		public static MvcHtmlString MenuItem(this HtmlHelper htmlHelper, string action, string controller, string nome, string classe)
		{
			var highlight = false;
			var currentAction = (string)htmlHelper.ViewContext.RouteData.Values["controller"];
			if (string.Equals(currentAction, controller, StringComparison.CurrentCultureIgnoreCase)
			)
			{
				highlight = true;
			}

			var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

			var url = urlHelper.Action(action, controller);
			var writer = new StringWriter();
			using (HtmlTextWriter html = new HtmlTextWriter(writer))
			{
				if (highlight)
				{
					html.AddAttribute(HtmlTextWriterAttribute.Class, "highlight");
				}
				html.RenderBeginTag(HtmlTextWriterTag.Li);
				html.AddAttribute(HtmlTextWriterAttribute.Href, url);
				html.RenderBeginTag(HtmlTextWriterTag.A);
				
				html.AddAttribute(HtmlTextWriterAttribute.Class, classe);
				html.RenderBeginTag(HtmlTextWriterTag.I);
				html.RenderEndTag();
				html.RenderBeginTag(HtmlTextWriterTag.Span);
				html.Write(nome);
				html.RenderEndTag();
				if (highlight)
				{
					html.AddAttribute(HtmlTextWriterAttribute.Class, "current-page");
					html.RenderBeginTag(HtmlTextWriterTag.Span);
					html.RenderEndTag();
				}
				html.RenderEndTag();
			}
			var resultado = writer.ToString();


			return MvcHtmlString.Create(resultado);
		}
	}
}