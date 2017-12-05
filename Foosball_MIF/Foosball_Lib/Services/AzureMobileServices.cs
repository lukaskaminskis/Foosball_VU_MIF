using Foosball_Lib.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_Lib.Services
{
    class AzureMobileServices
    {
        public MobileServiceClient Client { get; private set; }
        private IMobileServiceSyncTable<User> userTable;

        public AzureMobileServices()
        {
            Initialize();
        }

        public async Task Initialize()
        {
            Client = new MobileServiceClient(Labels.AppUrl);

            var path = Path.Combine(MobileServiceClient.DefaultDatabasePath, "test.db");

            var store = new MobileServiceSQLiteStore(path);

            store.DefineTable<User>();

            await Client.SyncContext.InitializeAsync(store);

            userTable = Client.GetSyncTable<User>();
        }

        private async Task SyncUsers()
        {
            try
            {
                await userTable.PullAsync("allUsers", userTable.CreateQuery());
                await Client.SyncContext.PushAsync();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                await SyncUsers();
                return await userTable.ToListAsync();
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                await userTable.InsertAsync(user);
                await SyncUsers();
                return true;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


    }
}
