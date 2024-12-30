# R3MaterialDesignNavigationTemplate

WPF MaterialDesign Navigation のテンプレート.

- [MahApps.Metro 2.4.10](https://github.com/MahApps/MahApps.Metro)
- [MaterialDesignThemes5.1.0](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
- [MaterialDesignThemes.MahApps 3.1.0](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
- [Microsoft.Extensions.DependencyInjection 9.0.0](https://github.com/dotnet/runtime)
- [Microsoft.Extensions.Hosting 9.0.0](https://github.com/dotnet/runtime)
- [Microsoft.Extensions.Logging 9.0.0](https://github.com/dotnet/runtime)
- [R3 1.2.9](https://github.com/Cysharp/R3)
- [R3Extensions.WPF 1.2.9](https://github.com/Cysharp/R3)
- [ZLogger 2.5.9](https://github.com/Cysharp/ZLogger)

## Install
1. プロジェクトをVisualStudioで開きます
1. プロジェクト(P)→テンプレートのエクスポート(E)... からテンプレートをエクスポートします

---

## Usage
### メニューの追加
1. ViewsフォルダにUserControlを追加 (e.g. HomeBox)
1. ViewModelフォルダにBoxViewModelBaseを継承したViewModelを追加(e.g. HomeBoxViewModel)
1. HomeBoxのコードビハインドにDataContextを追加
```csharp
        public HomeBox()
        {
            InitializeComponent();
            this.DataContext = App.GetService<SampleBoxViewModel>(); // ←追加
        }
```
4. App.xaml.csのConfigureServicesに1,2で追加したUserControlとViewModelを追加
```csharp
private static readonly IHost _host = Host
    .CreateDefaultBuilder()
    .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!); })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<SampleBox>();
        services.AddSingleton<SampleBoxViewModel>();
        services.AddSingleton<HomeBox>();           // ←追加
        services.AddSingleton<HomeBoxViewModel>();  // ←追加
        services.AddHostedService<ApplicationHostService>();
    }).Build();
```
5. MainWindowViewModelのGenerateMenuItemsメソッドにUserControlを追加(いい方法ないかな)
```csharp
private static IEnumerable<NavigationMenuItem> GenerateMenuItems()
{
    yield return new NavigationMenuItem("Sample", typeof(SampleBox), ScrollBarVisibility.Disabled);
}
```
### 設定
- 設定はServices/AppConfigにあります。
- R3MaterialDesignNavigationTemplate.conf の拡張子以外の部分をアセンブリ名に変更してください
 
### Message
- ViewModel内で OnMessageメソッドまたはOnErrorOccurredの実行でメッセージの表示ができます
   - MahApps.Metro.Controls.Dialogs.DialogCoordinator使用 

### SnackBar
- ViewModel内で OnSnackBarMessageメソッドの実行でSnackBarへメッセージ送信できます
---
 

# License
---
This library is under the MIT License.