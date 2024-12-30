using R3MaterialDesignNavigationTemplate.ViewModels;

namespace R3MaterialDesignNavigationTemplate.Views;

public partial class ThemeSettings
{
    public ThemeSettings()
    {
        InitializeComponent();
        DataContext = App.GetService<ThemeSettingsViewModel>();
    }
}
