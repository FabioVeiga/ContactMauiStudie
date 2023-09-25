using System.Collections.ObjectModel;
using Contacts.Models;
using Contact = Contacts.Models.Contact;

namespace Contacts.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //using observable to change data to subscribers
        LoadContacts();
    }

    //it's trigger less times
    //better to put logic here
    async void listContacts_ItemSelected(Object sender, SelectedItemChangedEventArgs e)
    {
		//to solve a bug because this trigged twice
		if(listContacts.SelectedItem != null) {
            //using like queries
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
		}
		//listContacts.SelectedItem = null;
    }

	//it's trigger more times
    void listContacts_ItemTapped(Object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    async void btnAdd_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(AddContactPage)}");
    }

    void DeleteClicked(System.Object sender, System.EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contect = menuItem.CommandParameter as Contact;
        ContactRepository.DeleteContact(contect.ContactId);
        LoadContacts();
    }

    private void LoadContacts() {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    void SearchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }
}
