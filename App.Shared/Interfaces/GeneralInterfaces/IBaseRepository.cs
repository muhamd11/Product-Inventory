﻿using App.Shared.Models.General.LocalModels;
using App.Shared.Models.General.PaginationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Shared.Interfaces.General
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); 

        Task<BaseGetDataWithPagnation<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selection,
                                                                     List<Expression<Func<T, bool>>> criteria = null,
                                                                     PaginationRequest paginationRequest = null,
                                                                     List<Expression<Func<T, object>>> includes = null);

        T FirstOrDefault(Expression<Func<T, bool>> criteria, List<Expression<Func<T, object>>> includes = null);

        Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> criteria,
            Expression<Func<T, TResult>> select, List<Expression<Func<T, object>>> includes = null);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take,
            Expression<Func<T, object>> orderBy = null);

        T Add(T entity);

        Task<T> AddAsync(T entity);

        IEnumerable<T> AddRange(IEnumerable<T> entities);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        T Update(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        void Attach(T entity);

        void AttachRange(IEnumerable<T> entities);

        int Count();

        int Count(Expression<Func<T, bool>> criteria);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<T, bool>> criteria);

        bool Any(Expression<Func<T, bool>> criteria);

        IQueryable<T> AsQueryable();
    }
}