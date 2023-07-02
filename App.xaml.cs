using System.Security.Cryptography.X509Certificates;
using UdemyMaui.MVVM.Views;
using UdemyMaui.Repositories;

namespace UdemyMaui;

public partial class App : Application
{
    // this makes access to database throughout application
    public static CustomerRepository CustomerRepo { get; private set; }

	public App(CustomerRepository repo)
	{
		InitializeComponent();

        CustomerRepo = repo;

        MainPage = new SqlPage();

        //var navPage = new NavigationPage(new MainPage());

        //navPage.BarBackgroundColor = Colors.Chocolate;
        //navPage.BarTextColor = Colors.White; 


        //MainPage = navPage;

    }
}
