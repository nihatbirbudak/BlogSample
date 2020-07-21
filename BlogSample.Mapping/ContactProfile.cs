using BlogSample.DTO;
using BlogSample.Mapping.ConfigProfile;
using BlogSample.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.Mapping
{
    public class ContactProfile : ProfileBase
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}
