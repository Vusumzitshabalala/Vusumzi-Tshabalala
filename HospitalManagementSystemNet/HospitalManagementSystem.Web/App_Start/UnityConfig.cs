using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Logic;
using HospitalManagementSystem.Repository;
using System;

using Unity;

namespace HospitalManagementSystem.Web
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
            HospitalManagementSystemContext hospitalManagementSystemContext = new HospitalManagementSystemContext();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IPatientRepository, PatientRepository>();
            container.RegisterType<IPatientRegistration, PatientRegistration>();
            container.RegisterType<IPatientRetriever, PatientRetriever>();
            container.RegisterType<IPatientsRetriever, PatientsRetriever>();

            container.RegisterType<IDoctorRepository, DoctorRepository>();
            container.RegisterType<IDoctorRegistration, DoctorRegistration>();
            container.RegisterType<IDoctorRetriever, DoctorRetriever>();
            container.RegisterType<IDoctorsRetriever, DoctorsRetriever>();

            container.RegisterType<INurseRepository, NurseRepository>();
            container.RegisterType<INurseRegistration, NurseRegistration>();
            container.RegisterType<INurseRetriever, NurseRetriever>();
            container.RegisterType<INursesRetriever, NursesRetriever>();

            container.RegisterType<IAdministratorRepository, AdministratorRepository>();
            container.RegisterType<IAdministratorRegistration, AdministratorRegistration>();
            container.RegisterType<IAdministratorRetriever, AdministratorRetriever>();
            container.RegisterType<IAdministratorsRetriever, AdministratorsRetriever>();

            container.RegisterType<IPorterRepository, PoterRepository>();
            container.RegisterType<IPorterRegistration, PorterRegistration>();
            container.RegisterType<IPorterRetriever, PorterRetriever>();
            container.RegisterType<IPortersRetriever, PortersRetriever>();

            container.RegisterInstance(hospitalManagementSystemContext);
            //TypeFactory.RegisterType<IPatientRepository,PatientRepository>();
            //TypeFactory.RegisterType<IPatientRegistration, PatientRegistration>();
            //TypeFactory.RegisterType<IPatientRetriever, PatientRetriever>();

            //TypeFactory.RegisterInstance(HospitalManagementSystemContext);

        }
    }
}