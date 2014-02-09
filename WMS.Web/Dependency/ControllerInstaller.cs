﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Mvc;
using System.Reflection;
using System.Web.Http;


namespace WMS.Web.Dependency
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                //All MVC controllers
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient(),
                AllTypes.FromThisAssembly().BasedOn<ApiController>().LifestyleScoped()
                
                //,
                //Classes.FromAssemblyNamed("Elmah.Mvc").BasedOn<IController>().LifestyleTransient()

                );


          
           

        }
    }
}