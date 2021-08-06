using System.ComponentModel;
using Prism.Regions;
using Reactive.Bindings;

namespace Prism8WpfSample.ViewModels
{
    public class CustomDialogABViewModel : INavigationAware
    {
#pragma warning disable 0067
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore 0067
        private IRegionNavigationService? NavigationService { get; set; }

        public ReactiveCommand CustomDialogAACommand { get; } = new ReactiveCommand();
        public ReactiveCommand CustomDialogBBCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ContentViewCommand { get; } = new ReactiveCommand();

        public CustomDialogABViewModel()
        {
            CustomDialogAACommand.Subscribe(() => NavigationService.RequestNavigate("CustomDialogAAView"));
            CustomDialogBBCommand.Subscribe(() => NavigationService.RequestNavigate("CustomDialogBBView"));
            ContentViewCommand.Subscribe(() => NavigationService.RequestNavigate("ContentView"));
        }

        public void OnNavigatedTo(NavigationContext navigationContext) {}
        public bool IsNavigationTarget(NavigationContext navigationContext) => true;
        public void OnNavigatedFrom(NavigationContext navigationContext) => NavigationService = navigationContext.NavigationService;
    }
}