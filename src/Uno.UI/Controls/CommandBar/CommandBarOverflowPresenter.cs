#if XAMARIN
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Controls
{
	public  partial class CommandBarOverflowPresenter : ItemsControl
	{
		public CommandBarOverflowPresenter() : base()
		{
			ItemsPanel = new ItemsPanelTemplate(() => new StackPanel());
		}
	}
}
#endif
