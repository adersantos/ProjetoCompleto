using AS.ProjetoCompleto.Dominio.Interfaces;
using AS.ProjetoCompleto.Dominio.Models;
using AS.ProjetoCompleto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AS.ProjetoCompleto.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {
        //classe abstrata de repositório, genérica que não pode ser implementada sozinha
        //os métodos são virtuais para permitir mudar seus comportamentos, qdo quiser

        protected ProjetoCompletoContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new ProjetoCompletoContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objRet = DbSet.Add(obj);
            SaveChanges();
            return objRet;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();
            return obj;
        }

        public virtual void Remover(Guid id)
        {
            //cria instancia de uma entidade genérica para evitar ir ao banco 2 vezes
            //para encontrar e depois para remover
            var entity = new TEntity { Id = id };

            DbSet.Remove(entity);
            //SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterTodosPaginado(int s, int t)
        {
            return DbSet.Take(t).Skip(s);
        }


        public int SaveChanges()
        {
            return Db.SaveChanges();
        }


        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
