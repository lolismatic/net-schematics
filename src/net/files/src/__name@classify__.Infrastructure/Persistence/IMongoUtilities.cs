// <copyright file="IMongoUtilities.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Infrastructure.Persistence
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MongoDB.Driver;

    /// <summary>
    /// The <see cref="IMongoUtilities"/> interface.
    /// </summary>
    public interface IMongoUtilities
    {
        /// <summary>
        /// The get generic id filter.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns>
        /// The <see cref="FilterDefinition{TEntity}"/>.
        /// </returns>
        FilterDefinition<TEntity> GetGenericIdFilter<TEntity>(object id);

        /// <summary>
        /// The get entity id.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object GetEntityId<TEntity>(TEntity entity);

        /// <summary>
        /// The convert to queryable.
        /// </summary>
        /// <param name="mongoCollection">
        /// The Mongo collection.
        /// </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<TEntity> ConvertToQueryable<TEntity>(IMongoCollection<TEntity> mongoCollection);

        /// <summary>
        /// The sort skip take queryable.
        /// </summary>
        /// <param name="queryable">
        /// The queryable.
        /// </param>
        /// <param name="orderBy">
        /// The order by.
        /// </param>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<TEntity> SortSkipTakeQueryable<TEntity>(
            IQueryable<TEntity> queryable,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null);

        /// <summary>
        /// The filter collection.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<TEntity> FilterCollection<TEntity>(
            IMongoCollection<TEntity> collection,
            Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// The filter collection async.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IQueryable<TEntity>> FilterCollectionAsync<TEntity>(
            IMongoCollection<TEntity> collection,
            Expression<Func<TEntity, bool>> filter);
    }
}
