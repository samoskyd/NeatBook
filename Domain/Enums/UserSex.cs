using NeatBook.Domain.Enums.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Domain.Enums
{
    public enum UserSex
    {
        [StringValue("Male")]
        Male,
        [StringValue("Female")]
        Female,
        [StringValue("Other")]
        Other,
        [StringValue("Prefer not to say")]
        PreferNotToSay
    }
}
