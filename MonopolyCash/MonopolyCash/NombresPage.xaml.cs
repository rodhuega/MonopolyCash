using MonopolyCash.Resources;
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
	public partial class NombresPage : ContentPage, ActualizableGui
	{
        List<Jugador> jugadores;
		public NombresPage ()
		{
			InitializeComponent ();
		}
        /// <summary>
        /// Metodo que se ejecuta cuando alguien presiona el boton actualizar y cambia el nombre de los jugadores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Actualizar_Clicked(object sender, EventArgs e)
        {
            foreach (Jugador ju in jugadores)
            {
                if (ju.cambiarNombre.Text != null && ju.cambiarNombre.Text != "")
                {
                    ju.nombre = ju.cambiarNombre.Text;
                    ju.cambiarNombre.Text = null;
                    ju.labelNombre.Text = ju.nombre;
                }
            }
        }

        //Metodos de la interfaz ActualizableGui

        /// <summary>
        /// Metodo de la interfaz ActualizableGui, explicado en ella
        /// </summary>
        public void ActualizarGui()
        {
            cambiarNombresLayout.Children.Clear();
            foreach (Jugador ju in jugadores)
            {
                StackLayout juLayout = new StackLayout();
                juLayout.Children.Add(ju.labelNombre);
                juLayout.Children.Add(ju.cambiarNombre);
                cambiarNombresLayout.Children.Add(juLayout);
            }
        }
        /// <summary>
        /// Metodo de la interfaz ActualizableGui, explicado en ella
        /// </summary>
        /// <param name="jugadores"></param>
        public void setJugadores(List<Jugador> jugadores)
        {
            this.jugadores = jugadores;
        }
        /// <summary>
        /// Metodo de la interfaz ActualizableGui, explicado en ella
        /// </summary>
        /// <returns></returns>
        public List<Jugador> getJugadores()
        {
            return jugadores;
        }

    }
}