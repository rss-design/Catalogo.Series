using System.Collections.Generic;

namespace Catalogo.Series.Interfaces
{
    // Implementando uma interface que recebe um tipo generico.
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorId(int id);

         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}