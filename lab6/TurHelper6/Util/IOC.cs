using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Configuration;

using TurHelper.DataAccesss;
using TurHelper.DataAccesss.PSQLRepository;
using TurHelper.DataAccesss.MSSQLRepository;
using TurHelper6;

namespace TurHelper.Util
{
    public class IOC
    {
        public IKernel ninjectKernel;
        public IOC()
        {
            ninjectKernel = new StandardKernel();

            //string con = System.Configuration.ConfigurationManager.AppSettings["DBMS"];
            //if (con == "PSQL")
            PSQL();
            //MSSQL();
        }
        public IOC(string Login, string Password)
        {
            ninjectKernel = new StandardKernel();

            //string con = System.Configuration.ConfigurationManager.AppSettings["DBMS"];

            //if (con == "PSQL")
            PSQLConString(Login, Password);
        }
        private void PSQL()
        {
            ninjectKernel.Bind<UserRepositoryInterface>().To<UserRepositoryPSQL>();
            ninjectKernel.Bind<CountriesRepositoryInterface>().To<CountryRepositoryPSQL>();
            ninjectKernel.Bind<ClimateRepositoryInterface>().To<ClimateRepositoryPSQL>();
            ninjectKernel.Bind<HotelsRepositoryInterface>().To<HotelRepositoryPSQL>();
            ninjectKernel.Bind<RoomsRepositoryInterface>().To<RoomRepositoryPSQL>();
        }

        private void MSSQL()
        {
            ninjectKernel.Bind<UserRepositoryInterface>().To<UserRepositoryMSSQL>();
            ninjectKernel.Bind<CountriesRepositoryInterface>().To<CountryRepositoryMSSQL>();
            ninjectKernel.Bind<ClimateRepositoryInterface>().To<ClimateRepositoryMSSQL>();
            ninjectKernel.Bind<HotelsRepositoryInterface>().To<HotelRepositoryMSSQL>();
            ninjectKernel.Bind<RoomsRepositoryInterface>().To<RoomRepositoryMSSQL>();
        }
        private void PSQLConString(string Login, string Password)
        {
            string ConString = "Host=localhost;Port=5432;Database=ppo;Username=" + Login + ";Password=" + Password;

            //поставила 1
            ninjectKernel.Bind<UserRepositoryInterface>().To<UserRepositoryPSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<CountriesRepositoryInterface>().To<CountryRepositoryPSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<ClimateRepositoryInterface>().To<ClimateRepositoryPSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<HotelsRepositoryInterface>().To<HotelRepositoryPSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<RoomsRepositoryInterface>().To<RoomRepositoryPSQL>().WithConstructorArgument(ConString, 1);
        }
        private void MSSQLConString(string Login, string Password)
        {
            string ConString = "Server=LAPTOP-623125E8;Database=ppo2;Persist Security Info=False;" +
                "TrustServerCertificate=true;User Id=" + Login + ";Password=" + Password + ";";

            ninjectKernel.Bind<UserRepositoryInterface>().To<UserRepositoryMSSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<CountriesRepositoryInterface>().To<CountryRepositoryMSSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<ClimateRepositoryInterface>().To<ClimateRepositoryMSSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<HotelsRepositoryInterface>().To<HotelRepositoryMSSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<RoomsRepositoryInterface>().To<RoomRepositoryMSSQL>().WithConstructorArgument(ConString, 1);
        }
    }
    
    
}
