using System;
namespace Contacts.Models
{
	public static class ContactRepository
	{
		public static List<Contact> _contacts = new List<Contact>() {
            new Contact {ContactId = 1, Name = "John Doe", Email = "JohnDoe@gmail.com"},
            new Contact {ContactId = 2, Name = "Jane Doe", Email = "JaneDoe@gmail.com"},
            new Contact {ContactId = 3, Name = "Tom Hanks", Email = "TomHanks@gmail.com"},
            new Contact {ContactId = 4, Name = "FrankLiu", Email = "FrankLiu@gmail.com"}
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int id) {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == id);
            if(contact != null) {
                return new Contact() {
                    ContactId = id,
                    Address = contact.Address,
                    Email = contact.Email,
                    Name = contact.Name,
                    Phone = contact.Phone
                };
            }
            return null;
        }

        public static void UpdateContact(int id, Contact contact) {
            if (contact.ContactId != id) return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == id);
            if (contactToUpdate != null) {
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Name = contact.Name;
            }
        }

        public static void AddContact(Contact contact) {
            var maxId = _contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            _contacts.Add(contact);
        }

        public static void DeleteContact(int id) {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == id);
            if(contact != null) {
                _contacts.Remove(contact);
            }
        }

        public static List<Contact> SearchContacts(string filterText) {
            var result = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            if(result is null || result.Count == 0)
               result = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.Contains(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            if (result is null || result.Count == 0)
                result = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            if (result is null || result.Count == 0)
                result = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.Contains(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            return result;
        }
    }
}

