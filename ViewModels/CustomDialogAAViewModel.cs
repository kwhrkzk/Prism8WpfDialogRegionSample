using System;
using System.ComponentModel;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;

namespace Prism8WpfSample.ViewModels
{
    public class CustomDialogAAViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        private IRegionNavigationService? NavigationService { get; set; }
        public bool KeepAlive => true;

        public ReactiveCommand CustomDialogABCommand { get; } = new ReactiveCommand();
        public ReactiveCommand CustomDialogBACommand { get; } = new ReactiveCommand();
        public ReactiveCommand ContentViewCommand { get; } = new ReactiveCommand();

        public CustomDialogAAViewModel(IRegionManager _regionManager)
        {
            CustomDialogABCommand.Subscribe(() => _regionManager.RequestNavigate("CustomDialogARegion", "CustomDialogABView"));
            CustomDialogBACommand.Subscribe(() => NavigationService.RequestNavigate("CustomDialogBAView"));
            ContentViewCommand.Subscribe(() => NavigationService.RequestNavigate("ContentView"));
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            NavigationService = navigationContext.NavigationService;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavigationService = navigationContext.NavigationService;
        }
    }
}