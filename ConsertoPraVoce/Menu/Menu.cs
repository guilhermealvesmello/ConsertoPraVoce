using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsertoPraVoce.Menu
{
	public class Menu
	{
		public Menu()
		{
			SubMenu = new List<Menu>();
		}
		public string Nome { get; set; }
		public string Classe { get; set; }
		public string Icone { get; set; }
		public string ActionName { get; set; }
		public string ControllerName { get; set; }
		public List<Menu> SubMenu { get; set; }
	}
}