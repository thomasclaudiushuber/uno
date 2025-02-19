#if !__UWP__
using System;
using System.Collections.Generic;
using System.Text;
using Uno.UI;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls
{
	/// <summary>
	/// PopupPanel implementation for <see cref="FlyoutBase"/>.
	/// </summary>
	/// <remarks>
	/// This panel is *NOT* used by types derived from <see cref="PickerFlyoutBase"/>. Pickers use a plain
	/// <see cref="PopupPanel"/> (see <see cref="PickerFlyoutBase.InitializePopupPanel()"/>).
	/// </remarks>
	internal partial class FlyoutBasePopupPanel : PlacementPopupPanel
	{
		private readonly FlyoutBase _flyout;

		public FlyoutBasePopupPanel(FlyoutBase flyout) : base(flyout._popup)
		{
			_flyout = flyout;

			// Required for the dismiss handling
			// This should however be customized depending of the Popup.DismissMode
			Background = new SolidColorBrush(Windows.UI.Colors.Transparent);
		}

		protected override FlyoutPlacementMode PopupPlacement => _flyout.EffectivePlacement;

		protected override FrameworkElement AnchorControl => _flyout.Target as FrameworkElement;

		protected override Point? PositionInAnchorControl => _flyout.PopupPositionInTarget;

		internal override FlyoutBase Flyout => _flyout;
	}
}
#endif
