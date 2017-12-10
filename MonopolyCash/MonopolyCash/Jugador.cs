using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonopolyCash
{
    public class Jugador
    {
        /// <summary>
        /// Propiedad que contiene el nombre del jugador
        /// </summary>
        public string nombre { get; set; }

        /// <summary>
        /// Propiedad que contiene el dinero del jugador
        /// </summary>
        public int dinero { get; set; }
        /// <summary>
        /// Propiedad que contiene la id interna del jugador (sin uso actual)
        /// </summary>
        public int idInterna { get; set; }
        /// <summary>
        /// Propiedad de la Label que muestra el nombre del jugador por pantalla
        /// </summary>
        public Label labelNombre { get; set; }
        /// <summary>
        /// Propiedad de la Label que meustra el dinero del jugador por pantalla
        /// </summary>
        public Label labelCantidad { get; set; }
        /// <summary>
        /// Propiedad de la Entry que modifica la cantidad de dienro del jugador
        /// </summary>
        public Entry entryMod { get; set; }
        /// <summary>
        /// Propiedad que permite cambiar el nombre del jugador
        /// </summary>
        public Entry cambiarNombre { get; set; }
        /// <summary>
        /// Constructor del jugador, al cual se le pasa un nombre,una id(sin uso actual), una Entry de cantidad, Label de cantidad, y Label de nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="idInterna"></param>
        /// <param name="entryMod"></param>
        /// <param name="labelCantidad"></param>
        /// <param name="labelNombre"></param>
        public Jugador(string nombre, int idInterna, Entry entryMod,Label labelCantidad, Label labelNombre)
        {
            this.nombre = nombre;
            this.idInterna = idInterna;
            dinero = 0;
            this.entryMod = entryMod;
            this.labelCantidad = labelCantidad;
            this.labelNombre = labelNombre;
            cambiarNombre = new Entry() { Placeholder = "Nuevo Nombre" };
        }
    }
}
