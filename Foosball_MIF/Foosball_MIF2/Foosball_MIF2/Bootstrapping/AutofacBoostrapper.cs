using Autofac;
using Foosball_MIF2.Bootstrapping.Modules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foosball_MIF2.Bootstrapping
{
    public abstract class AutofacBoostrapper
    {
        private Dictionary<Type, Type> _mappedTypes;

        public void RunWithMappedTypes(Dictionary<Type, Type> mappedTypes)
        {
            _mappedTypes = mappedTypes;

            var builder = new ContainerBuilder();

            RegisterViews(builder);

            ConfigureContainer(builder);

            var container = builder.Build();
            ConfigureApplication(container);
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            if (_mappedTypes != null && !_mappedTypes.Any())
            {
                builder.RegisterModule(new MappedTypeModule(_mappedTypes));
            }
        }

        protected abstract void RegisterViews(ContainerBuilder builder);

        protected abstract void ConfigureApplication(IContainer container);
    }
}
