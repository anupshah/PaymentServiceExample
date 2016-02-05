using System;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PaymentServiceExample.Controllers;
using PaymentServiceExample.Models;
using PaymentServiceExample.Services;
using Unity.WebApi;

namespace PaymentServiceExample
{
	public static class UnityConfig
	{
		#region Unity Container
		private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
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
			return Container.Value;
		}
		#endregion

		/// <summary>Registers the type mappings with the Unity container.</summary>
		/// <param name="container">The unity container to configure.</param>
		/// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
		/// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
		public static void RegisterTypes(IUnityContainer container)
		{
			// NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
			// container.LoadConfiguration();

			// Register your types here
			container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
			container.RegisterType<AccountController>(new InjectionConstructor());
			container.RegisterType<ManageController>(new InjectionConstructor());

			container.RegisterType<IPaymentService, PaymentService>();
		}

		// Used by WebAPI
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			container.RegisterType<IPaymentService, PaymentService>();

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}