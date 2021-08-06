using System;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Prism8WpfDialogRegionSample.ViewModels
{
    public class CustomDialogAViewModel : IDialogAware 
    {
        public event Action<IDialogResult>? RequestClose;
        public bool CanCloseDialog() => true;
        public string Title => "CustomDialogA";
        private IRegionManager CustomDialogARegionManager { get; set; }

        public CustomDialogAViewModel(IRegionManager _regionManager) => CustomDialogARegionManager = _regionManager;

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.TryGetValue<IRegionManager>("rm", out IRegionManager rm))
                CustomDialogARegionManager = rm;

            if (parameters.TryGetValue<string>("ViewName", out string v))
                CustomDialogARegionManager.RequestNavigate("CustomDialogARegion", v);
            else
                CustomDialogARegionManager.RequestNavigate("CustomDialogARegion", "CustomDialogAAView");
        }

        public void OnDialogClosed()
        {
            if (RequestClose is not null)
                RequestClose(new DialogResult());
        }
    }
}