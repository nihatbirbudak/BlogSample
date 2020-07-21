using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Phone { get; set; }
        public bool Read { get; set; }
    }
}
