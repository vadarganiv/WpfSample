using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportSaver.Services
{

    public static class KernelExt
    {
        public static bool IsRegistered<TServiceType>(this IKernel kernel)
        {
            return kernel.IsRegistered(typeof(TServiceType));
        }

        public static bool IsRegistered(this IKernel kernel, Type serviceType)
        {
            return kernel.CanResolve(kernel.CreateRequest(serviceType, meta => true, new List<IParameter>(), false, false));
        }

        public static void RegisterTypeIfMissing<TFromType, TToType>(this IKernel kernel, bool registerAsSingleton) where TToType : TFromType
        {
            kernel.RegisterTypeIfMissing(typeof(TFromType), typeof(TToType), registerAsSingleton);
        }

        public static void RegisterTypeIfMissing(this IKernel kernel, Type fromType, Type toType, bool registerAsSingleton)
        {
            if (kernel.IsRegistered(fromType))
            {
              
            }
            else
            {
                if (registerAsSingleton)
                {
                    kernel.Bind(fromType).To(toType).InSingletonScope();
                }
                else
                {
                    kernel.Bind(fromType).To(toType).InTransientScope();
                }
            }
        }

        public static T Resolve<T>(this IKernel kernel, string name = null, params IParameter[] overrides)
        {
            return (T)kernel.Resolve(typeof(T), name, overrides);
        }

        public static object Resolve(this IKernel kernel, Type t, string name = null, params IParameter[] overrides)
        {
            return kernel.Get(t, name, overrides);
        }

        public static IEnumerable<T> ResolveAll<T>(this IKernel kernel, params IParameter[] resolverOverrides)
        {
            return kernel.GetAll(typeof(T), resolverOverrides).Cast<T>();
        }
    }
}
