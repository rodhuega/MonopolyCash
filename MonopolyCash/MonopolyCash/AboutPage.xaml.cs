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
	public partial class AboutPage : ContentPage, ActualizableGui
	{
        List<Jugador> jugadores;
        public AboutPage ()
		{
			InitializeComponent ();
		}

        public void ActualizarGui() { }

        public void setJugadores(List<Jugador> jugadores)
        {
            this.jugadores = jugadores;
        }

        public List<Jugador> getJugadores()
        {
            return jugadores;
        }
    }
}