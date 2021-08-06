using System.Windows;
using Prism.Services.Dialogs;

namespace Prism8WpfSample.Views
{
    public partial class CustomDialogBWindow : Window, IDialogWindow
    {
        public CustomDialogBWindow()
        {
            InitializeComponent();
        }

        public IDialogResult? Result { get; set; }
    }
}