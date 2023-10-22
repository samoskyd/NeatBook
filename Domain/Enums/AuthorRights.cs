using NeatBook.Domain.Enums.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Domain.Enums
{
    public enum AuthorRights
    {
        [StringValue("None")]
        None,
        [StringValue("Creative Commons")]
        CreativeCommons,
        [StringValue("All rights protected")]
        AllProtected
    }
}
