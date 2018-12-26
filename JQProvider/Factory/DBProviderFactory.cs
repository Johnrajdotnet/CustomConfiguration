using JQProvider.DataAcess.DataContract;
using JQProvider.DataAccess.Enum;
using JQProvider.DataAcess.DataProvider;
using JQProvider.DataSecure;
using System.Configuration;

namespace JQProvider.DataAcess.Factory
{
    public class DBProviderFactory : JQDataProvider
    {
        public static DataContractProvider CreateDBProvider(DBProviderObject dataProvider)
        {
            try
            {
                DataContractProvider iDataProvider = null;
                JQSecureData qDataSecure = new JQSecureData();
                if (qDataSecure.ReadSecureData())
                {
                    switch (dataProvider)
                    {
                        case DBProviderObject.RRCare:
                            {
                                iDataProvider = new AppDataProvider();
                                iDataProvider.ConnectionString = ConfigurationManager.ConnectionStrings["RTMS_RR_Care_ConnectionString"].ConnectionString.ToString();
                                break;
                            }
                        case DBProviderObject.AMSApp:
                            {
                                iDataProvider = new AppDataProvider();
                                iDataProvider.ConnectionString = ConfigurationManager.ConnectionStrings["RTMS_AMS_App_ConnectionString"].ConnectionString.ToString();
                                break;
                            }
                        case DBProviderObject.AMSAero:
                            {
                                iDataProvider = new AppDataProvider();
                                iDataProvider.ConnectionString = ConfigurationManager.ConnectionStrings["RTMS_AMS_Aero_ConnectionString"].ConnectionString.ToString();
                                break;
                            }
                        case DBProviderObject.GPCApp:
                            {
                                iDataProvider = new AppDataProvider();
                                iDataProvider.ConnectionString = ConfigurationManager.ConnectionStrings["RTMS_GPC_App_ConnectionString"].ConnectionString.ToString();
                                break;
                            }
                        default: { iDataProvider = null; break; }
                    }
                }
                return iDataProvider;
            }
            catch {
                throw;
            }
        }
    }
}
