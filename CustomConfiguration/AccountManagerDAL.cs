using CustomConfiguration;
using Dapper;
using JQProvider.DataAccess.Enum;
using JQProvider.DataAcess.Factory;
using System.Data;

namespace JQProvider.DataAcess.AppCore.Account
{
    public class AccountManagerDAL 
    {
        private DataContract.DataContractProvider rtmsDataProvider =null;

        public AccountManagerDAL()
        {
            rtmsDataProvider = DBProviderFactory.CreateDBProvider(DBProviderObject.AMSApp);
        }

        public UserSP ValidateUserForChangePassword(string commandName, int userId, string password, string SelectedChangePwdType)
        {

            UserSP userLogin;
            var p = new DynamicParameters();
            p.Add("@OracleId", userId, dbType: DbType.Int64);
            p.Add("@password", password, dbType: DbType.String);
            p.Add("@serviceType", SelectedChangePwdType, dbType: DbType.Int32);

            try
            {
                userLogin = rtmsDataProvider.QuerySingle<UserSP>(commandName, p);

            }

            catch { throw; }
            return userLogin;

        }
    }
}

