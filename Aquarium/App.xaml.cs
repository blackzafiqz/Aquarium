namespace Aquarium;

public partial class App : Application
{
	public App()
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Nzc5NjI1QDMyMzAyZTMzMmUzMGt6NTBiK3JtUjlVZWROMS9CeFNMUkg0R3VBOVQ1d3lXTmFWdU5PSDA5L0k9\r\n");
        InitializeComponent();

		MainPage = new AppShell();
	}
}
