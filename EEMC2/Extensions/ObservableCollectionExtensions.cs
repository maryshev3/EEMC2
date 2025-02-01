using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void RemoveFirst<T>(this ObservableCollection<T> observableCollection, Func<T, bool> filter) where T : class
        {
            T itemToRemove = null;

            foreach (var item in observableCollection) 
            {
                if (filter(item))
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove != null)
            {
                observableCollection.Remove(itemToRemove);
            }
        }
    }
}
