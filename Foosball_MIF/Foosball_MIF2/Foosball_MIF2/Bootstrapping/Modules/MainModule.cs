using Autofac;
using Foosball_MIF2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_MIF2.Bootstrapping.Modules
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ChooseOpponentViewModel>().SingleInstance();
            builder.RegisterType<ChooseOpponentPage>().SingleInstance();
        }
    }
}
