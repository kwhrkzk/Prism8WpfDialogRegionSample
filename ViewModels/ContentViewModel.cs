using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Prism8WpfDialogRegionSample.ViewModels
{
    public class ContentViewModel : BindableBase, INavigationAware
    {
        private IRegionNavigationService? NavigationService { get; set; }
        private IDialogService DialogService { get; init; }

        public DelegateCommand DialogACommand { get; init; }
        public DelegateCommand DialogBCommand { get; init; }

        public ContentViewModel(IDialogService _dialogService)
        {
            DialogService = _dialogService;

            DialogACommand = new DelegateCommand(() => DialogService.Show("CustomDialogAView", new DialogParameters{ { "ViewName", "CustomDialogABView" } }, _ => {}, "CustomDialogAWindow"));
            DialogBCommand = new DelegateCommand(() => DialogService.Show("CustomDialogBView", new DialogParameters(), _ => {}, "CustomDialogBWindow"));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;
        public void OnNavigatedFrom(NavigationContext navigationContext) {}
        public void OnNavigatedTo(NavigationContext navigationContext) => NavigationService = navigationContext.NavigationService;
    }
}