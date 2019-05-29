// <copyright file="IReadOnlyRepository.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Application.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// The ReadOnlyRepository interface.
    /// </summary>
    public interface IReadOnlyRepository
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="orderBy"> The order by. </param>
        /// <param name="skip"> The skip. </param>
        /// <param name="take"> The take. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="T:IEnumerable"/>. </returns>
        IEnumerable<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        /// <summary>
        /// The get all async.
        /// </summary>
        /// <param name="orderBy"> The order by. </param>
        /// <param name="skip"> The skip. </param>
        /// <param name="take"> The take. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="Task"/>. </returns>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <param name="orderBy"> The order by. </param>
        /// <param name="skip"> The skip. </param>
        /// <param name="take"> The take. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="T:IEnumerable"/>. </returns>
        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        /// <summary>
        /// The get async.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <param name="orderBy"> The order by. </param>
        /// <param name="skip"> The skip. </param>
        /// <param name="take"> The take. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="Task"/>. </returns>
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class;

        /// <summary>
        /// The get one.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="T:TEntity"/>. </returns>
        TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// The get one async.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="Task"/>. </returns>
        Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// The get first.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <param name="orderBy"> The order by. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="T:TEntity"/>. </returns>
        TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            where TEntity : class;

        /// <summary>
        /// The get first async.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <param name="orderBy"> The order by. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="Task"/>. </returns>
        Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            where TEntity : class;

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="T:TEntity"/>. </returns>
        TEntity GetById<TEntity>(object id)
            where TEntity : class;

        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="Task"/>. </returns>
        Task<TEntity> GetByIdAsync<TEntity>(object id)
            where TEntity : class;

        /// <summary>
        /// The get count.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <typeparam name="TEntity"> The entity type.
        /// </typeparam>
        /// <returns> The <see cref="int"/>. </returns>
        long GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// The get count async.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="Task"/>. </returns>
        Task<long> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// The get exists.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="bool"/>. </returns>
        bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;

        /// <summary>
        /// The get exists async.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns> The <see cref="Task"/>. </returns>
        Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;
    }

    /// <summary>
    /// The entity interface.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the Id.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the date of creation.
        /// </summary>
        DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the date of the last update.
        /// </summary>
        DateTime ModifiedAt { get; }
    }
}