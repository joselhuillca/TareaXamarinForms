using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EduticXamarin.Cells
{
    public class NoticiaCell: ViewCell
    {
        public NoticiaCell()
        {
            var noticiaTitleLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = Device.GetNamedSize(NamedSize.Medium,typeof(Label)),
                TextColor = Color.Blue
            };

            var noticiaiurlImage = new Image
            {
                WidthRequest = 200
            };
            noticiaTitleLabel.SetBinding(Label.TextProperty, new Binding("title"));
            noticiaiurlImage.SetBinding(Image.SourceProperty, new Binding("iurl"));

            View = new StackLayout
            {
                Children = { noticiaiurlImage,noticiaTitleLabel },
                Orientation = StackOrientation.Horizontal
            };
        }
    }
}
