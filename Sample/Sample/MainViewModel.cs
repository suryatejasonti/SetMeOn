using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class MainViewModel:ObservableObject
    {
        private ObservableCollection<YBItem> _Items = new ObservableCollection<YBItem>();
        public ObservableCollection<YBItem> Items
        {
            get { return _Items; }
            set { SetProperty(ref _Items, value); }
        }

        public async Task GetDataAsync(int pageCount)
        {
            var items = await App.TodoManager.GetTasksAsync(pageCount);
            foreach(var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
