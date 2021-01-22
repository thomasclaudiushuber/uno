using System;
using System.Collections.Generic;
using System.Text;
using Windows.Globalization;

namespace Windows.ApplicationModel.Resources.Core
{
	public partial class ResourceContext
	{
		private static ResourceContext _instance = new ResourceContext();

		public ResourceContext()
		{
		}

		public static ResourceContext GetForCurrentView() => _instance;

		public static ResourceContext GetForViewIndependentUse() => _instance;

		public void Reset()
		{
			// force the reload resources
			ResourceLoader.DefaultLanguage = ApplicationLanguages.PrimaryLanguageOverride;
		}
	}
}
