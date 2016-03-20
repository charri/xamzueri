using System;
using System.ComponentModel;
using Android.Support.V7.Widget;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamZueri.App.Controls;
using XamZueri.App.Droid.Renders;

[assembly: ExportRenderer(typeof(Card), typeof(CardRenderer))]

namespace XamZueri.App.Droid.Renders
{
    public class CardRenderer : CardView, IVisualElementRenderer
    {

        public CardRenderer() : base(Forms.Context)
        {
        }

        public event EventHandler<VisualElementChangedEventArgs> ElementChanged;

        public void SetElement(VisualElement element)
        {
            var oldElement = Element;

            if (oldElement != null)
                oldElement.PropertyChanged -= HandlePropertyChanged;

            Element = element;
            if (Element != null)
            {
                //UpdateContent ();
                Element.PropertyChanged += HandlePropertyChanged;
            }

            ViewGroup.RemoveAllViews();
            //sizes to match the forms view
            //updates properties, handles visual element properties
            Tracker = new VisualElementTracker(this);
            Packager = new VisualElementPackager(this);
            Packager.Load();

            UseCompatPadding = true;

            SetContentPadding((int)TheView.Padding.Left, (int)TheView.Padding.Top,
              (int)TheView.Padding.Right, (int)TheView.Padding.Bottom);

            Radius = TheView.CornerRadius;

            SetCardBackgroundColor(TheView.BackgroundColor.ToAndroid());

            ElementChanged?.Invoke(this, new VisualElementChangedEventArgs(oldElement, Element));
        }

        private Card TheView => (Card)Element;

        void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Content")
            {
                Tracker.UpdateLayout();
            }
            else if (e.PropertyName == Xamarin.Forms.Layout.PaddingProperty.PropertyName)
            {
                SetContentPadding((int)TheView.Padding.Left, (int)TheView.Padding.Top,
                  (int)TheView.Padding.Right, (int)TheView.Padding.Bottom);
            }
            else if (e.PropertyName == Card.CornerRadiusProperty.PropertyName)
            {
                Radius = TheView.CornerRadius;
            }
            else if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                SetCardBackgroundColor(TheView.BackgroundColor.ToAndroid());
            }
        }

        public SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
            Measure(widthConstraint, heightConstraint);

            //Measure child here and determine size
            return new SizeRequest(new Size(MeasuredWidth, MeasuredHeight));
        }

        public void UpdateLayout()
        {
            Tracker?.UpdateLayout();
        }

        public VisualElementTracker Tracker { get; private set; }

        public VisualElementPackager Packager { get; private set; }

        public ViewGroup ViewGroup => this;

        public VisualElement Element { get; private set; }
    }
}