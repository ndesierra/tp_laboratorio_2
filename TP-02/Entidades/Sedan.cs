using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {        
        #region Atributos

        private ETipo tipo;

        #endregion

        #region Propiedades
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Métodos        

        /// <summary>
        /// Constructor del objeto Sedán, el atributo tipo será siempre "CuatroPuertas"
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>        
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
           : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Constructor por defecto del Objeto Sedán
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }
        // <summary>
        /// Muestra los datos del Objeto Suv
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendFormat("{0}", base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendFormat("TIPO : {0}", this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region Enumerado
        /// <summary>
        /// Lista del tipo de Sedan, según cantidad de Puertas
        /// </summary>
        public enum ETipo { CuatroPuertas, CincoPuertas }
        #endregion
    }
}
