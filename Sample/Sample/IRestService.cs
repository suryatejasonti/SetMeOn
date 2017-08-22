using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public interface IRestService
    {
        Task<ObservableCollection<YBItem>> RefreshDataAsync(int pageCount);
    }
}
