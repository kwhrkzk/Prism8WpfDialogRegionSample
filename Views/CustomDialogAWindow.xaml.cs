using System.Windows;
using Prism.Services.Dialogs;

namespace Prism8WpfSample.Views
{
    public partial class CustomDialogAWindow : Window, IDialogWindow
    {
        public CustomDialogAWindow()
        {
            InitializeComponent();
        }

        public IDialogResult? Result { get; set; }
    }
}