namespace UdemyMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        MainPage = new MainPage();

        //var navPage = new NavigationPage(new MainPage());

        //navPage.BarBackgroundColor = Colors.Chocolate;
        //navPage.BarTextColor = Colors.White; 


        //MainPage = navPage;

    }
}
