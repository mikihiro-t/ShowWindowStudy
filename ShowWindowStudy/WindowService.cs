using System.Windows;

namespace ShowWindowStudy;

public class WindowService : IWindowService
{
    /// <summary>
    /// Model, ViewModel, Viewの、いずれのレイヤーからも呼び出し可能。
    /// </summary>
    public void ShowMainView()
    {
        var model = new MainModel();
        var viewModel = new MainViewModel(model);
        var view = new MainView(viewModel);
        view.Show();
    }

    /// <summary>
    /// MainModelを引数にした時は、
    /// Model, ViewModel, Viewの、いずれのレイヤーからも呼び出し可能。
    /// </summary>
    /// <param name="model"></param>
    public void ShowMainView(MainModel model)
    {
        var viewModel = new MainViewModel(model);
        var view = new MainView(viewModel);
        view.Show();
    }

    /// <summary>
    /// Modelのレイヤーのコードからは、呼び出ししない。MainViewModelを、生成しておき引数にする必要があるため。
    /// </summary>
    /// <param name="viewModel"></param>
    /// <param name="model"></param>
    public void ShowMainView(MainViewModel viewModel, MainModel model)
    {
        var view = new MainView(viewModel);
        view.Show();
    }

    /// <summary>
    /// ジェネリックメソッド。
    /// Model, VewModelのレイヤーのコードからは、呼び出ししない。Viewの型をTに配置する必要があるため。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataContext"></param>
    public void ShowWindow<T>(object dataContext) where T : Window, new()
    {
        T window = new T();
        window.DataContext = dataContext;
        window.Show();
    }
}

public interface IWindowService
{
    public void ShowMainView();

    public void ShowMainView(MainModel model);

    public void ShowMainView(MainViewModel viewModel, MainModel model);

    public void ShowWindow<T>(object dataContext) where T : Window, new();
}