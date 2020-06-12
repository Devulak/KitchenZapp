using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using KitchenZapp.Models;

namespace KitchenZapp.Services
{
    public class SimpleDataStore : IDataStore<Account>
    {
        private readonly ObservableCollection<Account> items;

        private readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "SimpleDataStore.txt");

        private int incrementer;
        private int Incrementer
        {
            get
            {
                return ++incrementer;
            }
        }

        public SimpleDataStore()
        {
            Console.WriteLine("YAAAAAAAAAA");
            Console.WriteLine("YAAAAAAAAAA");
            Console.WriteLine("YAAAAAAAAAA");
            Console.WriteLine("YAAAAAAAAAA");
            items = new ObservableCollection<Account>()
            {
                new Account { Id = Incrementer, PersonalName = "First Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 },
                new Account { Id = Incrementer, PersonalName = "Second Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 },
                new Account { Id = Incrementer, PersonalName = "Third Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 },
                new Account { Id = Incrementer, PersonalName = "Fourth Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 },
                new Account { Id = Incrementer, PersonalName = "Fifth Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 },
                new Account { Id = Incrementer, PersonalName = "Sixth Dummy", DoorNumber=1337, Birthday = DateTime.UtcNow, Phone = "0045 6969 6969", TagID = 13371337 }
            };

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            items = formatter.Deserialize(fileStream) as ObservableCollection<Account>;
            fileStream.Close();

            if (items.Count > 0)
            {
                incrementer = items.Last().Id;
            }
        }

        private void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream serializer = new FileStream(filePath, FileMode.Create);
            formatter.Serialize(serializer, items);
            serializer.Close();

            Console.WriteLine("Yeet");
        }

        public async Task<bool> AddItemAsync(Account item)
        {
            item.Id = Incrementer;
            items.Add(item);

            Save();

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Account item)
        {
            var oldItem = items.Where(o => o.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            Save();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Account arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            Save();

            return await Task.FromResult(true);
        }

        public async Task<Account> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Account>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}