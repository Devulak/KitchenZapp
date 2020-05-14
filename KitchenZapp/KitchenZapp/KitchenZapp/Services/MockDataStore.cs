using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using KitchenZapp.Models;

namespace KitchenZapp.Services
{
    public class MockDataStore : IDataStore<Account>
    {
        readonly List<Account> items;

        public MockDataStore()
        {
            items = new List<Account>()
            {
                new Account { Id = Guid.NewGuid().ToString(), PersonalName = "First Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 },
                new Account { Id = Guid.NewGuid().ToString(), PersonalName = "Second Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 },
                new Account { Id = Guid.NewGuid().ToString(), PersonalName = "Third Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 },
                new Account { Id = Guid.NewGuid().ToString(), PersonalName = "Fourth Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 },
                new Account { Id = Guid.NewGuid().ToString(), PersonalName = "Fifth Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 },
                new Account { Id = Guid.NewGuid().ToString(), PersonalName = "Sixth Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 }
            };
        }

        public async Task<bool> AddItemAsync(Account item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Account item)
        {
            var oldItem = items.Where((Account arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Account arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Account> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Account>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}