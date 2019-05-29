// <copyright file="MongoReadOnlyRepository.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Infrastructure.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using <%= classify(name) %>.Application.Persistence;

    /// <summary>
    /// The MongoDB repository.
    /// </summary>
    public class MongoReadOnlyRepository : IReadOnlyRepository
    {
        /// <summary>
        /// The Mongo database.
        /// </summary>
        protected readonly IMongoDatabase MongoDatabase;

        /// <summary>
        /// The Mongo utilities.
        /// </summary>
        protected readonly IMongoUtilities MongoUtilities;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoReadOnlyRepository"/> class.
        /// </summary>
        /// <param name="mongoDatabase">
        /// The MongoDB database.
        /// </param>
        /// <param name="mongoUtilities">
        /// The mongo Utilities.
        /// </param>
        public MongoReadOnlyRepository(IMongoDatabase mongoDatabase, IMongoUtilities mongoUtilities)
        {
            this.MongoDatabase = mongoDatabase
                ?? throw new ArgumentNullException(nameof(mongoDatabase));

            this.MongoUtilities = mongoUtilities
                ?? throw new ArgumentNullException(nameof(mongoUtilities));

        }

        /// <summary>
        /// Gets entities from the database.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="filter"> The optional filter criteria. </param>
        /// <param name="orderBy"> The optional order criteria. </param>
        /// <param name="skip"> The optional skipped amount. </param>
        /// <param name="take"> The optional taken amount. </param>
        /// <returns> The <see cref="IEnumerable{TEntity}"/> corresponding to the parameters. </returns>
        public IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();

            var queryResult = filter == null
                ? this.MongoUtilities.ConvertToQueryable(collection)
                : this.MongoUtilities.FilterCollection(collection, filter);

            return this.MongoUtilities.SortSkipTakeQueryable(queryResult, orderBy, skip, take);
        }

        /// <summary>
        /// Gets all entities of a specified type from the database.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="orderBy"> The optional order criteria. </param>
        /// <param name="skip"> The optional skipped amount. </param>
        /// <param name="take"> The optional taken amount. </param>
        /// <returns> The <see cref="IEnumerable{TEntity}"/>. </returns>
        public IEnumerable<TEntity> GetAll<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();

            var queryResult = this.MongoUtilities.ConvertToQueryable(collection);

            return this.MongoUtilities.SortSkipTakeQueryable(queryResult, orderBy, skip, take);
        }

        /// <summary>
        /// Gets asynchronously all entities of a specified type from the database.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="orderBy"> The optional order criteria. </param>
        /// <param name="skip"> The optional skipped amount. </param>
        /// <param name="take"> The optional taken amount. </param>
        /// <returns> The <see cref="Task{IEnumerable}"/>. </returns>
        public Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            return Task.FromResult(this.GetAll(orderBy, skip, take));
        }

        /// <summary>
        /// Gets asynchronously entities from the database.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="filter"> The optional filter criteria. </param>
        /// <param name="orderBy"> The optional order criteria. </param>
        /// <param name="skip"> The optional skipped amount. </param>
        /// <param name="take"> The optional taken amount. </param>
        /// <returns> The <see cref="Task{IEnumerable}"/> corresponding to the parameters. </returns>
        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();

            var queryResult = filter == null
                ? this.MongoUtilities.ConvertToQueryable(collection)
                : await this.MongoUtilities.FilterCollectionAsync(collection, filter);

            return this.MongoUtilities.SortSkipTakeQueryable(queryResult, orderBy, skip, take).AsEnumerable();
        }

        /// <summary>
        /// Gets an entity.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="id"> The id. </param>
        /// <returns> The entity. </returns>
        public TEntity GetById<TEntity>(object id)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();
            var filter = this.MongoUtilities.GetGenericIdFilter<TEntity>(id);

            return collection.Find(filter).SingleOrDefault();
        }

        /// <summary>
        /// Gets an entity asynchronously.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="id"> The id. </param>
        /// <returns> The entity. </returns>
        public async Task<TEntity> GetByIdAsync<TEntity>(object id)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();
            var filter = this.MongoUtilities.GetGenericIdFilter<TEntity>(id);

            return (await collection.FindAsync(filter)).SingleOrDefault();
        }

        /// <summary>
        /// Gets the count of a collection.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="filter"> The optional filter criteria. </param>
        /// <returns> The count. </returns>
        public long GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();

            return filter == null
                ? collection.CountDocuments((_) => true)
                : collection.CountDocuments(filter);
        }

        /// <summary>
        /// Gets the count of a collection asynchronously.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="filter"> The optional filter criteria. </param>
        /// <returns> The count. </returns>
        public async Task<long> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();

            return await (filter == null
                ? collection.CountDocumentsAsync((_) => true)
                : collection.CountDocumentsAsync(filter));
        }

        /// <summary>
        /// Checks the existence of an entity.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="filter"> The optional filter criteria. </param>
        /// <returns> The result of the existence check. </returns>
        public bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();

            return (filter == null
                ? collection.Find((_) => true)
                : collection.Find(filter)).Any();
        }

        /// <summary>
        /// Checks asynchronously the existence of an entity.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="filter"> The optional filter criteria. </param>
        /// <returns> The result of the existence check. </returns>
        public async Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();
            var filterResult = await (filter == null
                ? collection.FindAsync((_) => true)
                : collection.FindAsync(filter));

            return filterResult.Any();
        }

        /// <summary>
        /// Gets the first matching entity.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="filter"> The optional filter criteria. </param>
        /// <param name="orderBy"> The optional order criteria. </param>
        /// <returns> The entity. </returns>
        public TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();

            return collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Gets asynchronously the first matching entity.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="filter"> The optional filter criteria. </param>
        /// <param name="orderBy"> The optional order criteria. </param>
        /// <returns> The entity. </returns>
        public async Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();

            return (await collection.FindAsync(filter)).FirstOrDefault();
        }

        /// <summary>
        /// Gets one matching entity.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="filter"> The optional filter criteria. </param>
        /// <returns> The entity. </returns>
        public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();

            return collection.Find(filter).SingleOrDefault();
        }

        /// <summary>
        /// Gets asynchronously one matching entity.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <param name="filter"> The optional filter criteria. </param>
        /// <returns> The entity. </returns>
        public async Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class
        {
            var collection = this.GetCollection<TEntity>();

            return (await collection.FindAsync(filter)).SingleOrDefault();
        }

        /// <summary>
        /// The get collection.
        /// </summary>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        /// <returns>
        /// The <see cref="IMongoCollection{TEntity}"/>.
        /// </returns>
        protected IMongoCollection<TEntity> GetCollection<TEntity>()
            => this.MongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
    }
}