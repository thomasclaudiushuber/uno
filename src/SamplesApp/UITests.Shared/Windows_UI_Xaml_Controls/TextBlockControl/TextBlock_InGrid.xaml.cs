using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Uno.UI.Samples.Controls;

namespace UITests.Windows_UI_Xaml_Controls.TextBlockControl
{
	[Sample]
	public sealed partial class TextBlock_InGrid : Page
	{
		public TextBlock_InGrid()
		{
			this.InitializeComponent();

			text1.LayoutUpdated += (snd, evt) => out1.Text = GetTextLayoutDetails(snd);
			text2.LayoutUpdated += (snd, evt) => out2.Text = GetTextLayoutDetails(snd);
			text3.LayoutUpdated += (snd, evt) => out3.Text = GetTextLayoutDetails(snd);
			text4.LayoutUpdated += (snd, evt) => out4.Text = GetTextLayoutDetails(snd);
			text5.LayoutUpdated += (snd, evt) => out5.Text = GetTextLayoutDetails(snd);
			text6.LayoutUpdated += (snd, evt) => out6.Text = GetTextLayoutDetails(snd);

			string GetTextLayoutDetails(object snd)
			{
				var text = snd as TextBlock;
				var availableSize = LayoutInformation.GetAvailableSize(text);
				var desiredSize = text.DesiredSize;
				var layoutSlot = LayoutInformation.GetDesiredSize(text);
				var actualSize = text.ActualSize;
				var output = $"{text.Name}: AvailableSize={availableSize}, desiredSize={desiredSize}, Slot={layoutSlot}, ActualSize={actualSize}";
				return output;
			}
		}
	}
}
