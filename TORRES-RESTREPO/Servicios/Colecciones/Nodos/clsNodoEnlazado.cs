using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoEnlazado<Tipo>: clsNodo<Tipo> where Tipo: IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        private clsNodoEnlazado<Tipo> atrSiguiente;
        #endregion
        #endregion
        #region Métodos
        #region Constructores
        public clsNodoEnlazado()
        {
            this.atrItem = default(Tipo);
            this.atrSiguiente = null;
        }
        #endregion
        #region Método pasar siguiente
        public Tipo pasarItem
        {
            get { return atrItem; }
            set { atrItem = value; }
        }
        public clsNodoEnlazado<Tipo> GetAtrSiguiente
        {
            get { return atrSiguiente; }
            set { atrSiguiente = value; }
        }
        #endregion
        #endregion
    }
}
