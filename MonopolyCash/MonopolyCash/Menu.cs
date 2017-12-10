using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonopolyCash { 

    /// <summary>
    /// Clase con la finalidad de contener una pagina del hamburgerMenu
    /// </summary>
    class Menu
    {
        /// <summary>
        /// Propiedad del nombre de la pagina
        /// </summary>
        public string MenuTitle { get; set; }
        /// <summary>
        /// Propiedad del Detail de la pagina(breve explicacion)
        /// </summary>
        public string MenuDetail { get; set; }
        /// <summary>
        /// Propiedad que contiene la pagina en si.
        /// </summary>
        public Page MenuPage { get; set; }
    }
}
