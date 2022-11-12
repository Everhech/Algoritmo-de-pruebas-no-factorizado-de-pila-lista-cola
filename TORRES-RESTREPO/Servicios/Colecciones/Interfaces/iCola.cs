using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iCola<Tipo> where Tipo: IComparable<Tipo>
    {
        #region CRUDs
        bool encolar(Tipo prmItem);
        bool desencolar(ref Tipo prmItem);
        bool revisar(ref Tipo prmItem);
        bool reversar();
        #endregion
    }
}
