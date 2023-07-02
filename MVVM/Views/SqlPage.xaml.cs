using UdemyMaui.MVVM.ViewModels;

namespace UdemyMaui.MVVM.Views;

public partial class SqlPage : ContentPage
{
	public SqlPage()
	{
		InitializeComponent();
		BindingContext = new SqlPageViewModel();
	}
}