using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamZueri.App.Controls
{
    public class Card : ContentView
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(InfiniteListView), 2.0f);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            if (Content == null)
                return new SizeRequest(new Size(100, 100));

            return Content.GetSizeRequest(widthConstraint, heightConstraint);
        }
    }
}
