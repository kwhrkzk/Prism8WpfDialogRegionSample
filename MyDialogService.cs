using System.Windows;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Prism8WpfSample
{
    public class MyDialogService : DialogService
    {
        private readonly IContainerExtension _containerExtension;
        private readonly IRegionManager _regionManager;
        public MyDialogService(
            IContainerExtension containerExtension
            , IRegionManager regionManager) : base(containerExtension)
        {
            _containerExtension = containerExtension;
            _regionManager = regionManager;
        }

        protected override void ConfigureDialogWindowContent(string dialogName, IDialogWindow window, IDialogParameters parameters)
        {
            var rm = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(window as Window, rm);
            RegionManager.UpdateRegions();

            parameters.Add("rm", rm);

            base.ConfigureDialogWindowContent(dialogName, window, parameters);
        }
    }
}