using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Dependencies
{
    public class IoCUtil
    {
        private static string country = null ;
        private static IWindsorContainer _container = null;
        private static IWindsorContainer Container
        {
            get
            {
                //if container is null, register _container with country class
                // else return already existing container
                if (_container == null)
                {
                    _container = BootstrapContainer(country);
                }
                return _container;
            }
        }

        private static IWindsorContainer BootstrapContainer(string country)
        {
            //country code control
            if (country.Equals("TR"))
            {
                return new WindsorContainer().Register(
                Component.For<ISmsSender>().ImplementedBy<TurkeySenderService>() // new implementing can be added with ','
                );
            }
            else
            {
                return new WindsorContainer().Register(
                Component.For<ISmsSender>().ImplementedBy<UnitedKingdomSenderService>() // new implementing can be added with ','
                );
            }
        }

        public static T Resolve<T>(string _country)
        {
            //if static value(container) is null or country has been changed, 
            //container must be null for new registering and static country must change as comes new country code
            if (country == null || !country.Equals(_country))
            {
                _container = null;
                country = _country;
            }
            return Container.Resolve<T>();

        }
    }
}