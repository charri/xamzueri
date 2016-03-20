using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;

namespace XamZueri.App.Tests.Mvx
{
    public class MockDispatcher
        : MvxMainThreadDispatcher
          , IMvxViewDispatcher
    {
        public readonly List<MvxViewModelRequest> Requests = new List<MvxViewModelRequest>();
        public readonly List<MvxPresentationHint> Hints = new List<MvxPresentationHint>();

        public bool RequestMainThreadAction(Action action)
        {
            action();
            return true;
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            var sb = new StringBuilder();

            if (request.ParameterValues != null)
            {
                foreach (var pair in request.ParameterValues)
                {
                    sb.Append($"{{ {pair.Key}={pair.Value} }},");
                }
            }

            Console.WriteLine("ShowViewModel {0} with parameters: {1}", request.ViewModelType.FullName, sb);
            Requests.Add(request);
            return true;
        }

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            Hints.Add(hint);
            return true;
        }

    }
}
