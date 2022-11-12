using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsListaDobleEnlazada<Tipo> : iLista<Tipo> where Tipo : IComparable<Tipo>
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
                for (int i = 0; i < atrItems.Length; i++)
                {
                    clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
                    varActual.pasarItem = atrItems[i];
                    if (atrPrimero == null)
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
        public bool agregar(Tipo prmItem)
        {
            bool varComprobante = true;
            int i = 0;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            Tipo[] varVectorClonado;
            if (atrItems == null)
            {
                atrItems = new Tipo[atrLongitud + 1];
            }
            else if (atrLongitud == atrItems.Length && atrItems.Length != int.MaxValue / 16)
            {
                varVectorClonado = new Tipo[atrLongitud + 1];
                Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                atrItems = varVectorClonado;
            }
            else if (atrItems.Length == int.MaxValue / 16)
            {
                varComprobante = false;
            }
            if (atrItems.Length < int.MaxValue / 16)
            {
                varActual.pasarItem = prmItem;
                if (atrPrimero == null)
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
                varActual = atrPrimero;
                while (varActual != null)
                {
                    atrItems[i] = varActual.pasarItem;
                    varActual = varActual.GetAtrSiguiente;
                    i++;
                }
                atrLongitud++;
            }
            return varComprobante;
            throw new NotImplementedException();
        }
        public bool insertar(int prmIndice, Tipo prmItem)
        {
            bool varComprobante = true;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            Tipo[] varVectorClonado;
            if (prmIndice < 0)
            {
                varComprobante = false;
            }
            if (prmIndice <= atrLongitud)
            {
                if (prmIndice >= 0)
                {
                    if (atrItems == null)
                    {
                        atrItems = new Tipo[atrLongitud + 1];
                    }
                    else if (atrItems.Length == atrLongitud)
                    {
                        varVectorClonado = new Tipo[atrLongitud + 1];
                        Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                        atrItems = varVectorClonado;
                    }
                    if (varComprobante == true || prmIndice < atrLongitud && varComprobante == true)
                    {
                        varActual.pasarItem = prmItem;
                        if (prmIndice == 0)
                        {
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
                        }
                        else if (prmIndice == atrItems.Length - 1)
                        {
                            atrUltimo.GetAtrSiguiente = varActual;
                            varActual.GetAtrAnterior = atrUltimo;
                            atrUltimo = varActual;
                        }
                        else
                        {
                            varCopia = atrPrimero;
                            while (!varCopia.pasarItem.Equals(atrItems[prmIndice]))
                            {
                                varCopia = varCopia.GetAtrSiguiente;
                            }
                            varActual.GetAtrSiguiente = varCopia;
                            varCopia = atrPrimero;
                            while (!varCopia.pasarItem.Equals(atrItems[prmIndice - 1]))
                            {
                                if (varCopia.GetAtrSiguiente != null)
                                {
                                    varCopia = varCopia.GetAtrSiguiente;
                                }
                            }
                            varCopia.GetAtrSiguiente = varActual;
                            varActual.GetAtrAnterior = varCopia;
                            varActual.GetAtrSiguiente.GetAtrAnterior = varActual;
                            atrUltimo = varActual.GetAtrSiguiente;
                            atrUltimo.GetAtrAnterior = varActual;
                            atrPrimero.GetAtrSiguiente = varCopia;
                        }
                        varActual = atrPrimero;
                        for (int i = 0; i < atrItems.Length; i++)
                        {
                            atrItems[i] = varActual.pasarItem;
                            varActual = varActual.GetAtrSiguiente;
                        }
                        atrLongitud++;
                    }
                }
            }
            else
            {
                varComprobante = false;
            }
            return varComprobante;
            throw new NotImplementedException();
        }
        public bool extraer(int prmIndice, ref Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            bool prueba = false;
            bool varComprobante = true;
            if (prmIndice < 0 || atrLongitud == 0)
            {
                varComprobante = false;
            }
            else
            {
                if (prmIndice < atrLongitud)
                {
                    if (prmIndice >= 0)
                    {
                        if (varComprobante == true || prmIndice < atrLongitud && varComprobante == true)
                        {
                            if (prmIndice == 0)
                            {
                                prmItem = atrPrimero.pasarItem;
                                varActual = atrPrimero;
                                atrPrimero = varActual.GetAtrSiguiente;
                                atrPrimero.GetAtrAnterior = null;
                                atrLongitud--;
                                atrItems = new Tipo[atrLongitud];
                            }
                            else if (prmIndice == atrItems.Length - 1)
                            {
                                varActual = atrPrimero;
                                varCopia = atrPrimero;
                                while (varActual.GetAtrSiguiente != null)
                                {
                                    varCopia = varActual;
                                    varActual = varActual.GetAtrSiguiente;
                                }
                                prmItem = varCopia.GetAtrSiguiente.pasarItem;
                                varCopia.GetAtrSiguiente = null;
                                atrUltimo = varCopia;
                                atrPrimero.GetAtrSiguiente = varCopia;
                                atrLongitud--;
                                atrItems = new Tipo[atrLongitud];
                            }
                            else
                            {
                                varCopia = atrPrimero;
                                while (!varCopia.pasarItem.Equals(atrItems[prmIndice]))
                                {
                                    varCopia = varCopia.GetAtrSiguiente;
                                }
                                varActual.GetAtrSiguiente = varCopia;
                                varCopia = atrPrimero;
                                while (!varCopia.pasarItem.Equals(atrItems[prmIndice - 1]) && prueba == false)
                                {
                                    if (varCopia.GetAtrSiguiente != null)
                                    {
                                        varCopia = varCopia.GetAtrSiguiente;
                                    }
                                }
                                varCopia.GetAtrSiguiente = varActual;
                                atrPrimero.GetAtrSiguiente = varCopia;
                            }
                            varActual = atrPrimero;
                            for (int i = 0; i < atrItems.Length; i++)
                            {
                                atrItems[i] = varActual.pasarItem;
                                varActual = varActual.GetAtrSiguiente;
                            }
                        }
                    }
                }
                else
                {
                    varComprobante = false;
                }
            }
            return varComprobante;
            throw new NotImplementedException();
        }
        public bool modificar(int prmIndice, Tipo prmItem)
        {
            bool varComprobante = true;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            if (prmIndice < 0 || atrLongitud == 0)
            {
                varComprobante = false;
            }
            else
            {
                if (prmIndice < atrLongitud)
                {
                    if (prmIndice >= 0)
                    {
                        if (varComprobante == true || prmIndice < atrLongitud && varComprobante == true)
                        {
                            if (prmIndice == 0)
                            {
                                atrPrimero.pasarItem = prmItem;
                            }
                            else if (prmIndice == atrItems.Length - 1)
                            {
                                atrUltimo.pasarItem = prmItem;
                            }
                            varActual = atrPrimero;
                            for (int i = 0; i < atrItems.Length; i++)
                            {
                                atrItems[i] = varActual.pasarItem;
                                varActual = varActual.GetAtrSiguiente;
                            }
                        }
                    }
                }
                else
                {
                    varComprobante = false;
                }
            }
            return varComprobante;
        }
        public bool recuperar(int prmIndice, ref Tipo prmItem)
        {
            bool varComprobante = true;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            if (prmIndice < 0 || atrLongitud == 0)
            {
                varComprobante = false;
            }
            else
            {
                if (prmIndice < atrLongitud)
                {
                    if (prmIndice >= 0)
                    {
                        if (varComprobante == true || prmIndice < atrLongitud && varComprobante == true)
                        {
                            if (prmIndice == 0)
                            {
                                prmItem = atrPrimero.pasarItem;
                            }
                            else if (prmIndice == atrItems.Length - 1)
                            {
                                prmItem = atrUltimo.pasarItem;
                            }
                        }
                    }
                }
                else
                {
                    varComprobante = false;
                }
            }
            return varComprobante;
            throw new NotImplementedException();
        }
        public bool contiene(Tipo prmItem)
        {
            bool varComprobante = true;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            if (atrItems == null)
            {
                varComprobante = false;
            }
            else
            {
                varActual.pasarItem = prmItem;
                varCopia = atrPrimero;
                for (int i = 0; i < atrLongitud; i++)
                {
                    if (varCopia.pasarItem.Equals(varActual.pasarItem))
                    {
                        varComprobante = true;
                    }
                    else
                    {
                        varComprobante = false;
                    }
                    varCopia = varCopia.GetAtrSiguiente;
                }
            }
            return varComprobante;
            throw new NotImplementedException();
        }
        public int encontrar(Tipo prmItem)
        {
            int varEncontrar = 0;
            int varContador = 0;
            clsNodoDobleEnlazado<Tipo> varActual = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> varCopia = new clsNodoDobleEnlazado<Tipo>();
            varActual.pasarItem = prmItem;
            varCopia = atrPrimero;
            if (atrItems != null)
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    if (varCopia.pasarItem.Equals(varActual.pasarItem))
                    {
                        varEncontrar = i + varContador;
                    }
                    else
                    {
                        varEncontrar = -1;
                    }
                    if (varCopia.GetAtrSiguiente != null)
                    {
                        if (varActual.pasarItem.Equals(varCopia.pasarItem))
                        {
                            varContador--;
                        }
                    }
                    varCopia = varCopia.GetAtrSiguiente;
                }
            }
            else
            {
                varEncontrar--;

            }

            return varEncontrar;
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
