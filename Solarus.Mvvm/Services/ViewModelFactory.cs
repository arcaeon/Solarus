using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Solarus.Mvvm.Services
{
    public class ViewModelFactory : IViewModelFactory
    {
        private static ViewModelFactory _instance;
        private readonly IServiceProvider _serviceProvider;

        static ViewModelFactory() { }

        private ViewModelFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static ViewModelFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("Instance has not been initialized.");
                }

                return _instance;
            }
        }

        public T Create<T>(params object[] args)
        {
            ConstructorInfo ctor = typeof(T).GetConstructors().Single();
            ParameterInfo[] parameters = ctor.GetParameters();
            List<object> instanceArgs = new List<object>();

            foreach (ParameterInfo param in parameters)
            {
                object service = _serviceProvider.GetService(param.ParameterType);
                if (service != null)
                {
                    instanceArgs.Add(service);
                }
            }

            if (args.Length > 0)
            {
                instanceArgs.AddRange(args);
            }

            return (T)Activator.CreateInstance(typeof(T), instanceArgs.ToArray());
        }

        public static void InitializeInstance(IServiceProvider serviceProvider)
        {
            _instance = new ViewModelFactory(serviceProvider);
        }
    }
}
