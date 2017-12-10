using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyCash
{
    /// <summary>
    /// Interfaz que sera implementada por todas las paginas en las que haya navegacion(AboutPage,NombresPage,MainPage) con la finalidad de que no se pierda la informacion de los jugadores
    /// </summary>
    interface ActualizableGui
    {
        /// <summary>
        /// Metodo que tiene como finalidad que se actualicen elementos de la GUI
        /// </summary>
        void ActualizarGui();
        /// <summary>
        /// Metodo con la finalidad de setear los atributos jugadores de cada pagina para que no se pierdan en la navegacion entre paginas
        /// </summary>
        /// <param name="jugadores"></param>
        void setJugadores(List<Jugador> jugadores);
        /// <summary>
        /// Metodo que obtiene el atributo de cada pagina para luego hacer un set con el y que asi no se pierda la informacion en la navegacion entre paginas
        /// </summary>
        /// <returns></returns>
        List<Jugador> getJugadores();
    }
}
