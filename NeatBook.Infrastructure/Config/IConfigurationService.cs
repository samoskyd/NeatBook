using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Infrastructure.Config
{
    public interface IConfigurationService
    {
        string GetConnectionString();
    }
}
