using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsPilaEnlazada<Tipo> : iPila<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        private clsNodoEnlazado<Tipo> atrPrimero;
        private clsNodoEnlazado<Tipo> atrUltimo;
        #endregion
        #region Accesores
        private Tipo[] atrItems;
        private int atrLongitud;
        #endregion
        #endregion
        #region Métodos
        #region Accesores
        public Tipo[] darItems()
        {
            return atrItems;
        }
        public int darLongitud()
        {
            return atrLongitud;
        }
        public clsNodoEnlazado<Tipo> darPrimero()
        {
            return atrPrimero;
        }
        public clsNodoEnlazado<Tipo> darUltimo()
        {
            return atrUltimo;
        }
        #endregion
        #region Constructores
        #endregion
        #region Mutadores
        public bool ponerItems(Tipo[] prmItems)
        {
            bool varComprobante = true;
            atrItems = prmItems;
            if (prmItems.Length == 0)
            {
                varComprobante = false;
            }
            else if (prmItems.Length == int.MaxValue / 16)
            {
                atrLongitud = atrItems.Length;
            }
            else if (prmItems.Length >= int.MaxValue / 16 + 1)
            {
                varComprobante = false;
                atrLongitud = 0;
                atrItems = null;
            }
            else
            {
                atrLongitud = atrItems.Length;     
                for (int i = 0; i < atrItems.Length; i++)
                {
                    clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
                    varActual.pasarItem = atrItems[i];
                    if (atrPrimero == null)
                    {
                        atrPrimero = varActual;
                        atrUltimo = atrPrimero;
                    }
                    else
                    {
                        atrUltimo.GetAtrSiguiente = varActual;
                        atrUltimo = varActual;
                    }
                }
            }            
            return varComprobante;
        }
        #endregion
        #region CRUDs
        public bool apilar(Tipo prmItem)
        {
            clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
            Tipo[] varVectorClonado;
            int i = 0;
            if (atrItems == null)
            {
                atrItems = new Tipo[atrLongitud + 1];
            }
            else if (atrItems.Length == atrLongitud && atrItems.Length < int.MaxValue / 16)
            {
                varVectorClonado = new Tipo[atrLongitud + 1];
                Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                atrItems = varVectorClonado;
            }
            else if (atrItems.Length >= int.MaxValue / 16)
            {
                return false;
            }
            if (atrItems.Length > 0 && atrItems.Length < int.MaxValue/16)
            {                
                varActual.pasarItem = prmItem;
                if(atrPrimero == null)
                {
                    atrPrimero = varActual;
                    atrUltimo = atrPrimero;
                }
                else
                {
                    varActual.GetAtrSiguiente = atrPrimero;
                    atrPrimero = varActual;
                }
                varActual = atrPrimero;
                while (varActual != null)
                {
                    atrItems[i] = varActual.pasarItem;
                    varActual = varActual.GetAtrSiguiente;
                    i++;
                }
                atrLongitud++;
            }
            return true;
            throw new NotImplementedException();
        }
        public bool desapilar(ref Tipo prmItem)
        {
            int i = 0;
            clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
            if (atrItems == null)
            {
                prmItem = default(Tipo);
                return false;
            }
            else
            {
                atrLongitud--;
                atrItems = new Tipo[atrLongitud];
                #region Desapilar en Nodo
                if (atrPrimero != null)
                {
                    varActual = atrPrimero;
                    atrPrimero = varActual.GetAtrSiguiente;
                    atrUltimo = atrPrimero.GetAtrSiguiente;
                }
                else
                {
                    atrPrimero = null;
                    atrUltimo = atrPrimero;
                }
                #endregion
                #region Pasar datos del Nodo a Vector
                prmItem = varActual.pasarItem;
                varActual = atrPrimero;
                while (varActual != null)
                {
                    atrItems[i] = varActual.pasarItem;
                    varActual = varActual.GetAtrSiguiente;
                    i++;
                }
                #endregion
                return true;
            }
            throw new NotImplementedException();
        }
        public bool revisar(ref Tipo prmItem)
        {
            if (atrItems == null)
            {
                prmItem = default(Tipo);
                return false;
            }
            else
            {
                prmItem = atrPrimero.pasarItem;
                return true;
            }
            throw new NotImplementedException();
        }
        public bool reversar()  
        {
            if (atrItems == null)
            {
                return false;
            }
            else
            {
                clsNodoEnlazado<Tipo> varCopia = new clsNodoEnlazado<Tipo>();
                varCopia = atrPrimero;
                while (atrPrimero != null)
                {
                    atrPrimero = atrPrimero.GetAtrSiguiente;
                }
                atrUltimo = atrPrimero;
                while (varCopia != null)
                {
                    clsNodoEnlazado<Tipo> varActual = new clsNodoEnlazado<Tipo>();
                    varActual.pasarItem = varCopia.pasarItem;
                    if (atrPrimero == null)
                    {
                        atrPrimero = varActual;
                        atrUltimo = atrPrimero;
                    }
                    else
                    {
                        varActual.GetAtrSiguiente = atrPrimero;
                        atrPrimero = varActual;
                    }
                    varCopia = varCopia.GetAtrSiguiente;
                }
                varCopia = atrPrimero;
                for (int i = 0; i < atrItems.Length; i++)
                {
                    atrItems[i] = varCopia.pasarItem;
                    varCopia = varCopia.GetAtrSiguiente;
                }
                return true;
            }            
            throw new NotImplementedException();
        }
        #endregion 
        #endregion
    }
}
