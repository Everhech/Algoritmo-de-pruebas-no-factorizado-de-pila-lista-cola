using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodo<Tipo> where Tipo: IComparable<Tipo>
    {
        #region Atributos
        #region Propios
        protected Tipo atrItem;
        #endregion
        #endregion
    }
}
