using AutoMapper;
using Contacts.Persistence;
using Contacts.Persistence.Interfaces;
using Contacts.Persistence.Repositories;
using Contacts.Persistence.Repositories.Interfaces;
using Contacts.Persistence.Services;
using Contacts.Persistence.Services.Interfaces;
using Contacts.Web.Mapping;
using System;

using Unity;

namespace Contacts.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IContactsDbContext, ContactsDbContext>();
            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IPersonRepo, PersonRepo>();

            //TODO :: Register instances
            container.RegisterInstance(Configuration.CreateMapper());
        }
    }
}