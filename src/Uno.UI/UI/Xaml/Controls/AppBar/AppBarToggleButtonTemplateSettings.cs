using Uno;
using Windows.UI.Xaml;

namespace Windows.UI.Xaml.Controls.Primitives
{
	public partial class AppBarToggleButtonTemplateSettings : DependencyObject
	{
		internal AppBarToggleButtonTemplateSettings()
		{

		}

		public double KeyboardAcceleratorTextMinWidth
		{
			get => (double)GetValue(KeyboardAcceleratorTextMinWidthProperty);
			internal set => SetValue(KeyboardAcceleratorTextMinWidthProperty, value);
		}

		internal static DependencyProperty KeyboardAcceleratorTextMinWidthProperty { get; } =
			DependencyProperty.Register("KeyboardAcceleratorTextMinWidth", typeof(double), typeof(AppBarToggleButtonTemplateSettings), new FrameworkPropertyMetadata(0.0));
	}
}
