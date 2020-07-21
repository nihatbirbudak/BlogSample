using BlogSample.Core.Services;
using BlogSample.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.BLL.Abstract
{
    public interface IContactService : IServiceBase
    {
        List<ContactDTO> getAll();
        ContactDTO getContact(int Id);
        List<ContactDTO> getContactName(string ContactName);
        ContactDTO newContact(ContactDTO contact);
        ContactDTO updateContact(ContactDTO contact);
        bool deleteContact(int contactId);
    }
}
