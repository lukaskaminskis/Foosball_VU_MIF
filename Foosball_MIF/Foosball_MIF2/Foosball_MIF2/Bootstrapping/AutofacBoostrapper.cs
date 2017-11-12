using Autofac;
using Foosball_MIF2.Bootstrapping.Modules;
using Foosball_MIF2.Factory;
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

            ConfigureContainer(builder);

            var container = builder.Build();

            var viewFactory = container.Resolve<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(container);
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            if (_mappedTypes != null && _mappedTypes.Any())
            {
                builder.RegisterModule(new MappedTypeModule(_mappedTypes));
            }
            builder.RegisterModule<AutofacModule>();
        }

        protected abstract void RegisterViews(IViewFactory builder);

        protected abstract void ConfigureApplication(IContainer container);
    }
}
