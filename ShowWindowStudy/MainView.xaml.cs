using CommunityToolkit.Mvvm.DependencyInjection;
using ShowWindowStudy.Sub;
using System.Windows;

namespace ShowWindowStudy;

public partial class MainView : Window, IDisposable
{
    private readonly MainViewModel vm;

    #region Service

    private readonly IWindowService _windowService = Ioc.Default.GetRequiredService<IWindowService>();

    #endregion

    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();
        vm = viewModel;
        DataContext = vm;
        vm.ShowWindowAction ??= new Action(ShowWindow);
    }

    /// <summary>
    /// Viewのコードビハインドによる表示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var model = new MainModel();
        var viewModel = new MainViewModel(model);
        var view = new MainView(viewModel);
        view.Show();
    }

    /// <summary>
    /// Actionから呼び出される。
    /// </summary>
    public void ShowWindow()
    {
        var model = new MainModel();
        var viewModel = new MainViewModel(model);
        var view = new MainView(viewModel);
        view.Show();
    }

    /// <summary>
    /// DIの、Serviceで処理する。（ジェネリックメソッド）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ShowMainViewGenericButton_Click(object sender, RoutedEventArgs e)
    {
        var model = new SubModel();
        var viewModel = new SubViewModel(model);
        //ここに、SubViewへの参照があるので、MVVMに適した形にするには、Viewのレイヤーで処理する。
        _windowService.ShowWindow<SubView>(viewModel);
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        Dispose();
    }

    #region Dispose View

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                vm.ShowWindowAction = null;
                vm.Dispose();
                DataContext = null;
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}