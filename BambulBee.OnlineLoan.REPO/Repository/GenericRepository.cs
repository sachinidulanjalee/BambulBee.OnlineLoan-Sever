﻿using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.REPOSITORY.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BumbleBee.OnlineLoan.REPOSITORY.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext context;
        private DbSet<T> dbSet;
        private string errorMessage = string.Empty;
        private bool result = false;

        public GenericRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public void AddRange(List<T> entitys)
        {
            try
            {
                if (entitys == null)
                {
                    throw new ArgumentNullException("entity");
                }
                dbSet.AddRange(entitys);
                //entitys.ForEach(x => dbSet.Add(x));
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public void Edit(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault();
        }

        public List<T> GetByValues(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public bool DeleteByPram(Expression<Func<T, bool>> predicate)
        {
            try
            {
                List<T> entitys = dbSet.Where(predicate).ToList();
                if (entitys == null)
                {
                    throw new ArgumentNullException("entity");
                }
                foreach (var item in entitys)
                {
                    dbSet.Attach(item);
                    dbSet.Remove(item);
                }
                return result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public bool BulkDelete(List<T> data)
        {
            try
            {
                dbSet.AttachRange(data);
                dbSet.RemoveRange(data);

                return result = true;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

    }
}
