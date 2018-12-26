using Dapper;
using RTMS.Models.AppCore.DataModel.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JQProvider.DataAcess.DataContract
{
    public abstract class DataContractProvider
    {
        public abstract string ConnectionString { get; set; }

        #region Synchronize Functions
        #region QuerySingle
        /// <summary>
        /// Execute Query that returns only single record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"> Name of the Procedure</param>
        /// <param name="parameters"></param>
        /// <returns>Returns a single record </returns>
        public abstract T QuerySingle<T>(string commandName, DynamicParameters parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract int QueryExecuteTransaction(string commandName, DynamicParameters parameters);

        #endregion
        #region QueryList
        /// <summary>
        /// Execute Query that returns a List of data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"> Name of the Procedure</param>
        /// <param name="parameters"></param>
        /// <returns>Returns a  list of  records </returns>
        public abstract IList<T> QueryList<T>(string commandName, DynamicParameters parameters);

        #endregion
        #region Execute data manipulation
        /// <summary>
        ///  Execute  for data manipulation(Insert,Update,Delete). 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"> Name of the Procedure</param>
        /// <param name="parameters"></param>
        /// <returns> </returns>
        public abstract int CommandExecute<T>(string commandName, DynamicParameters parameters);

        /// <summary>
        ///  Execute  for data manipulation(Insert,Update,Delete). 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"> Name of the Procedure</param>
        /// <param name="parameters"></param>
        /// <returns> </returns>
        public abstract int CommandExecuteMutipleRow<T>(string commandName, List<DynamicParameters> parameters);

        #endregion
        #region Scalar Value Function
        /// <summary>
        /// Execute  sql  Scalar value  Function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"> Name of the Sql Function</param>
        /// <param name="parameters"></param>
        /// <returns>Returns a Scalar value</returns>
        public abstract T ExecuteScalarFunc<T>(string commandName, DynamicParameters parameters);

        #endregion
        #region Table Valued Function
        /// <summary>
        /// Execute  Table-valued sql Function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"> Name of the Sql function</param>
        /// <param name="parameters"></param>
        /// <returns>Returns a  list of  records </returns>
        public abstract IList<T> ExecuteTableFunc<T>(string commandName, DynamicParameters parameters);

        #endregion
        #endregion
        #region Asynchronize Functions
        #region QuerySingleAsync
        /// <summary>
        /// Execute Async query that returns only single record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"> Name of the Procedure</param>
        /// <param name="parameters"></param>
        /// <returns>Returns a single Record </returns>
        public abstract Task<T> QuerySingleAsync<T>(string commandName, DynamicParameters parameters);

        #endregion
        #region QueryListAsync
        /// <summary>
        /// Execute Async query that returns a List of data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"> Name of the Procedure</param>
        /// <param name="parameters"></param>
        /// <returns>Returns a  list of  records </returns>
        public abstract Task<IList<T>> QueryListAsync<T>(string commandName, DynamicParameters parameters);

        #endregion
        #region Async for data manipulation
        /// <summary>
        /// Execute Async data manipulation. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"> Name of the Procedure</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract Task<int> CommandExecuteAsync<T>(string commandName, DynamicParameters parameters);

        #endregion
        #endregion
        #region MultiQueryDB
        #region MultiSetQuery
        /// <summary>
        /// conn.QueryMultipleAsync("select 1; select 2").Result
        /// </summary>
        /// <param name="commandName"></param>
        /// <param name="parameters"></param>
        public abstract DynamicMutipleSetModel<T, K> QueryMultipleSetAsync<T, K>(string commandName, DynamicParameters parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <param name="commandName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract DynamicMutipleSetModel<K, M, N> QueryMultipleSetAsync<K, M, N>(string commandName, DynamicParameters parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="N"></typeparam>
        /// <typeparam name="O"></typeparam>
        /// <typeparam name="P"></typeparam>
        /// <typeparam name="Q"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="commandName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract DynamicMutipleSetModel<M, N, O, P, Q, R> QueryMultipleSetAsync<M, N, O, P, Q, R>(string commandName, DynamicParameters parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="commandName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract DynamicMutipleModel<T, K> QueryMultipleAsync<T, K>(string commandName, DynamicParameters parameters);

        #endregion
        #region MultiLevelQueryDB 
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandName"></param>
        /// <param name="parameters"></param>
        /// <param name="mapperIdentifiers"></param>
        /// <returns></returns>
        public abstract T QueryMultipleLevel<T>(string commandName, DynamicParameters parameters, List<MapperConfigurationIdentifiersSP> mapperIdentifiers);

        #endregion
        #endregion
    }
}
