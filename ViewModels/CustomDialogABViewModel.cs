using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Prism8WpfDialogRegionSample.ViewModels
{
    public class CustomDialogABViewModel : BindableBase, INavigationAware
    {
        private IRegionNavigationService? NavigationService { get; set; }

        public DelegateCommand CustomDialogAACommand { get; init; }

        public CustomDialogABViewModel() => CustomDialogAACommand = new DelegateCommand(() => NavigationService.RequestNavigate("CustomDialogAAView"));

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;
        public void OnNavigatedFrom(NavigationContext navigationContext) {}
        public void OnNavigatedTo(NavigationContext navigationContext) => NavigationService = navigationContext.NavigationService;
    }
}