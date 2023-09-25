using Contacts.Models;
using Contact = Contacts.Models.Contact;

namespace Contacts.Views;

//receive parameters
[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactPage : ContentPage
{
	private Contact contact;

	public EditContactPage()
	{
        InitializeComponent();
	}

	void btnCancel_Clicked(Object sender, EventArgs e) {
		Shell.Current.GoToAsync("..");
	}

	public string ContactId {
		set {
			contact = ContactRepository.GetContactById(int.Parse(value));
			if(contact != null) {
                contactCtrl.Name = contact.Name;
                contactCtrl.Email = contact.Email;
                contactCtrl.Address = contact.Address;
                contactCtrl.Phone = contact.Phone;
			}
		}
	}

    void btnUpdate_Clicked(Object sender, EventArgs e)
    {
		contact.Name = contactCtrl.Name;
		contact.Address = contactCtrl.Address;
		contact.Phone = contactCtrl.Phone;
		contact.Email = contactCtrl.Email;

		ContactRepository.UpdateContact(contact.ContactId, contact);
		Shell.Current.GoToAsync("..");
    }

    void contactCtrl_OnError(Object sender, String e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}
