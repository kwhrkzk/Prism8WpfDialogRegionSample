using System;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Prism8WpfDialogRegionSample.ViewModels
{
    public class CustomDialogBViewModel : IDialogAware 
    {
        public event Action<IDialogResult>? RequestClose;
        public bool CanCloseDialog() => true;
        public string Title => "CustomDialogB";
        private IRegionManager CustomDialogARegionManager { get; set; }

        public CustomDialogBViewModel(IRegionManager _regionManager) => CustomDialogARegionManager = _regionManager;

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.TryGetValue<IRegionManager>("rm", out IRegionManager rm))
                CustomDialogARegionManager = rm;

            if (parameters.TryGetValue<string>("ViewName", out string v))
                CustomDialogARegionManager.RequestNavigate("CustomDialogBRegion", v);
            else
                CustomDialogARegionManager.RequestNavigate("CustomDialogBRegion", "CustomDialogAAView");
        }

        public void OnDialogClosed()
        {
            if (RequestClose is not null)
                RequestClose(new DialogResult());
        }
    }
}