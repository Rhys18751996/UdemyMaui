namespace UdemyMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		// this is the initial page of the application
		MainPage = new ContentPageDemo();

        //Original initial page
        //MainPage = new AppShell();
    }
}
