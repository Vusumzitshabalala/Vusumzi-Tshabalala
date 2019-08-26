using Unity;
using Unity.Injection;
using Unity.Interception;
using Unity.Lifetime;
using Unity.Resolution;

namespace HospitalManagementSystem.Ioc
{
    public static class TypeFactory
    {
        static TypeFactory()
        {
            if (Container == null)
            {
                Container = new UnityContainer();
                Container.AddNewExtension<Interception>();
            }
        }

        public static IUnityContainer Container { get; private set; }

        public static void Clear()
        {
            Container.Dispose();
            Container = null;
            if (Container == null)
            {
                Container = new UnityContainer();
                Container.AddNewExtension<Interception>();
            }
        }

        public static void RegisterInstance<T>(T instance)
        {
            Container.RegisterInstance<T>(instance);
        }

        public static void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            Container.RegisterType<TFrom, TTo>();
        }

        public static void RegisterType<T>()
        {
            Container.RegisterType<T>();
        }

        //public static void RegisterType<TFrom, TTo>(LifetimeManager lifetimeManager) where TTo : TFrom
        //{
        //    Container.RegisterType<TFrom, TTo>(lifetimeManager);
        //}

        //public static void RegisterType<T>(LifetimeManager lifetimeManager)
        //{
        //    Container.RegisterType<T>(lifetimeManager);
        //}

        public static void RegisterType<TFrom, TTo>(params InjectionMember[] injectionMembers) where TTo : TFrom
        {
            Container.RegisterType<TFrom, TTo>(injectionMembers);
        }

        //public static void RegisterType<TFrom, TTo>(LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
        //    where TTo : TFrom
        //{
        //    Container.RegisterType<TFrom, TTo>(lifetimeManager, injectionMembers);
        //}

        public static T Resolve<T>(params ResolverOverride[] resolverOverrides)
        {
            return Container.Resolve<T>(resolverOverrides);
        }

        public static T Resolve<T>(string name, params ResolverOverride[] resolverOverrides)
        {
            return Container.Resolve<T>(name, resolverOverrides);
        }
    }
}
