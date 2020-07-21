using BlogSample.BLL.Abstract;
using BlogSample.Core.Data.UnitOfWork;
using BlogSample.DTO;
using BlogSample.Mapping.ConfigProfile;
using BlogSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSample.BLL.BlogService
{
    public class ContactService : IContactService
    {
        private readonly IUnitofWork uow;
        public ContactService(IUnitofWork _uow)
        {
            uow = _uow;
        }
        public bool deleteContact(int contactId)
        {
            try
            {
                var delete = uow.GetRepository<Contact>().Get(z => z.Id == contactId);
                uow.GetRepository<Contact>().Delete(delete);
                uow.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public List<ContactDTO> getAll()
        {
            var list = uow.GetRepository<Contact>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<ContactDTO>>(list);
        }

        public ContactDTO getContact(int Id)
        {
            var contact = uow.GetRepository<Contact>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<ContactDTO>(contact);
        }

        public List<ContactDTO> getContactName(string ContactName)
        {
            var getName = uow.GetRepository<Contact>().Get(z => z.Title.Contains(ContactName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<ContactDTO>>(getName);
        }

        public ContactDTO newContact(ContactDTO contact)
        {
            if (!uow.GetRepository<Contact>().GetAll().Any(z => z.Title == contact.Title))
            {
                var added = MapperFactory.CurrentMapper.Map<Contact>(contact);
                uow.GetRepository<Contact>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ContactDTO>(added);
            }
            else
            {
                return null;
            }
        }

        public ContactDTO updateContact(ContactDTO contact)
        {
            var update = uow.GetRepository<Contact>().Get(z => z.Id == contact.Id);
            update = MapperFactory.CurrentMapper.Map<Contact>(contact);
            uow.GetRepository<Contact>().Update(update);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ContactDTO>(update);
        }
    }
}
