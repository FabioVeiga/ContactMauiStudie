using Contacts.Models;

namespace Contacts.Views;

public partial class AddContactPage : ContentPage
{
    public AddContactPage()
	{
		InitializeComponent();
	}

  //  void btnCancel_Clicked(System.Object sender, System.EventArgs e)
  //  {
		////.. navigate to de previues page
		////Shell.Current.GoToAsync("..");
		////Absolute path eus //
		//Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
  //  }

    void contactCtrl_OnSave(System.Object sender, System.EventArgs e)
    {
        var contact = new Models.Contact() {
            Address = contactCtrl.Address,
            Email = contactCtrl.Email,
            Name = contactCtrl.Name,
            Phone = contactCtrl.Phone
        };

        ContactRepository.AddContact(contact);
        Shell.Current.GoToAsync("..");
    }

    void contactCtrl_OnCancel(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    void contactCtrl_OnError(System.Object sender, System.String e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}
