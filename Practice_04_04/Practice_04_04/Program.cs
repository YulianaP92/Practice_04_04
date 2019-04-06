using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Practice_04_04
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            GetList();
            //GetBookId();
            //PostCreateBook();
            //PutBookId();
            //DeleteBook();
            Console.ReadLine();
        }

        //Get/api/books
        public static void GetList()
        {
            var responce = client.GetAsync("https://EugeneTestWebApp.AzureWebSites.net/api/books")
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
            var stringContext = responce.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine(stringContext);
        }
        //Get/api/books/id
        public static void GetBookId()
        {
            var id = Convert.ToInt32(Console.ReadLine());
            var responce = client.GetAsync($"https://EugeneTestWebApp.AzureWebSites.net/api/books/{id}")
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
            var stringContext = responce.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine(stringContext);
        }

        //Post/api/books/
        public static void PostCreateBook()
        {
            var content = new StringContent(JsonConvert.SerializeObject(new { Id = 2, Title = "Book" }), Encoding.UTF8, "application/json");
            var responce = client.PostAsync("https://EugeneTestWebApp.AzureWebSites.net/api/books", content).
                ConfigureAwait(false).
                GetAwaiter().
                GetResult();
            var stringContext = responce.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine(stringContext);
        }
        //Put/api/books/id
        public static void PutBookId()
        {
            var id = Convert.ToInt32(Console.ReadLine());
            var putStrContent = new StringContent(JsonConvert.SerializeObject(new { Title = "Book_3" }), Encoding.UTF8, "application/json");
            var responce = client.PutAsync($"https://EugeneTestWebApp.AzureWebSites.net/api/books/{id}", putStrContent)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }
        //Delete/api/books/id
        public static void DeleteBook()
        {
            var id = Convert.ToInt32(Console.ReadLine());
            client.DeleteAsync($"https://EugeneTestWebApp.AzureWebSites.net/api/books/{id}")
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }
    }
}
