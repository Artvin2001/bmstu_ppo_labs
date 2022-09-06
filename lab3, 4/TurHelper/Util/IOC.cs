using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

using TurHelper.DataAccesss;
using TurHelper.DataAccesss.PSQLRepository;

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
        private void PSQLConString(string Login, string Password)
        {
            string ConString = "Host=localhost;Port=5432;Database=ppo;Username=" + Login + ";Password=" + Password;

            //поставила 1
            ninjectKernel.Bind<UserRepositoryInterface>().To<UserRepositoryPSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<CountriesRepositoryInterface>().To<CountryRepositoryPSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<ClimateRepositoryInterface>().To<ClimateRepositoryPSQL>().WithConstructorArgument(ConString, 1);
            ninjectKernel.Bind<HotelsRepositoryInterface>().To<HotelRepositoryPSQL>();
            ninjectKernel.Bind<RoomsRepositoryInterface>().To<RoomRepositoryPSQL>();
        }
    }
}
