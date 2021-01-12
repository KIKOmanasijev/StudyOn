using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Court.Contracts
{
    /// <summary>
    /// </summary>
    public interface IContext : IDisposable
    {
        /// <summary>B
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> AsQueryable<T>() where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        void Insert<T>(T item) where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        void Insert<T>(IEnumerable<T> items) where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        void Update<T>(IEntity<T> item) where T : class;


        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        void UpdateTranslate<T>(IEntity<T> item) where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        void UpdateAsync<T>(IEntity<T> item) where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TField"></typeparam>
        void UpdateMany<T, TField>(Expression<Func<T, bool>> expression, Expression<Func<T, TField>> field, TField value)
            where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TField"></typeparam>
        /// <param name="expression"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        void UpdateManyAsync<T, TField>(Expression<Func<T, bool>> expression, Expression<Func<T, TField>> field, TField value) where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        void Delete<T>(IEntity<T> item) where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <param name="exp"></param>
        /// <typeparam name="T"></typeparam>
        void Delete<T>(Expression<Func<T, bool>> exp) where T : class;

        /// <summary>
        /// Deletes Multiple items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        void Delete<T>(IEnumerable<IEntity<T>> items) where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <param name="exp"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> FindItems<T>(Expression<Func<T, bool>> exp) where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp"></param>
        /// <returns></returns>
        long Count<T>(Expression<Func<T, bool>> exp) where T : class;

        /// <summary>
        ///
        /// </summary>
        /// <param name="exp"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>(Expression<Func<T, bool>> exp) where T : class;


        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IList<T> AllItems<T>() where T : class;

        /// <summary>
        /// Update multiple items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        void UpdateMultiple<T>(IEnumerable<T> items) where T : class, IEntity<string>;

        List<T> ExecuteDbFunction<T>(string functionName, Dictionary<string, object> parametarts) where T : class, new();
        List<T> ExecuteDbQuery<T>(string query, Dictionary<string, object> parametarts) where T : class, new();
        /// <summary>
        /// Change database connection string in runtime
        /// </summary>
        /// <param name="connection"></param> connection name of the target database
        void ChangeDatabase(string connection);
    }
}
