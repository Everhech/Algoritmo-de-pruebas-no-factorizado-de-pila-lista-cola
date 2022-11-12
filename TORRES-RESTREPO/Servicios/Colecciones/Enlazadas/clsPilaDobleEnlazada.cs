using System;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsPilaDobleEnlazada<Tipo> : iPila<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        private clsNodoDobleEnlazado<Tipo> atrPrimero;
        private clsNodoDobleEnlazado<Tipo> atrUltimo;
        #endregion
        #region Accesores
        private Tipo[] atrItems;
        private int atrLongitud;
        #endregion
        #endregion
        #region Accesores
        public Tipo[] darItems()
        {
            return atrItems;
        }
        public int darLongitud()
        {
            return atrLongitud;
        }
        public clsNodoDobleEnlazado<Tipo> darPrimero()
        {
            return atrPrimero;
        }
        public clsNodoDobleEnlazado<Tipo> darUltimo()
        {
            return atrUltimo;
        }
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
            else if (prmItems.Length == int.MaxValue / 16 + 1)
            {
                varComprobante = false;
                atrLongitud = 0;
                atrItems = null;
            }
            else
            {
                atrLongitud = atrItems.Length;
                for(int i = 0; i < atrItems.Length; i++)
                {
                    clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
                    varActual.pasarItem = atrItems[i];
                    if(atrPrimero == null)
                    {
                        atrPrimero = varActual;
                        atrUltimo = atrPrimero;                        
                    }
                    else
                    {
                        atrUltimo.GetAtrSiguiente = varActual;
                        varActual.GetAtrAnterior = atrUltimo;
                        atrUltimo = varActual;
                    }
                }
            }                            
            return varComprobante;
        }
        #endregion
        #region Constructores
        #endregion
        #region CRUDs
        public bool apilar(Tipo prmItem)
        {
            Tipo[] varVectorClonado;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
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
            if (atrItems.Length > 0 && atrItems.Length < int.MaxValue / 16)
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
                    varActual.GetAtrSiguiente.GetAtrAnterior = varActual;
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
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            int i = 0;
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
                    atrPrimero.GetAtrAnterior = null;
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
                clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
                varCopia = atrPrimero;
                while (atrPrimero != null)
                {
                    atrPrimero = atrPrimero.GetAtrSiguiente;
                    clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
                    varActual = atrPrimero;
                    atrPrimero = varActual.GetAtrSiguiente;
                }
                atrUltimo = atrPrimero;
                while (varCopia != null)
                {
                    clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
                    varActual.pasarItem = varCopia.pasarItem;
                    if (atrPrimero == null)
                    {
                        atrPrimero = varActual;
                        atrUltimo = atrPrimero;
                    }
                    else
                    {
                        varActual.GetAtrSiguiente = atrPrimero;
                        varActual.GetAtrSiguiente.GetAtrAnterior = varActual;
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
    }
}
