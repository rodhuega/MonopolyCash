using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonopolyCash
{
	public partial class MainPage : ContentPage, ActualizableGui
	{
        /// <summary>
        /// Propiedad Array de los jugadores que hay en la partida
        /// </summary>
        public List<Jugador> jugadores { get; set; }
        public MainPage()
		{
			InitializeComponent();
            //Inicialmente se inicia una partida de 2 jugadores.
            pickerNJugadores.SelectedIndex = 0;
            anyadirJugadores(2);

        }

        
        /// <summary>
        /// Metodo que se ejecuta cuando alguien cambia el numero de jugadores para generar una nueva partida con ellos, o cuando se habre la app por primera vez
        /// </summary>
        /// <param name="final"></param>
        private void anyadirJugadores(int final)
        {
            jugadores = new List<Jugador>();
            jugadoresLayout.Children.Clear();
            for (int i = 1; i <= final; i++)
            {
                Label labelNombreJugador = new Label() { Text = "Jugador " + i };
                Label labelCantidadJugador = new Label() { Text = "0" };
                Entry entryModCantidad = new Entry() { Placeholder = "Cantidad", Keyboard = Keyboard.Telephone };
                jugadores.Add(new Jugador("Jugador " + i, i, entryModCantidad, labelCantidadJugador, labelNombreJugador));
            }
            ActualizarGui();
        }

        

        /// <summary>
        /// Metodo que comprueba que cuando se escribe una nueva cantidad, sea un numero y no algo que no sea valido, si es legal, devuelve true
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private bool ningunCaracterRaro(string cadena)
        {
            char[] charcadena=cadena.ToCharArray();
            int i;
            //Se tiene en cuanta de que el numero tenga signo.
            if (charcadena[0]=='+' || charcadena[0]=='-')
            {
                i = 1;
            }else {
                i = 0;
            }
            while(i<charcadena.Length)
            {
                if(charcadena[i]!='1'&& charcadena[i] != '2' && charcadena[i] != '3' && charcadena[i] != '4' && charcadena[i] != '5' && charcadena[i] != '6' &&
                    charcadena[i] !='7' && charcadena[i] != '8' && charcadena[i] != '9' && charcadena[i]!='0')
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        //Metodos de eventos de boton

        /// <summary>
        /// Metodo que actualiza las cantidades de cada jugador segun el valor de sus Entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonActualizar_Clicked(object sender, EventArgs e)
        {
            foreach (Jugador ju in jugadores)
            {
                if (ju.entryMod.Text != null && ju.entryMod.Text != "" && ningunCaracterRaro(ju.entryMod.Text))
                {
                    ju.dinero += Int32.Parse(ju.entryMod.Text);
                }
                ju.entryMod.Text = null;
            }
            ActualizarGui();
        }
        /// <summary>
        /// Metodo que se ejecuta cuando alguien cambia el numero de jugadores que hay en la partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pickerNJugadores_Changed(object sender, EventArgs e)
        {
            anyadirJugadores(Int32.Parse(pickerNJugadores.SelectedItem.ToString()));
        }

        /// <summary>
        /// Metodo que quita todo el dinero  a los jugadores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReiniciar_Clicked(object sender, EventArgs e)
        {
            foreach (Jugador ju in jugadores)
            {
                ju.dinero = 0;
            }
            ActualizarGui();
        }
        /// <summary>
        /// Metodo que se ejecuta cuando alguien va a efectuar una transferencia, se compureba que no se pueda hacer una transferencia el mismo jugador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAceptar_Clicked(object sender, EventArgs e)
        {
            int tran1Index = pickerTran1.SelectedIndex;
            int tran2Index = pickerTran2.SelectedIndex;
            if(tran1Index!=tran2Index && entryCantidadTransferencia.Text!=null && entryCantidadTransferencia.Text!="")
            {
                int dinero = Int32.Parse(entryCantidadTransferencia.Text);
                Jugador aux1=jugadores[tran1Index];
                Jugador aux2 = jugadores[tran2Index];
                aux1.dinero -= dinero;
                aux2.dinero += dinero;
                entryCantidadTransferencia.Text = "";
                ActualizarGui();
            }
            else {
                entryCantidadTransferencia.Placeholder = "Introduzca una cantidad y no seleccione el mismo jugador";
            }

        }

        //Metodos de la interfaz ActualizableGui

        /// <summary>
        /// Metodo de la interfaz ActualizableGui, explicado en ella
        /// </summary>
        public void ActualizarGui()
        {
            jugadoresLayout.Children.Clear();
            foreach (Jugador jugador in jugadores)
            {
                jugador.labelCantidad.Text = jugador.dinero.ToString();
                jugador.labelNombre.Text = jugador.nombre;
                StackLayout jugadorLayout = new StackLayout();
                jugadorLayout.Children.Add(jugador.labelNombre);
                jugadorLayout.Children.Add(jugador.labelCantidad);
                jugadorLayout.Children.Add(jugador.entryMod);
                jugadoresLayout.Children.Add(jugadorLayout);
            }
            pickerTran1.ItemsSource = jugadores;
            pickerTran1.ItemDisplayBinding = new Binding("nombre");

            pickerTran2.ItemsSource = jugadores;
            pickerTran2.ItemDisplayBinding = new Binding("nombre");
            pickerTran1.SelectedIndex = 0;
            pickerTran2.SelectedIndex = 0;
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
