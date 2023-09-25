using Contacts.Views;

namespace Contacts;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//Register thoses pages
		//Name of da page and type is like keypairvalues
		Routing.RegisterRoute(nameof(ContactPage), typeof(ContactPage));
		Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
		Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
    }
}

