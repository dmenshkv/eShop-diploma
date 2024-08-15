using Marketplace.UI.Shared;

namespace Marketplace.UI.Pages.BasePages;

public abstract class PageComponentBase : ComponentBase
{
    [CascadingParameter]
    protected Error? Error { get; set; }

    protected bool IsLoading { get; set; }

    protected abstract Task InitializePageAsync();

    protected async Task ExecuteSafelyAsync(Func<Task> function)
    {
        try
        {
            IsLoading = true;

            await function();
        }
        catch (Exception)
        {
            Error?.ProcessError();
        }
        finally
        {
            IsLoading = false;
        }
    }
}