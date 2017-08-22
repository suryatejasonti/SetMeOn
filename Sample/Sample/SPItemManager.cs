using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Sample
{
    public class SPItemManager
    {
        IRestService restService;

        public SPItemManager(IRestService service)
        {
            restService = service;
        }

        public Task<ObservableCollection<YBItem>> GetTasksAsync(int pageCount)
        {
            return restService.RefreshDataAsync(pageCount);
        }
    }
}
