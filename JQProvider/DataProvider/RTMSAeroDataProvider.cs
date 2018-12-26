using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JQProvider.DataAcess.DataContract;
using JQProvider.DataAcess.Factory;
using JQProvider.DataAcess.Models;

namespace JQProvider.DataAcess.DataProvider
{
    public partial class JQDataProvider
    {
        protected class RTMSAeroDataProvider: DataContractProvider
        {
            public override string ConnectionString { get; set; }
            private IDbTransaction transaction = null;
            private const int commandTimeout = 6000;
            #region Synchronize Functions
            #region QuerySingle
            /// <summary>
            /// Execute Query that returns only single record.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="commandName"> Name of the Procedure</param>
            /// <param name="parameters"></param>
            /// <returns>Returns a single record </returns>
            public T QuerySingle<T>(string commandName, DynamicParameters parameters)
            {
                try
                {
                    using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                    {
                        return connection.QueryFirstOrDefault<T>(commandName, parameters, commandType: CommandType.StoredProcedure);
                    }
                }
                catch

                {
                    throw;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="commandName"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            public int QueryExecuteTransaction(string commandName, DynamicParameters parameters)
            {
                try
                {
                    using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                    {
                        using (transaction = connection.BeginTransaction())
                        {
                            connection.Execute(commandName, parameters,transaction: transaction,commandTimeout: commandTimeout, commandType: CommandType.StoredProcedure);
                            transaction.Commit();
                            return 1;
                        }
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    transaction.Dispose();
                }

            }
            #endregion
            #region QueryList
            /// <summary>
            /// Execute Query that returns a List of data.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="commandName"> Name of the Procedure</param>
            /// <param name="parameters"></param>
            /// <returns>Returns a  list of  records </returns>
            public IList<T> QueryList<T>(string commandName, DynamicParameters parameters)
            {
                try
                {
                    using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                    {
                        var dResult = connection.Query<T>(commandName, parameters, commandType: CommandType.StoredProcedure);
                        return dResult.ToList();
                    }
                }
                catch
                {
                    throw;
                }
            }
            #endregion
            #region Execute data manipulation
            /// <summary>
            ///  Execute  for data manipulation(Insert,Update,Delete). 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="commandName"> Name of the Procedure</param>
            /// <param name="parameters"></param>
            /// <returns> </returns>
            public int CommandExecute<T>(string commandName, DynamicParameters parameters)
            {
                try
                {
                    using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                    {
                        int dResult = connection.Execute(commandName, parameters, commandType: CommandType.StoredProcedure);
                        return dResult;
                    }
                }
                catch
                {
                    throw;
                }
            }
            /// <summary>
            ///  Execute  for data manipulation(Insert,Update,Delete). 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="commandName"> Name of the Procedure</param>
            /// <param name="parameters"></param>
            /// <returns> </returns>
            public int CommandExecuteMutipleRow<T>(string commandName, List<DynamicParameters> parameters)
            {
                try
                {
                    using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                    {
                        //int totalRowResult=0;
                        //foreach (var item in parameters)
                        //{
                        //    int dResult = connection.Execute(commandName, item, commandType: CommandType.StoredProcedure);
                        //    totalRowResult = totalRowResult + dResult;
                        //}
                        int dResult = connection.Execute(commandName, parameters, commandType: CommandType.StoredProcedure);
                        return dResult;
                    }
                }
                catch
                {
                    throw;
                }
            }
            #endregion
            #region Scalar Value Function
            /// <summary>
            /// Execute  sql  Scalar value  Function.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="commandName"> Name of the Sql Function</param>
            /// <param name="parameters"></param>
            /// <returns>Returns a Scalar value</returns>
            public T ExecuteScalarFunc<T>(string commandName, DynamicParameters parameters)
            {
                try
                {
                    string sql = "select " + commandName;
                    using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                    {
                        return connection.ExecuteScalar<T>(sql, parameters);
                    }
                }
                catch
                {
                    throw;
                }
            }
            #endregion
            #region Table Valued Function
            /// <summary>
            /// Execute  Table-valued sql Function.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="commandName"> Name of the Sql function</param>
            /// <param name="parameters"></param>
            /// <returns>Returns a  list of  records </returns>
            public IList<T> ExecuteTableFunc<T>(string commandName, DynamicParameters parameters)
            {
                try
                {
                    string sql = "select * from " + commandName;
                    using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                    {
                        return connection.Query<T>(sql, parameters).ToList();
                    }

                }
                catch
                {
                    throw;
                }
            }
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
            public async Task<T> QuerySingleAsync<T>(string commandName, DynamicParameters parameters)
            {
                try
                {
                    using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                    {
                        return await connection.QueryFirstOrDefaultAsync<T>(commandName, parameters, commandType: CommandType.StoredProcedure);
                    }
                }
                catch
                {
                    throw;
                }
            }
            #endregion
            #region QueryListAsync
            /// <summary>
            /// Execute Async query that returns a List of data.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="commandName"> Name of the Procedure</param>
            /// <param name="parameters"></param>
            /// <returns>Returns a  list of  records </returns>
            public async Task<IList<T>> QueryListAsync<T>(string commandName, DynamicParameters parameters)
            {
                try
                {
                    using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                    {
                        var dResult = await connection.QueryAsync<T>(commandName, parameters, commandType: CommandType.StoredProcedure);
                        return dResult.ToList();
                    }
                }
                catch
                {
                    throw;
                }
            }
            #endregion
            #region Async for data manipulation
            /// <summary>
            /// Execute Async data manipulation. 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="commandName"> Name of the Procedure</param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            public async Task<int> CommandExecuteAsync<T>(string commandName, DynamicParameters parameters)
            {
                try
                {
                    using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                    {
                        int dResult = await connection.ExecuteAsync(commandName, parameters, commandType: CommandType.StoredProcedure);
                        return dResult;
                    }
                }
                catch
                {
                    throw;
                }
            }
            #endregion
            #endregion
            #region MultiQueryDB
            #region MultiSetQuery
            /// <summary>
            /// conn.QueryMultipleAsync("select 1; select 2").Result
            /// </summary>
            /// <param name="commandName"></param>
            /// <param name="parameters"></param>
            public DynamicMutipleSetModel<T,K> QueryMultipleSetAsync<T, K>(string commandName, DynamicParameters parameters)
            {
                using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                {
                    using (Dapper.SqlMapper.GridReader multi = connection.QueryMultipleAsync(commandName, parameters, commandType: CommandType.StoredProcedure).Result)
                    {
                        List<T> resultSetT = multi.ReadAsync<T>().Result.ToList();
                        List<K> resultSetK = multi.ReadAsync<K>().Result.ToList();
                        return new DynamicMutipleSetModel<T, K>() { DynamicListResultSetT = resultSetT, DynamicListResultSetK = resultSetK };
                    }
                }
            }
            public DynamicMutipleSetModel<K,M,N> QueryMultipleSetAsync<K,M,N>(string commandName, DynamicParameters parameters)
            {
                using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                {
                    using (Dapper.SqlMapper.GridReader multi = connection.QueryMultipleAsync(commandName, parameters, commandType: CommandType.StoredProcedure).Result)
                    {
                        
                        List<K> resultSetK = multi.ReadAsync<K>().Result.ToList();
                        List<M> resultSetM = multi.ReadAsync<M>().Result.ToList();
                        List<N> resultSetN = multi.ReadAsync<N>().Result.ToList();
                        return new DynamicMutipleSetModel<K,M,N>() {
                            DynamicListResultSetK = resultSetK,
                            DynamicListResultSetM = resultSetM,
                             DynamicListResultSetN = resultSetN
                        };
                    }
                }
            }
       
            public DynamicMutipleSetModel<M,N,O,P,Q,R> QueryMultipleSetAsync<M,N,O,P,Q,R>(string commandName, DynamicParameters parameters)
            {
                using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                {
                    using (Dapper.SqlMapper.GridReader multi = connection.QueryMultipleAsync(commandName, parameters, commandType: CommandType.StoredProcedure).Result)
                    {
                      
                      
                        List<M> resultSetM = multi.ReadAsync<M>().Result.ToList();
                        List<N> resultSetN = multi.ReadAsync<N>().Result.ToList();
                        List<O> resultSetO = multi.ReadAsync<O>().Result.ToList();
                        List<P> resultSetP = multi.ReadAsync<P>().Result.ToList();
                        List<Q> resultSetQ = multi.ReadAsync<Q>().Result.ToList();
                        List<R> resultSetR = multi.ReadAsync<R>().Result.ToList();
                        return new DynamicMutipleSetModel<M,N,O,P,Q,R>()
                        { 
                          DynamicListResultSetM = resultSetM,DynamicListResultSetN = resultSetN,
                          DynamicListResultSetO = resultSetO,DynamicListResultSetP = resultSetP,
                          DynamicListResultSetQ = resultSetQ,
                            DynamicListResultSetR = resultSetR,
                        };
                    }
                }
            }
            public DynamicMutipleModel<T, K> QueryMultipleAsync<T, K>(string commandName, DynamicParameters parameters)
            {
                using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                {
                    using (Dapper.SqlMapper.GridReader multi = connection.QueryMultipleAsync(commandName, parameters, commandType: CommandType.StoredProcedure).Result)
                    {
                        T resultSetT = multi.ReadFirst<T>();
                        K resultSetK = multi.ReadFirst<K>();
                       
                        return new DynamicMutipleModel<T, K>() { DynamicResultT = resultSetT, DynamicResultK = resultSetK };
                    }
                }
            }

          
            #endregion
            #region MultiLevelQueryDB 
            public T QueryMultipleLevel<T>(string commandName, DynamicParameters parameters, List<MapperConfigurationIdentifiersSP> mapperIdentifiers)
            {
                using (var connection = SqlConnectionFactory.CreateConnection(ConnectionString))
                {
                    dynamic result = connection.Query<dynamic>(commandName, parameters);
                    mapperIdentifiers.ForEach(x =>
                    {
                        Slapper.AutoMapper.Configuration.AddIdentifiers(x.ModelType, new List<string> { x.PrimaryKey });
                    });

                    var testContact = (Slapper.AutoMapper.MapDynamic<T>(result) as IEnumerable<dynamic>).ToList();
                    return testContact.FirstOrDefault();
                }
            }

            #endregion
            #endregion
        }

    }

}
