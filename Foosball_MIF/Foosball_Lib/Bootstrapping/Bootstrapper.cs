using Autofac;
using Foosball_Lib.Views;
using Foosball_MIF;

namespace Foosball_Lib.Bootstrapping
{
    public class Bootstrapper : AutofacBoostrapper
    {
        private App _app;

        public Bootstrapper(App app)
        {
            _app = app;
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var enterOpponentName = container.Resolve<EnterOponentName>();
            var enterOpponentNameViewModel = container.Resolve<EnterOponentNameViewModel>();
            enterOpponentName.BindingContext = enterOpponentNameViewModel;
            _app.MainPage = enterOpponentName;
        }

        protected override void RegisterViews(ContainerBuilder builder)
        {
            builder.RegisterType<EnterOponentName>().SingleInstance();
            builder.RegisterType<EnterOponentNameViewModel>().SingleInstance();
        }
    }
}
