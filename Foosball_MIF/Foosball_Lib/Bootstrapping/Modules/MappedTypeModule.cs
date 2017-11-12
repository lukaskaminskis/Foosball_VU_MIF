using Autofac;
using System;
using System.Collections.Generic;

namespace Foosball_Lib.Bootstrapping.Modules
{
    public class MappedTypeModule : Module
    {
        private Dictionary<Type, Type> _mappedTypes;

        public MappedTypeModule(Dictionary<Type, Type> mappedTypes)
        {
            _mappedTypes = mappedTypes;
        }

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var kvp in _mappedTypes)
            {
                builder.RegisterType(kvp.Value).As(kvp.Key);
            }
        }
    }
}
