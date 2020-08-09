using GroctaXP.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;


namespace GroctaXP.Services
{
    public class DataService : IDataService
    {
        static DocumentClient documentClient;
        public Task AddUser(Models.User user)
        {
            IDocumentClient client = new DocumentClient(new Uri("https://cosmos-grocta-dev.documents.azure.com:443/"), "WdGI6mYIlDg2Pzmu4EUFRcNBxgfKNfr0VXCzbR1tkSlJ26tmqqBDjdoa1JesGON5TLcVFlbOOKKSFoKqJqfiWQ==");
            try
            {
                var document1 = client.CreateDocumentAsync( UriFactory.CreateDocumentCollectionUri("groctadb", "UserContainer"),   user);
                document1.Wait();
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
            finally
                {
                if (client != null) client = null;
            }

            return Task.CompletedTask;
        }
    }
}
