#if __SKIA__

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Windows.UI.Xaml;

namespace Windows.UI.Xaml.Media.Imaging
{
	partial class RenderTargetBitmap
	{
		private Task<Stream> GetImageStream(UIElement elt, int? width = null, int? height = null)
		{
			if (!(elt is FrameworkElement frameworkElement))
			{
				return Task.FromResult<Stream>(null);
			}

			height ??= (int)frameworkElement.ActualHeight;
			width ??= (int)frameworkElement.ActualWidth;

			var info = new SKImageInfo(width.Value, height.Value, SKImageInfo.PlatformColorType, SKAlphaType.Premul);
			using var bitmap = new SKBitmap(width.Value, height.Value, SKColorType.Rgba8888, SKAlphaType.Premul);
			using var surface = SKSurface.Create(info, bitmap.GetPixels(out _));
			surface.Canvas.Clear(SKColors.Transparent);
			elt.Visual.Parent?.Render(surface, info);

			using var image = surface.Snapshot();
			using var data = image.Encode(SKEncodedImageFormat.Png, 100);

			if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)))
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
			}

			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), $"{Guid.NewGuid()}.png");

			using var fs = new FileStream(path, FileMode.Create);
			data.SaveTo(fs);
			return Task.FromResult(data.AsStream());
		}
	}
}


#endif
