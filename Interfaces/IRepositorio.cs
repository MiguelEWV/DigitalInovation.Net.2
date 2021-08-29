using System.Collections.Generic;

namespace DigitalInovation.Net._2.Interfaces
{
    public interface IRepositorio<T> //-->>Implementacao de uma classe para o repositorio T
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();

    }
}