using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Infrasturucture.Helpers.Abstractions
{
    public interface IMailService
    {
        Task Activate(string to, int num);        
    }
}
