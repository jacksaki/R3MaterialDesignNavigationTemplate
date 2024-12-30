using R3MaterialDesignNavigationTemplate.ViewModels;

namespace R3MaterialDesignNavigationTemplate.Views;

public partial class ColorToolBox
{
    public ColorToolBox()
    {
        InitializeComponent();
        this.DataContext = App.GetService<ColorToolBoxViewModel>();
    }
}
