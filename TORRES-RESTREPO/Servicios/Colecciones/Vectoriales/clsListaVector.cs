using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsListaVector<Tipo> : iLista<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        private Tipo[] atrItems;
        private int atrCapacidad;
        private int atrLongitud;
        private bool atrFlexible;
        private int atrFactorCrecimiento;
        #endregion
        #region Métodos
        #region Accesores
        public Tipo[] darItems()
        {
            return atrItems;
        }
        public int darCapacidad()
        {
            return atrCapacidad;
        }
        public int darLongitud()
        {
            return atrLongitud;
        }
        public bool esFlexible()
        {
            return atrFlexible;
        }
        public int darFactorCrecimiento()
        {
            return atrFactorCrecimiento;
        }
        #endregion
        #region Mutadores
        public bool ponerItems(Tipo[] prmItems)
        {
            bool varComprobante = true;
            atrItems = prmItems;
            if (prmItems.Length == int.MaxValue / 16)
            {
                atrLongitud = atrItems.Length;
                atrCapacidad = atrItems.Length;
                atrFactorCrecimiento = 0;
                atrFlexible = false;
            }
            else
            {
                if (prmItems.Length == int.MaxValue / 16 + 1)
                {
                    varComprobante = false;
                    atrCapacidad = 0;
                    atrLongitud = 0;
                    atrItems = new Tipo[0];
                }
                atrLongitud = atrItems.Length;
                atrCapacidad = atrItems.Length;
            }
            return varComprobante;
        }
        public bool ajustarFlexibilidad(bool prmDinamica)
        {
            if (atrCapacidad == int.MaxValue / 16)
            {
                prmDinamica = false;
            }
            else
            {
                if (atrCapacidad > 0)
                {
                    prmDinamica = true;
                    atrFlexible = false;
                    atrFactorCrecimiento = 0;
                }
            }
            return prmDinamica;
        }
        public bool ajustarFactorCrecimiento(int prmFactorCrecimiento)
        {
            bool varComprobante = true;
            atrFactorCrecimiento = prmFactorCrecimiento;
            if (atrCapacidad > 0 && atrCapacidad < int.MaxValue / 16)
            {
                atrFlexible = true;
                atrLongitud = 0;
            }
            else
            {
                if (prmFactorCrecimiento == int.MaxValue / 16)
                {
                    atrLongitud = 0;
                    atrFactorCrecimiento = atrLongitud;
                    varComprobante = false;
                }
            }
            return varComprobante;
        }
        #endregion
        #region Constructores
        public clsListaVector()
        {
            atrItems = new Tipo[atrCapacidad];
            atrFlexible = true;
            atrFactorCrecimiento = 1000;
        }
        public clsListaVector(int prmCapacidad)
        {
            if (prmCapacidad < 0 || prmCapacidad == int.MaxValue || prmCapacidad >= int.MaxValue / 16 + 1)
            {
                prmCapacidad = 0;
                atrFlexible = true;
                atrFactorCrecimiento = 1000;
            }
            else
            {
                if (prmCapacidad == int.MaxValue / 16)
                {
                    atrFlexible = false;
                    atrFactorCrecimiento = 0;
                }
                else
                {
                    atrFlexible = true;
                    atrFactorCrecimiento = 1000;
                }                
            }            
            atrCapacidad = prmCapacidad;
            atrItems = new Tipo[atrCapacidad];
        }
        public clsListaVector(int prmCapacidad, bool prmDinamica)
        {
            if (prmCapacidad < 0 && prmDinamica == false || prmCapacidad >= int.MaxValue / 16 + 1 || prmCapacidad < 0 || prmCapacidad == 0 && prmDinamica == false)
            {
                prmCapacidad = 0;
                atrFlexible = true;
                atrFactorCrecimiento = 1000;
            }
            else
            {
                if (prmCapacidad > 0 && prmDinamica == false || prmDinamica == false)
                {
                    atrFlexible = false;
                    atrFactorCrecimiento = 0;
                }
                else
                {
                    atrFlexible = true;
                    atrFactorCrecimiento = 1000;
                }
            }
            atrCapacidad = prmCapacidad;
            atrItems = new Tipo[atrCapacidad];
        }
        public clsListaVector(int prmCapacidad, int prmFactorCrecimiento)
        {
            if (prmCapacidad < 0 || prmFactorCrecimiento < 0 || prmCapacidad == 0 && prmFactorCrecimiento == 0 || prmFactorCrecimiento == int.MaxValue / 16 + 1 || prmCapacidad == int.MaxValue / 16 && prmFactorCrecimiento > 0 || prmCapacidad == int.MaxValue || prmCapacidad == int.MaxValue / 16 + 1 && prmFactorCrecimiento >= 0)
            {
                prmCapacidad = 0;
                atrFlexible = true;
                atrFactorCrecimiento = 1000;
            }
            else
            {
                if (prmFactorCrecimiento > 0)
                {
                    atrFactorCrecimiento = prmFactorCrecimiento;
                    atrFlexible = true;
                }
                if (prmCapacidad == int.MaxValue / 16 && prmFactorCrecimiento == 0)
                {
                    atrFactorCrecimiento = 0;
                    atrFlexible = false;
                }
            }
            atrCapacidad = prmCapacidad;
            atrItems = new Tipo[atrCapacidad];
        }
        #endregion
        #region CRUDs
        public bool agregar(Tipo prmItem)
        {
            bool varComprobante = true;
            Tipo[] varVectorClonado;
            if (atrItems.Length == 0)
            {
                atrCapacidad = atrFactorCrecimiento + atrLongitud;
                atrItems = new Tipo[atrCapacidad];
            }
            else
            {
                if (atrLongitud == atrItems.Length && atrItems.Length != int.MaxValue / 16)
                {
                    atrCapacidad = atrFactorCrecimiento + atrLongitud;
                    varVectorClonado = new Tipo[atrCapacidad];
                    Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                    atrItems = varVectorClonado;
                }
                if (atrItems.Length == int.MaxValue / 16)
                {
                    varComprobante = false;
                }
            }
            if (atrItems.Length < int.MaxValue / 16)
            {
                for (int i = atrLongitud; i < atrLongitud + 1; i++)
                {
                    atrItems[i] = prmItem;
                }
            }
            if (atrLongitud != int.MaxValue / 16)
            {
                atrLongitud++;
            }
            return varComprobante;
            throw new NotImplementedException();
        }
        public bool insertar(int prmIndice, Tipo prmItem)
        {
            bool varComprobante = true;
            Tipo[] varVectorClonado;
            if (prmIndice < 0)
            {
                varComprobante = false;
            }
            else
            {
                if (prmIndice <= atrLongitud)
                {
                    if (prmIndice >= 0)
                    {
                        if (atrItems.Length == atrLongitud && atrFlexible == true)
                        {
                            atrCapacidad = atrFactorCrecimiento + atrLongitud;
                            varVectorClonado = new Tipo[atrCapacidad];
                            Array.Copy(atrItems, varVectorClonado, atrItems.Length);
                            atrItems = varVectorClonado;
                        }
                        else
                        {
                            if (atrItems.Length == atrLongitud && atrFlexible == false || prmIndice > atrLongitud)
                            {
                                varComprobante = false;
                            }
                        }
                        if (varComprobante == true || prmIndice < atrLongitud && varComprobante == true)
                        {
                            for (int i = atrItems.Length - 1; i > prmIndice; i--)
                            {
                                atrItems[i] = atrItems[i - 1];
                            }
                            atrItems[prmIndice] = prmItem;
                            atrLongitud++;
                        }
                        else
                        {
                            if (prmIndice == atrLongitud)
                            {
                                varComprobante = false;
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
        public bool extraer(int prmIndice, ref Tipo prmItem)
        {
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
                            prmItem = atrItems[prmIndice];
                            for (int i = prmIndice; i < atrLongitud-1; i++)
                            {
                                atrItems[i] = atrItems[i + 1];
                            }
                            atrLongitud--;
                        }
                        else
                        {
                            if (prmIndice == atrLongitud)
                            {
                                varComprobante = false;
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
                            atrItems[prmIndice] = prmItem;
                        }
                        else
                        {
                            if (prmIndice == atrLongitud)
                            {
                                varComprobante = false;
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
        public bool recuperar(int prmIndice, ref Tipo prmItem)
        {
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
                            prmItem = atrItems[prmIndice];
                        }
                        else
                        {
                            if (prmIndice == atrLongitud)
                            {
                                varComprobante = false;
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
            if(atrItems.Length == 0)
            {
                varComprobante = false;
            }
            else
            {
                for(int i = 0; i < atrLongitud; i++)
                {
                    if(atrItems[i].Equals(prmItem))
                    {
                        varComprobante = true;
                    }
                    else
                    {
                        varComprobante = false;
                    }
                }
            }
            return varComprobante;
            throw new NotImplementedException();
        }
        public int encontrar(Tipo prmItem)
        {
            int varEncontrar = 0;
            int varContador = 0;
            for (int i = 0; i < atrLongitud; i++)
            {
                if (atrItems[i].Equals(prmItem))
                {
                    varEncontrar = i+varContador;
                }
                else
                {
                    varEncontrar = -1;
                }
                if (atrItems[i].Equals(atrItems[i + 1]))
                {
                    varContador--;
                }                
            }
            if (atrItems.Length == 0 && prmItem.Equals(atrItems.Length))
            {
                varEncontrar = atrLongitud - 1;
            }
            return varEncontrar;
            throw new NotImplementedException();
        }
        public bool reversar()
        {
            bool varComprobante = true;
            Tipo varValor;
            if (atrLongitud == 0)
            {
                varComprobante = false;
            }
            for (int i = 0; i < atrLongitud - 2; i++)
            {
                varValor = atrItems[i];
                atrItems[i] = atrItems[atrLongitud - 1 - i];
                atrItems[atrLongitud - 1 - i] = varValor;
            }
            return varComprobante;
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
