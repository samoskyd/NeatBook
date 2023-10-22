using NeatBook.Domain.Enums.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Domain.Enums
{
    public enum ArticleGenre
    {
        [StringValue("Science")]
        Science,
        [StringValue("Arts")]
        Arts,
        [StringValue("Sport")]
        Sport,
        [StringValue("Personal")]
        Personal
    }
}
