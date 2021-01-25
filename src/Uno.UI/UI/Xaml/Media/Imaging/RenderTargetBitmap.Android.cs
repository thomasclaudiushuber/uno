#if __ANDROID__
using System;
using System.Collections.Generic;
using MyPath = System.IO.Path;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Android.Graphics;
using Uno.UI;

namespace Windows.UI.Xaml.Media.Imaging
{ 
	partial class RenderTargetBitmap
	{
		private async Task<Stream> GetImageStream(UIElement elt, int? width = null, int? height = null)
		{
			if (!(elt is FrameworkElement frameworkElement))
			{
				return null;
			}

			var viewWidth = ViewHelper.LogicalToPhysicalPixels(width ?? frameworkElement.ActualWidth);
			var viewHeight = ViewHelper.LogicalToPhysicalPixels(height ?? frameworkElement.ActualHeight);

			using var bitmap = Bitmap.CreateBitmap(viewWidth, viewHeight, Bitmap.Config.Argb8888);
			using var canvas = new Android.Graphics.Canvas(bitmap);

			var view = frameworkElement as Android.Views.View;
			view.Draw(canvas);

			canvas.DrawColor(Android.Graphics.Color.Transparent);

	

			//if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)))
			//{
			//	Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
			//}

			//string path = MyPath.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), $"{Guid.NewGuid()}.png");

			//using var fs = new FileStream(path, FileMode.Create);
			var stream = new MemoryStream();
		//	await bitmap.CompressAsync(Android.Graphics.Bitmap.CompressFormat.Png, 100, fs);
			await bitmap.CompressAsync(Android.Graphics.Bitmap.CompressFormat.Png, 100, stream);
			bitmap.Recycle();
			stream.Position = 0;
			return stream;
		}
	}
}
#endif
