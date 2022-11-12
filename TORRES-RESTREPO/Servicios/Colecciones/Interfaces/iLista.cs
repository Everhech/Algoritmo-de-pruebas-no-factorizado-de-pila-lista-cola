using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iLista<Tipo> where Tipo: IComparable<Tipo>
    {
        #region CRUDs
        bool agregar(Tipo prmItem);
        bool insertar(int prmIndice, Tipo prmItem);
        bool extraer(int prmIndice, ref Tipo prmItem);
        bool modificar(int prmIndice, Tipo prmItem);
        bool recuperar(int prmIndice, ref Tipo prmItem);
        bool contiene(Tipo prmItem);
        int encontrar(Tipo prmItem);
        bool reversar();
        #endregion
        #region QUERY
        //bool Encontrar(Tipo prmItem, ref int prmIndice);
        #endregion
    }
}
