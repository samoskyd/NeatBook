using NeatBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Domain.Entities
{
    public class Chapter : BaseAuditableEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string Text { get; set; }
        public bool Published { get; set; }
        public DateTime PublishingDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
