using R3MaterialDesignNavigationTemplate.ViewModels;
using System.Windows.Controls;

namespace R3MaterialDesignNavigationTemplate.Views
{
    /// <summary>
    /// SampleBox.xaml の相互作用ロジック
    /// </summary>
    public partial class SampleBox : UserControl
    {
        public SampleBox()
        {
            InitializeComponent();
            this.DataContext = App.GetService<SampleBoxViewModel>();
        }
    }
}
