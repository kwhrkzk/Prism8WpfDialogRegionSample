using System;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;

namespace Prism8WpfSample.ViewModels
{
    public class CustomDialogAViewModel : IDialogAware 
    {
        public event Action<IDialogResult>? RequestClose;
        public bool CanCloseDialog() => true;
        public string Title => "CustomDialogA";
        public ReactivePropertySlim<IRegionManager> CustomDialogARegionManager { get; } = new ReactivePropertySlim<IRegionManager>();
        private IRegionManager _regionManager;

        public CustomDialogAViewModel(IRegionManager _regionManager)
        {

            //CustomDialogARegionManager.Value = _regionManager.CreateRegionManager();
            CustomDialogARegionManager.Value = _regionManager;
            this._regionManager = _regionManager;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.TryGetValue<IRegionManager>("rm", out IRegionManager rm))
                CustomDialogARegionManager.Value = rm;

            if (parameters.TryGetValue<string>("ViewName", out string v))
                CustomDialogARegionManager.Value.RequestNavigate("CustomDialogARegion", v);
            else
                CustomDialogARegionManager.Value.RequestNavigate("CustomDialogARegion", "CustomDialogAAView");
        }

        public void OnDialogClosed() {}
    }
}