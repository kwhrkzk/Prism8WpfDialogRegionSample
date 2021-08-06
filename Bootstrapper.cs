using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Unity;
using Prism8WpfDialogRegionSample.Views;

namespace Prism8WpfDialogRegionSample
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override void RegisterTypes(IContainerRegistry c)
        {
            c.Register<IDialogService, MyDialogService>();

            c.RegisterForNavigation<ContentView>();
            c.RegisterForNavigation<CustomDialogAAView>();
            c.RegisterForNavigation<CustomDialogABView>();

            c.RegisterDialogWindow<CustomDialogAWindow>(nameof(CustomDialogAWindow));
            c.RegisterDialogWindow<CustomDialogBWindow>(nameof(CustomDialogBWindow));
            c.RegisterDialog<CustomDialogAView>(nameof(CustomDialogAView));
            c.RegisterDialog<CustomDialogBView>(nameof(CustomDialogBView));
        }

        protected override Window CreateShell() => new MainWindow();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Container.Resolve<IRegionManager>().RequestNavigate("ContentRegion", nameof(ContentView));
        }
    }
}