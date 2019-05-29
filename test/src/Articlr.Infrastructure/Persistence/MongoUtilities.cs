// <copyright file="MongoUtilities.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace Articlr.Infrastructure.Persistence
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    /// <summary>
    /// The mongo utilities.
    /// </summary>
    internal class MongoUtilities : IMongoUtilities
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
        public FilterDefinition<TEntity> GetGenericIdFilter<TEntity>(object id) =>
            Builders<TEntity>.Filter.Eq("_id", id);

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
        public object GetEntityId<TEntity>(TEntity entity) =>
            BsonClassMap.LookupClassMap(typeof(TEntity)).IdMemberMap.Getter(entity);

        /// <summary>
        /// The convert to queryable.
        /// </summary>
        /// <param name="mongoCollection">
        /// The mongo collection.
        /// </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<TEntity> ConvertToQueryable<TEntity>(IMongoCollection<TEntity> mongoCollection) =>
            mongoCollection.AsQueryable();

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
        public IQueryable<TEntity> SortSkipTakeQueryable<TEntity>(
            IQueryable<TEntity> queryable,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
        {
            if (orderBy != null)
            {
                queryable = orderBy(queryable);
            }

            if (skip.HasValue)
            {
                queryable = queryable.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                queryable = queryable.Take(take.Value);
            }

            return queryable;
        }

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
        public IQueryable<TEntity> FilterCollection<TEntity>(
            IMongoCollection<TEntity> collection,
            Expression<Func<TEntity, bool>> filter)
            => collection.Find(filter).ToEnumerable().AsQueryable();

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
        public async Task<IQueryable<TEntity>> FilterCollectionAsync<TEntity>(
            IMongoCollection<TEntity> collection,
            Expression<Func<TEntity, bool>> filter)
            => (await collection.FindAsync(filter)).ToEnumerable().AsQueryable();
    }
}
