using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Prism8WpfDialogRegionSample.ViewModels
{
    public class CustomDialogAAViewModel : BindableBase, INavigationAware
    {
        private IRegionNavigationService? NavigationService { get; set; }
        public DelegateCommand CustomDialogABCommand { get; init; }

        public CustomDialogAAViewModel() => CustomDialogABCommand = new DelegateCommand(() => NavigationService.RequestNavigate("CustomDialogABView"));

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;
        public void OnNavigatedFrom(NavigationContext navigationContext) {}
        public void OnNavigatedTo(NavigationContext navigationContext) => NavigationService = navigationContext.NavigationService;
    }
}