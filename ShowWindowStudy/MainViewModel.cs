using CommunityToolkit.Mvvm.DependencyInjection;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Diagnostics;
using System.Reactive.Disposables;

namespace ShowWindowStudy;

public class MainViewModel : NotifyBase, IDisposable
{
    public MainModel Model { get; set; }

    /// <summary>
    /// Actionを利用して、ViewModelからViewのメソッドを呼び出す
    /// </summary>
    public ReactiveCommand ShowWindowCommand { get; } = new();

    /// <summary>
    /// ViewModel上で表示
    /// </summary>
    public ReactiveCommand ShowMainViewCommand { get; } = new();

    /// <summary>
    /// Model上で表示
    /// </summary>
    public ReactiveCommand ShowMainViewOnModelCommand { get; } = new();

    public Action? ShowWindowAction { get; set; }

    #region Service

    private readonly IWindowService _windowService = Ioc.Default.GetRequiredService<IWindowService>();

    #endregion

    public MainViewModel(MainModel model)
    {
        Model = model;
        ShowWindowCommand.Subscribe(ShowWindow).AddTo(Disposable);
        ShowMainViewCommand.Subscribe(ShowMainView).AddTo(Disposable);
        ShowMainViewOnModelCommand.Subscribe(ShowMainViewOnModel).AddTo(Disposable);
    }

    public void ShowWindow()
    {
        ShowWindowAction?.Invoke();
    }

    public void ShowMainView()
    {
        _windowService.ShowMainView();
    }

    public void ShowMainViewOnModel()
    {
        Model.ShowMainViewOnModel();
    }

    #region Dispose

    private bool disposedValue;
    private CompositeDisposable Disposable { get; } = [];

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Debug.WriteLine("MainViewModel Disposed");
                Disposable.Dispose();
                Model.Dispose();
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