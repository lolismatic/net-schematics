// <copyright file="IRepository.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>
namespace <%= classify(name) %>.Application.Persistence
{
    using System.Threading.Tasks;

    /// <summary>
    /// The repository interface.
    /// </summary>
    public interface IRepository : IReadOnlyRepository
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        void Create<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        void Update<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        void Delete<TEntity>(object id)
            where TEntity : class;

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <typeparam name="TEntity"> The entity type. </typeparam>
        void Delete<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// The save.
        /// </summary>
        void Save();

        /// <summary>
        /// The save async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SaveAsync();
    }
}