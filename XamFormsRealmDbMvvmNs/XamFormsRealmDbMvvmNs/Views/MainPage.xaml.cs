using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamFormsRealmDbMvvmNs.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

	    private void Button_OnClickedListOfCustomer(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new ListOfCustomers());
	    }

	    private void Button_OnClickedCreateCustomer(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new CreateCustomer());
	    }

	    private void Button_OnClickedUpdateDeleteCustomer(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new UpdateOrDeleteCustomer());
	    }
	}
}