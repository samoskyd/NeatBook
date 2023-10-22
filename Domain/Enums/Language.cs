using NeatBook.Domain.Enums.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Domain.Enums
{
    public enum Language
    {
        [StringValue("Ukrainian")]
        Ukrainian,
        [StringValue("English")]
        English
    }
}
