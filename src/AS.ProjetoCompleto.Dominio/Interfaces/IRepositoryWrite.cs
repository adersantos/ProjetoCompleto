using AS.ProjetoCompleto.Dominio.Models;
using System;

namespace AS.ProjetoCompleto.Dominio.Interfaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Adicionar(TEntity obj);

        TEntity Atualizar(TEntity obj);

        void Remover(Guid id);

        int SaveChanges();
    }
}
