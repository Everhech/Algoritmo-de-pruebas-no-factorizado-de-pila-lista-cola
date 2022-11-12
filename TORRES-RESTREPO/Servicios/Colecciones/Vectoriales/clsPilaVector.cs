using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsPilaVector<Tipo> : iPila<Tipo> where Tipo: IComparable<Tipo> // El : quiere decir que implementará los métodos públicos de la interfaz iPila.
    {
        #region Atributos
        private Tipo[] atrItems;
        private int atrCapacidad;
        private int atrLongitud;
        private bool atrEsFlexible;
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
            return atrEsFlexible;
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
                atrEsFlexible = false;
            }
            else
            {
                if (prmItems.Length == int.MaxValue / 16 + 1)
                {
                    varComprobante = false;
                    atrCapacidad = 0;
                    atrLongitud = 0;
                    atrItems = new Tipo[atrCapacidad];
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
                    atrEsFlexible = false;
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
                atrEsFlexible = true;
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
        public clsPilaVector()
        {
            atrItems = new Tipo[atrCapacidad];
            atrEsFlexible = true;
            atrFactorCrecimiento = 1000;
        }
        public clsPilaVector(int prmCapacidad)
        {
            if (prmCapacidad < 0 || prmCapacidad == int.MaxValue || prmCapacidad >= int.MaxValue / 16+1)
            {
                prmCapacidad = 0;
                atrEsFlexible = true;
                atrFactorCrecimiento = 1000;
            }
            else
            {
                if (prmCapacidad == int.MaxValue / 16)
                {
                    atrEsFlexible = false;
                    atrFactorCrecimiento = 0;
                }
                else
                {
                    atrEsFlexible = true;
                    atrFactorCrecimiento = 1000;
                }                
            }            
            atrCapacidad = prmCapacidad;
            atrItems = new Tipo[atrCapacidad];
        }
        public clsPilaVector(int prmCapacidad, bool prmDinamica)
        {
            if (prmCapacidad < 0 && prmDinamica == false || prmCapacidad >= int.MaxValue / 16 + 1  || prmCapacidad < 0 || prmCapacidad == 0 && prmDinamica == false)
            {
                prmCapacidad = 0;
                atrEsFlexible = true;
                atrFactorCrecimiento = 1000;
            }
            else
            {
                if (prmCapacidad > 0 && prmDinamica == false || prmDinamica == false)
                {
                    atrEsFlexible = false;
                    atrFactorCrecimiento = 0;
                }
                else
                {
                    atrEsFlexible = true;
                    atrFactorCrecimiento = 1000;
                }
            }
            atrCapacidad = prmCapacidad;
            atrItems = new Tipo[atrCapacidad];
        }
        public clsPilaVector(int prmCapacidad, int prmFactorCrecimiento)
        {
            if (prmCapacidad < 0 || prmFactorCrecimiento < 0 || prmCapacidad == 0 && prmFactorCrecimiento == 0 || prmFactorCrecimiento == int.MaxValue / 16 + 1 || prmCapacidad == int.MaxValue / 16 && prmFactorCrecimiento > 0 || prmCapacidad == int.MaxValue || prmCapacidad == int.MaxValue / 16 + 1 && prmFactorCrecimiento >= 0)
            {
                prmCapacidad = 0;
                atrEsFlexible = true;
                atrFactorCrecimiento = 1000;
            }
            else
            {
                if (prmFactorCrecimiento > 0)
                {
                    atrFactorCrecimiento = prmFactorCrecimiento;
                    atrEsFlexible = true;
                }
                if (prmCapacidad == int.MaxValue / 16 && prmFactorCrecimiento == 0)
                {
                    atrFactorCrecimiento = 0;
                    atrEsFlexible = false;
                }
            }
            atrCapacidad = prmCapacidad;
            atrItems = new Tipo[atrCapacidad];
        }
        #endregion
        #region CRUDs
        public bool apilar(Tipo prmItem)
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
            for (int i = atrItems.Length - 1; i > 0; i--)
            {
                atrItems[i] = atrItems[i - 1];
            }
            atrItems[0] = prmItem;
            if (atrLongitud != int.MaxValue / 16)
            {
                atrLongitud++;
            }
            return varComprobante;
            throw new NotImplementedException();
        }
        public bool desapilar(ref Tipo prmItem)
        {
            bool varComprobante = true;
            if (atrItems.Length == 0)
            {
                varComprobante = false;
                prmItem = default(Tipo);
            }
            else
            {
                prmItem = atrItems[0];
                for (int i = 0; i < atrItems.Length - 1; i++)
                {
                    atrItems[i] = atrItems[i + 1];
                }
                atrLongitud--;
            }
            return varComprobante;
            throw new NotImplementedException();
        }
        public bool revisar(ref Tipo prmItem)
        {
            bool varComprobante = true;
            if (atrItems.Length == 0)
            {
                varComprobante = false;
                prmItem = default(Tipo);
            }
            else
            {
                prmItem = atrItems[0];
            }
            return varComprobante;
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