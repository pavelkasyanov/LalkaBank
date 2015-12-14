using DAO.Implemenation;
using DAO.Implementation;
using DAO.Interafaces;
using Services.Implemenations;
using Services.Implementation;
using Services.Interfaces;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApp.App_Start.NinjectWebCommon), "Stop")]

namespace WebApp.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            #region ServicesInjection
            kernel.Bind<IBankBookService>().To<BankBookService>();
            kernel.Bind<ICreditService>().To<CreditService>();
            kernel.Bind<ICreditTypesService>().To<CreditTypesService>();
            kernel.Bind<IDebtService>().To<DebtService>();
            kernel.Bind<IManagerService>().To<ManagerService>();
            kernel.Bind<IMessageService>().To<MessageService>();
            kernel.Bind<IPassportService>().To<PassportService>();
            kernel.Bind<IPaymentService>().To<PaymentService>();
            kernel.Bind<IPersonService>().To<PersonService>();
            kernel.Bind<IRequestService>().To<RequestService>();
            kernel.Bind<IBankAccountService>().To<BankAccountService>();
            kernel.Bind<ICreditHistoryService>().To<CreditHistoryService>();
            #endregion

            #region DAOInjection
            kernel.Bind<IBankBookDAO>().To<BankBookDAO>();
            kernel.Bind<ICreditDAO>().To<CreditDAO>();
            kernel.Bind<ICreditTypesDAO>().To<CreditTypesDAO>();
            kernel.Bind<IDebtDAO>().To<DebtDAO>();
            kernel.Bind<IManagerDAO>().To<ManagerDAO>();
            kernel.Bind<IMessageDAO>().To<MessageDAO>();
            kernel.Bind<IPassportDAO>().To<PassportDAO>();
            kernel.Bind<IPaymentDAO>().To<PaymentDAO>();
            kernel.Bind<IPersonDAO>().To<PersonDAO>();
            kernel.Bind<IRequestDAO>().To<RequestDAO>();
            kernel.Bind<IBankAccountDAO>().To<BankAccountDAO>();
            kernel.Bind<ICreditHistoryDAO>().To<CreditHistoryDAO>();
            #endregion
        }
    }
}
