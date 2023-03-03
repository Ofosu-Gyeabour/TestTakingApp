using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PETAS.Classes
{
    public interface ISpinnerHelper
    {
        void Show();
        void Hide();
        event Action OnShow;
        event Action OnHide;

    }
    public class AutoDisplaySpinnerHttpMessageHandler : DelegatingHandler
    {
        private readonly ISpinnerHelper _spinnerHelper;
        public AutoDisplaySpinnerHttpMessageHandler(ISpinnerHelper spinnerHelper)
        {
            _spinnerHelper = spinnerHelper;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _spinnerHelper.Show();
            var response = await base.SendAsync(request, cancellationToken);
            _spinnerHelper.Hide();
            return response;
        }
    }
}
