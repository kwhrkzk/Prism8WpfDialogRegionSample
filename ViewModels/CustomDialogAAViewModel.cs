using System;
using System.ComponentModel;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;

namespace Prism8WpfSample.ViewModels
{
    public class CustomDialogAAViewModel : BindableBase, INavigationAware
    {
        private IRegionNavigationService? NavigationService { get; set; }
        public ReactiveCommand CustomDialogABCommand { get; } = new ReactiveCommand();
        public ReactiveCommand CustomDialogBACommand { get; } = new ReactiveCommand();
        public ReactiveCommand ContentViewCommand { get; } = new ReactiveCommand();

        public CustomDialogAAViewModel()
        {
            CustomDialogABCommand.Subscribe(() => NavigationService.RequestNavigate("CustomDialogABView"));
            CustomDialogBACommand.Subscribe(() => NavigationService.RequestNavigate("CustomDialogBAView"));
            ContentViewCommand.Subscribe(() => NavigationService.RequestNavigate("ContentView"));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;
        public void OnNavigatedFrom(NavigationContext navigationContext) {}
        public void OnNavigatedTo(NavigationContext navigationContext) => NavigationService = navigationContext.NavigationService;
    }
}