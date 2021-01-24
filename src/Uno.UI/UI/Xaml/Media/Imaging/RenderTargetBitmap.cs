using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Media.Imaging
{
	public partial class RenderTargetBitmap : ImageSource
	{
		public int PixelHeight
		{
			get => (int) this.GetValue(PixelHeightProperty);
			private set => this.SetValue(PixelHeightProperty, value);
		}

		public int PixelWidth
		{
			get => (int)this.GetValue(PixelWidthProperty);
			private set => this.SetValue(PixelWidthProperty, value);
		}

		public static global::Windows.UI.Xaml.DependencyProperty PixelHeightProperty { get; } =
		Windows.UI.Xaml.DependencyProperty.Register(
			nameof(PixelHeight), typeof(int),
			typeof(global::Windows.UI.Xaml.Media.Imaging.RenderTargetBitmap),
			new FrameworkPropertyMetadata(default(int)));


		public static global::Windows.UI.Xaml.DependencyProperty PixelWidthProperty { get; } =
		Windows.UI.Xaml.DependencyProperty.Register(
			nameof(PixelWidth), typeof(int),
			typeof(global::Windows.UI.Xaml.Media.Imaging.RenderTargetBitmap),
			new FrameworkPropertyMetadata(default(int)));

		public global::Windows.Foundation.IAsyncAction RenderAsync(global::Windows.UI.Xaml.UIElement element)
		{
			async Task SetSourceAsync(CancellationToken ct)
			{
				Stream = await GetImageStream(element);
			}

			return AsyncAction.FromTask(SetSourceAsync);
		}

		public global::Windows.Foundation.IAsyncAction RenderAsync(global::Windows.UI.Xaml.UIElement element, int scaledWidth, int scaledHeight)
		{
			async Task SetSourceAsync(CancellationToken ct)
			{
				Stream = await GetImageStream(element, scaledWidth, scaledHeight);
			}

			return AsyncAction.FromTask(SetSourceAsync);
		}

		public global::Windows.Foundation.IAsyncOperation<global::Windows.Storage.Streams.IBuffer> GetPixelsAsync()
		{
			throw new global::System.NotImplementedException("The member IAsyncOperation<IBuffer> RenderTargetBitmap.GetPixelsAsync() is not implemented in Uno.");
		}
	}
}
