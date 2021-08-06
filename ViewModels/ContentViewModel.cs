using System;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;

namespace Prism8WpfSample.ViewModels
{
    public class ContentViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {

        public bool KeepAlive => true;
        private IRegionNavigationService? NavigationService { get; set; }
        public ReactiveCommand DialogACommand { get; } = new ReactiveCommand();
        public ReactiveCommand DialogBCommand { get; } = new ReactiveCommand();
        private IDialogService DialogService { get; init; }

        public ContentViewModel(IDialogService _dialogService)
        {
            DialogService = _dialogService;

            //DialogACommand.Subscribe(_ => DialogService.Show("CustomDialogAView", new DialogParameters{ { "ViewName", "CustomDialogABView" } }, _ => {}, "CustomDialogAWindow"));
            DialogACommand.Subscribe(_ => DialogService.Show("CustomDialogAView"));
            DialogBCommand.Subscribe(_ => DialogService.Show("CustomDialogBView", new DialogParameters(), _ => {}, "CustomDialogBWindow"));
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