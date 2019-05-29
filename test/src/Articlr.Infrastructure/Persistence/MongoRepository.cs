// <copyright file="MongoRepository.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace Articlr.Infrastructure.Persistence
{
    using System;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using Articlr.Application.Persistence;

    /// <summary>
    /// The MongoDB repository.
    /// </summary>
    public class MongoRepository : MongoReadOnlyRepository, IRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoRepository"/> class.
        /// </summary>
        /// <param name="mongoDatabase"> The MongoDB database. </param>
        /// <param name="mongoUtilities"> The Mongo utility service. </param>
        public MongoRepository(IMongoDatabase mongoDatabase, IMongoUtilities mongoUtilities)
            : base(mongoDatabase, mongoUtilities)
        {
        }

        /// <summary>
        /// Creates a new entity in the database.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="entity"> The entity. </param>
        public void Create<TEntity>(TEntity entity)
            where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var collection = this.GetCollection<TEntity>();

            collection.InsertOne(entity);
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="id"> The entity id. </param>
        public void Delete<TEntity>(object id)
            where TEntity : class
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var collection = this.GetCollection<TEntity>();
            var filter = this.MongoUtilities.GetGenericIdFilter<TEntity>(id);

            collection.DeleteOne(filter);
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="entity"> The entity. </param>
        public void Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var collection = this.GetCollection<TEntity>();
            var id = this.MongoUtilities.GetEntityId(entity);

            if (id == null)
            {
                throw new ArgumentNullException();
            }

            var filter = this.MongoUtilities.GetGenericIdFilter<TEntity>(id);

            collection.DeleteOne(filter);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        [Obsolete("Not supported by MongoDB.")]
        public void Save()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Saves the changes asynchronously.
        /// </summary>
        /// <returns> Empty task. </returns>
        [Obsolete("Not supported by MongoDB.")]
        public Task SaveAsync()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="entity"> The entity. </param>
        public void Update<TEntity>(TEntity entity)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();
            var id = this.MongoUtilities.GetEntityId(entity);
            var filter = this.MongoUtilities.GetGenericIdFilter<TEntity>(id);

            collection.ReplaceOne(filter, entity);
        }
    }
}
