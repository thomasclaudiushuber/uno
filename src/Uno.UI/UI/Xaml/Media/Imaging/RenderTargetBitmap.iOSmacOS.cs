#if __IOS__ || __MACOS__
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media.Imaging
{
	partial class RenderTargetBitmap
	{
		private Task<Stream> GetImageStream(UIElement elt, int? width = null, int? height = null)
		{
			UIImage img;
			if (elt is FrameworkElement frameworkElement)
			{
				try
				{
					UIGraphics.BeginImageContextWithOptions(new Size(width ?? frameworkElement.ActualWidth, height ?? frameworkElement.ActualHeight), false, (nfloat)1.0);
					var ctx = UIGraphics.GetCurrentContext();
					frameworkElement.Layer.RenderInContext(ctx);
					img = UIGraphics.GetImageFromCurrentImageContext();
				}
				finally
				{
					UIGraphics.EndImageContext();
				}
				return Task.FromResult(img.AsPNG().AsStream());
			}
			return Task.FromResult<Stream>(null);
		}
	}
}
#endif
