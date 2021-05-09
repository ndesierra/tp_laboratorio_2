using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        #region Atributos

        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor privado del Objeto Taller, inicializa la lista Vehículos
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor del objeto Taller
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible): this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="t">Elemento a exponer</param>
        /// <param name="tipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", t.vehiculos.Count, t.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in t.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if (v is Suv)
                        {
                            sb.AppendFormat("{0}", v.Mostrar());
                        }                        
                        break;
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        {
                            sb.AppendFormat("{0}", v.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if (v is Sedan)
                        {
                            sb.AppendFormat("{0}", v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendFormat("{0}", v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="t">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller t, Vehiculo vehiculo)
        {
            if (t.vehiculos.Count < t.espacioDisponible)
            {
                foreach (Vehiculo v in t.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        return t;
                    }
                }
                t.vehiculos.Add(vehiculo);
            }            

            return t;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller t, Vehiculo vehiculo)
        {
            if (t.vehiculos.Count > 0)
            {
                foreach (Vehiculo v in t.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        t.vehiculos.Remove(v);
                        break;                        
                    }
                }
            }
            
            return t;
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Lista de Tipo de Vehículo
        /// </summary>
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }
        #endregion
    }
}
