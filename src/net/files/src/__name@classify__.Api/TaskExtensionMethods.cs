// <copyright file="TaskExtensionMethods.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Api
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The task extension methods.
    /// </summary>
    internal static class TaskExtensionMethods
    {
        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <param name="third"> The third. </param>
        /// <param name="forth"> The forth. </param>
        /// <param name="fifth"> The fifth. </param>
        /// <param name="sixth"> The sixth. </param>
        /// <param name="seventh"> The seventh. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="T3"> The 3th type. </typeparam>
        /// <typeparam name="T4"> The 4th type. </typeparam>
        /// <typeparam name="T5"> The 5th type. </typeparam>
        /// <typeparam name="T6"> The 6th type. </typeparam>
        /// <typeparam name="T7"> The 7th type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<IActionResult> Switch<S, T, T2, T3, T4, T5, T6, T7>(
            this Task<S> task,
            Expression<Func<S, IActionResult>> source,
            Expression<Func<T, IActionResult>> first,
            Expression<Func<T2, IActionResult>> second,
            Expression<Func<T3, IActionResult>> third,
            Expression<Func<T4, IActionResult>> forth,
            Expression<Func<T5, IActionResult>> fifth,
            Expression<Func<T6, IActionResult>> sixth,
            Expression<Func<T7, IActionResult>> seventh)
        {
            return await task.Switch<S, IActionResult>(new LambdaExpression[] { source, first, second, third, forth, fifth, sixth, seventh });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <param name="third"> The third. </param>
        /// <param name="forth"> The forth. </param>
        /// <param name="fifth"> The fifth. </param>
        /// <param name="sixth"> The sixth. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="T3"> The 3th type. </typeparam>
        /// <typeparam name="T4"> The 4th type. </typeparam>
        /// <typeparam name="T5"> The 5th type. </typeparam>
        /// <typeparam name="T6"> The 6th type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<IActionResult> Switch<S, T, T2, T3, T4, T5, T6>(
            this Task<S> task,
            Expression<Func<S, IActionResult>> source,
            Expression<Func<T, IActionResult>> first,
            Expression<Func<T2, IActionResult>> second,
            Expression<Func<T3, IActionResult>> third,
            Expression<Func<T4, IActionResult>> forth,
            Expression<Func<T5, IActionResult>> fifth,
            Expression<Func<T6, IActionResult>> sixth)
        {
            return await task.Switch<S, IActionResult>(new LambdaExpression[] { source, first, second, third, forth, fifth, sixth });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <param name="third"> The third. </param>
        /// <param name="forth"> The forth. </param>
        /// <param name="fifth"> The fifth. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="T3"> The 3th type. </typeparam>
        /// <typeparam name="T4"> The 4th type. </typeparam>
        /// <typeparam name="T5"> The 5th type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<IActionResult> Switch<S, T, T2, T3, T4, T5>(
            this Task<S> task,
            Expression<Func<S, IActionResult>> source,
            Expression<Func<T, IActionResult>> first,
            Expression<Func<T2, IActionResult>> second,
            Expression<Func<T3, IActionResult>> third,
            Expression<Func<T4, IActionResult>> forth,
            Expression<Func<T5, IActionResult>> fifth)
        {
            return await task.Switch<S, IActionResult>(new LambdaExpression[] { source, first, second, third, forth, fifth });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <param name="third"> The third. </param>
        /// <param name="forth"> The forth. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="T3"> The 3th type. </typeparam>
        /// <typeparam name="T4"> The 4th type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<IActionResult> Switch<S, T, T2, T3, T4>(
            this Task<S> task,
            Expression<Func<S, IActionResult>> source,
            Expression<Func<T, IActionResult>> first,
            Expression<Func<T2, IActionResult>> second,
            Expression<Func<T3, IActionResult>> third,
            Expression<Func<T4, IActionResult>> forth)
        {
            return await task.Switch<S, IActionResult>(new LambdaExpression[] { source, first, second, third, forth });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <param name="third"> The third. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="T3"> The 3th type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<IActionResult> Switch<S, T, T2, T3>(
            this Task<S> task,
            Expression<Func<S, IActionResult>> source,
            Expression<Func<T, IActionResult>> first,
            Expression<Func<T2, IActionResult>> second,
            Expression<Func<T3, IActionResult>> third)
        {
            return await task.Switch<S, IActionResult>(new LambdaExpression[] { source, first, second, third });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<IActionResult> Switch<S, T, T2>(
            this Task<S> task,
            Expression<Func<S, IActionResult>> source,
            Expression<Func<T, IActionResult>> first,
            Expression<Func<T2, IActionResult>> second)
        {
            return await task.Switch<S, IActionResult>(new LambdaExpression[] { source, first, second });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<IActionResult> Switch<S, T>(
            this Task<S> task,
            Expression<Func<S, IActionResult>> source,
            Expression<Func<T, IActionResult>> first)
        {
            return await task.Switch<S, IActionResult>(new LambdaExpression[] { source, first });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<IActionResult> Switch<S, T>(
            this Task<S> task,
            Expression<Func<S, IActionResult>> source)
        {
            return await task.Switch<S, IActionResult>(new LambdaExpression[] { source });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <param name="third"> The third. </param>
        /// <param name="forth"> The forth. </param>
        /// <param name="fifth"> The fifth. </param>
        /// <param name="sixth"> The sixth. </param>
        /// <param name="seventh"> The seventh. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="T3"> The 3th type. </typeparam>
        /// <typeparam name="T4"> The 4th type. </typeparam>
        /// <typeparam name="T5"> The 5th type. </typeparam>
        /// <typeparam name="T6"> The 6th type. </typeparam>
        /// <typeparam name="T7"> The 7th type. </typeparam>
        /// <typeparam name="R"> The return type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<R> Switch<S, T, T2, T3, T4, T5, T6, T7, R>(
            this Task<S> task,
            Expression<Func<S, R>> source,
            Expression<Func<T, R>> first,
            Expression<Func<T2, R>> second,
            Expression<Func<T3, R>> third,
            Expression<Func<T4, R>> forth,
            Expression<Func<T5, R>> fifth,
            Expression<Func<T6, R>> sixth,
            Expression<Func<T7, R>> seventh)
        {
            return await task.Switch<S, R>(new LambdaExpression[] { source, first, second, third, forth, fifth, sixth, seventh });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <param name="third"> The third. </param>
        /// <param name="forth"> The forth. </param>
        /// <param name="fifth"> The fifth. </param>
        /// <param name="sixth"> The sixth. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="T3"> The 3th type. </typeparam>
        /// <typeparam name="T4"> The 4th type. </typeparam>
        /// <typeparam name="T5"> The 5th type. </typeparam>
        /// <typeparam name="T6"> The 6th type. </typeparam>
        /// <typeparam name="R"> The return type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<R> Switch<S, T, T2, T3, T4, T5, T6, R>(
            this Task<S> task,
            Expression<Func<S, R>> source,
            Expression<Func<T, R>> first,
            Expression<Func<T2, R>> second,
            Expression<Func<T3, R>> third,
            Expression<Func<T4, R>> forth,
            Expression<Func<T5, R>> fifth,
            Expression<Func<T6, R>> sixth)
        {
            return await task.Switch<S, R>(new LambdaExpression[] { source, first, second, third, forth, fifth, sixth });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <param name="third"> The third. </param>
        /// <param name="forth"> The forth. </param>
        /// <param name="fifth"> The fifth. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="T3"> The 3th type. </typeparam>
        /// <typeparam name="T4"> The 4th type. </typeparam>
        /// <typeparam name="T5"> The 5th type. </typeparam>
        /// <typeparam name="R"> The return type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<R> Switch<S, T, T2, T3, T4, T5, R>(
            this Task<S> task,
            Expression<Func<S, R>> source,
            Expression<Func<T, R>> first,
            Expression<Func<T2, R>> second,
            Expression<Func<T3, R>> third,
            Expression<Func<T4, R>> forth,
            Expression<Func<T5, R>> fifth)
        {
            return await task.Switch<S, R>(new LambdaExpression[] { source, first, second, third, forth, fifth });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <param name="third"> The third. </param>
        /// <param name="forth"> The forth. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="T3"> The 3th type. </typeparam>
        /// <typeparam name="T4"> The 4th type. </typeparam>
        /// <typeparam name="R"> The return type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<R> Switch<S, T, T2, T3, T4, R>(
            this Task<S> task,
            Expression<Func<S, R>> source,
            Expression<Func<T, R>> first,
            Expression<Func<T2, R>> second,
            Expression<Func<T3, R>> third,
            Expression<Func<T4, R>> forth)
        {
            return await task.Switch<S, R>(new LambdaExpression[] { source, first, second, third, forth });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <param name="third"> The third. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="T3"> The 3th type. </typeparam>
        /// <typeparam name="R"> The return type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<R> Switch<S, T, T2, T3, R>(
            this Task<S> task,
            Expression<Func<S, R>> source,
            Expression<Func<T, R>> first,
            Expression<Func<T2, R>> second,
            Expression<Func<T3, R>> third)
        {
            return await task.Switch<S, R>(new LambdaExpression[] { source, first, second, third });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <param name="second"> The second. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="T2"> The 2th type. </typeparam>
        /// <typeparam name="R"> The return type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<R> Switch<S, T, T2, R>(
            this Task<S> task,
            Expression<Func<S, R>> source,
            Expression<Func<T, R>> first,
            Expression<Func<T2, R>> second)
        {
            return await task.Switch<S, R>(new LambdaExpression[] { source, first, second });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <param name="first"> The first. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="R"> The return type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<R> Switch<S, T, R>(
            this Task<S> task,
            Expression<Func<S, R>> source,
            Expression<Func<T, R>> first)
        {
            return await task.Switch<S, R>(new LambdaExpression[] { source, first });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task"> The task. </param>
        /// <param name="source"> The source. </param>
        /// <typeparam name="S"> The source type. </typeparam>
        /// <typeparam name="T"> The 1th type. </typeparam>
        /// <typeparam name="R"> The return type. </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<R> Switch<S, T, R>(
            this Task<S> task,
            Expression<Func<S, R>> source)
        {
            return await task.Switch<S, R>(new LambdaExpression[] { source });
        }

        /// <summary>
        /// The switch.
        /// </summary>
        /// <param name="task">
        /// The task.
        /// </param>
        /// <param name="patterns">
        /// The patterns.
        /// </param>
        /// <typeparam name="S">
        /// The source type.
        /// </typeparam>
        /// <typeparam name="R">
        /// The return type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private static async Task<R> Switch<S, R>(
            this Task<S> task,
            LambdaExpression[] patterns)
        {
            var value = await task;

            return (R)patterns
                .First(pattern => pattern.Parameters[0].Type.IsInstanceOfType(value))
                .Compile()
                .DynamicInvoke(value);
        }
     }
}
