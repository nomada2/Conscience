using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Concience.DataAccess;
using Conscience.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Conscience.Application.Graph;
using Conscience.Application.Services;
using Conscience.Web.Identity;

namespace Conscience.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance(container);

            container.RegisterType<ConscienceContext, ConscienceContext>();

            container.RegisterInstance<IDocumentExecuter>(new DocumentExecuter());
            container.RegisterInstance<IDocumentWriter>(new DocumentWriter(true));
            container.RegisterInstance(new ConscienceSchema(type => (GraphType)container.Resolve(type)));

            container.RegisterType<IUsersIdentityService, UsersIdentityService>();
        }
    }
}
