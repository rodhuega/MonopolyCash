using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonopolyCash
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : MasterDetailPage
	{
        /// <summary>
        /// Atributo que contiene las paginas del menu
        /// </summary>
        private List<Menu> menu;
        /// <summary>
        /// Atributo que dice en que pagina me encuentro
        /// </summary>
        private int indicePag;
        public MenuPage ()
		{
			InitializeComponent ();
            //Se pone el indice de pag a 0 porque inicialmente siempre se inicia en la MainPage
            indicePag = 0;
            //Se crea la lista que contiene las paginas que hay en la app y se le asigna a un ListView que mostrarta el Titulo y el Detail mediante binding
            menu = new List<Menu>()
            {
                new Menu{MenuPage=new MainPage(),MenuTitle="Inicio", MenuDetail="Pagina Principal"},
                new Menu{MenuPage=new NombresPage(),MenuTitle="Cambiar Nombres", MenuDetail="Pagina para cambiar los nombres"},
                new Menu{MenuPage=new AboutPage(),MenuTitle="Acerca de", MenuDetail="Informacion sobre la APp"}
            };
            ListaMenu.ItemsSource = menu;
            //Inicialmente va a la MainPage
            Detail = new NavigationPage(menu[0].MenuPage);
            
        }

        /// <summary>
        /// Metodo que se ejecuta cuando se navega a otra pagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListaMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Menu m = e.SelectedItem as Menu;//Pagina a la que voy
            if(m!=null)
            {
                ActualizableGui nuevaPage = m.MenuPage as ActualizableGui;
                ActualizableGui actualPage = menu[indicePag].MenuPage as ActualizableGui;//Pagina en la que todavia estoy
                //Se averigua a que pagina para cambiar el indice de en que pagina estoy para poder hacer el casting as de forma correcta y que no falle el getJugadores para que no se pierda la informacion
                if(m.MenuTitle.Equals("Inicio"))
                {
                    indicePag = 0;
                }else if(m.MenuTitle.Equals("Cambiar Nombres"))
                {
                    indicePag = 1;
                }else if(m.MenuTitle.Equals("Acerca de"))
                {
                    indicePag = 2;
                }
                nuevaPage.setJugadores(actualPage.getJugadores());
                nuevaPage.ActualizarGui();
                //Cambio de pagina
                IsPresented = false;
                Detail = new NavigationPage(m.MenuPage);
            }
        }

    }
}