using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        //classes estão virtuais para poder dar overrride
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>(); 
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            // Db.Set<TEntity>().Add(entity); método sem o readonly
            DbSet.Add(entity);
            await SaveChances();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChances();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            //asnotracking melhora perfomance
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync(); 
            //ir até o banco, onde a expressão passada retorna uma lista assincrona
            //await espera o resultado
        }

        public virtual async Task<TEntity> ObterPorID(Guid id)
        {
            return await DbSet.FindAsync(id); //busca por id
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync(); //retorna todos pq é sem parâmetro
        }

        public virtual async Task Remover(Guid id)
        {
            //poderia usar também new TEntity{ Id = id});
            DbSet.Remove(await ObterPorID(id)); 
            //usando método para achar o objeto por id ou poderia usar DbSet.FindAsync(id)
            await SaveChances();
        }

        public async Task<int> SaveChances()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
