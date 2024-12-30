using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.Wpf;
using R3MaterialDesignNavigationTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3MaterialDesignNavigationTemplate.ViewModels
{
    public class BoxViewModelBase : ViewModelBase
    {
        private readonly MainWindowViewModel _parent;
        public BoxViewModelBase()
        {
            _parent = App.GetService<MainWindowViewModel>()!;
        }
        public void OnErrorOccurred(ErrorOccurredEventArgs e)
        {
            _parent.OnErrorOccurred(this, e);
        }

        public void OnMessage(MessageEventArgs e)
        {
            _parent.OnMessage(this, e);
        }

        public void OnSnackBarMessage(SnackBarMessageEventArgs e)
        {
            _parent.OnSnackBarMessage(this, e);
        }
    }
}
