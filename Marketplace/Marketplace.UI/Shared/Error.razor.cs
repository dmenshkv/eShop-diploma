using Microsoft.AspNetCore.Components;

namespace Marketplace.UI.Shared
{
    public partial class Error
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected bool IsErrorActive { get; set; }

        protected string? Message { get; set; }

        public virtual void ProcessError()
        {
            Message = $"Oops, something went wrong";
            IsErrorActive = true;
            StateHasChanged();
        }

        protected void HideError()
        {
            IsErrorActive = false;
        }
    }
}
