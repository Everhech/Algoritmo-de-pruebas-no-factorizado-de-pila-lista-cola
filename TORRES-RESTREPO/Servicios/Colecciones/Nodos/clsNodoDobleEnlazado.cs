using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo>: clsNodo<Tipo> where Tipo: IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        private clsNodoDobleEnlazado<Tipo> atrAnterior;
        private clsNodoDobleEnlazado<Tipo> atrSiguiente;
        #endregion
        #endregion
        #region Constructores
        public clsNodoDobleEnlazado()
        {
            this.atrItem = default(Tipo);
            this.atrSiguiente = null;
        }
        #endregion
        #region Operaciones
        #region CRUDs
        //public bool apilar(Tipo prmItem)
        //{
        //    throw new NotImplementedException();
        //}
        //public bool desapilar(ref Tipo prmItem)
        //{
        //    throw new NotImplementedException();
        //}
        //public bool revisar(ref Tipo prmItem)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #region Método pasar siguiente
        public Tipo pasarItem
        {
            get { return atrItem; }
            set { atrItem = value; }
        }
        public clsNodoDobleEnlazado<Tipo> GetAtrAnterior
        {
            get { return atrAnterior; }
            set { atrAnterior = value; }
        }
        public clsNodoDobleEnlazado<Tipo> GetAtrSiguiente
        {
            get { return atrSiguiente; }
            set { atrSiguiente = value; }
        }
        #endregion
        #endregion
    }
}
