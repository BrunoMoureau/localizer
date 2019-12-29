# Xamarin.Forms - Localizer

This example project uses a simple text localization for Xamarin.Forms.

- Specify the default culture
- Localize text
- Localize images (platform specificities !) + Consume localized images
=> https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/localization/text?pivots=windows

To support a new culture, add a new AppResources with the culture identifier (e.g. AppResources.es.resx).

You can switch the app language using : 
CultureInfo cultureInfo = new CultureInfo("en-GB");
DependencyService.Get<ILocalizer>().SetCulture(cultureInfo);

You can also use localized images on each platform project.
https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/localization/text?pivots=windows


Sources : 

https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/localization/text?pivots=windows

 - Android
 - iOS
 
 https://docs.microsoft.com/en-us/xamarin/ios/app-fundamentals/localization/

 
 
 - UWP
 
 
 - More information and advices
 
 https://docs.microsoft.com/en-us/windows/uwp/design/globalizing/guidelines-and-checklist-for-globalizing-your-app
 https://docs.microsoft.com/en-us/windows/uwp/design/globalizing/adjust-layout-and-fonts--and-support-rtl
 
 
 Todo :
 - RTL (mirroring with FlowDirection)
 - Add localize images in platform projects