using CommunityToolkit.Mvvm.DependencyInjection;

namespace ShowWindowStudy;

public class MainModel : NotifyBase, IDisposable
{
    #region Service

    private readonly IWindowService _windowService = Ioc.Default.GetRequiredService<IWindowService>();

    #endregion

    public MainModel()
    {
    }

    public void ShowMainViewOnModel()
    {
        _windowService.ShowMainView();
    }

    #region Dispose

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
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