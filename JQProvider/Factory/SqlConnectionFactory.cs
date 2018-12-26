using System;
using System.Data.SqlClient;


namespace JQProvider.DataAcess.Factory
{
    internal class SqlConnectionFactory :IDisposable
    {

        
        #region Dispose Pattern

        protected bool Disposed { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Disposed = true;
        }

        protected void CheckDisposed()
        {
            if (Disposed)
                throw new ObjectDisposedException(this.GetType().Name);
        }

        #endregion

        protected SqlConnectionFactory()
        {
            Disposed = false;

        }
        /// <summary>
        /// connection creation method
        /// </summary>
        /// <returns>An SQL connection object</returns>
        public static SqlConnection CreateConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
