using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamZueri.App.Controls;
using XamZueri.App.iOS.Renderers;

[assembly: ExportRenderer(typeof(Card), typeof(CardRenderer))]

namespace XamZueri.App.iOS.Renderers
{
    public class CardRenderer : ViewRenderer<Card, UIView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Card> e)
        {
            base.OnElementChanged(e);


            if (Control == null)
            {
                SetNativeControl(new UIView());
            }

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= OnPropertyChanged;
            }

            if (e.NewElement != null)
            {
                e.NewElement.PropertyChanged += OnPropertyChanged;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == Card.CornerRadiusProperty.PropertyName || args.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                SetNeedsDisplay();
            }
        }


        protected override void SetBackgroundColor(Color color)
        {
            
            // don't set the background color, will be done in draw
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            using (var context = UIGraphics.GetCurrentContext())
            {
                CGRect contentRect = rect.Inset(Element.CornerRadius, Element.CornerRadius);

                UIBezierPath roundedPath = UIBezierPath.FromRoundedRect(contentRect, Element.CornerRadius);
                context.SetFillColor(UIColor.White.CGColor);
                context.SetShadow(new CGSize(0, 0), Element.CornerRadius, UIColor.Black.ColorWithAlpha(0.5f).CGColor);

                roundedPath.Fill();

                roundedPath.AddClip();

                context.SetStrokeColor(UIColor.Black.ColorWithAlpha(0.6f).CGColor);
                context.SetBlendMode(CGBlendMode.Overlay);

                context.MoveTo(contentRect.GetMinX(), contentRect.GetMinY() + 0.5f);
                context.AddLineToPoint(contentRect.GetMinX(), contentRect.GetMinY() + 0.5f);
                context.StrokePath();
            }
        }
    }
}
