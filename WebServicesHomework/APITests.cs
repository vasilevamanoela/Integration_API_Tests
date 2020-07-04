using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebServicesHomework.Models;

namespace WebServicesHomework
{
    [TestFixture]
    public class APITests
    {
        private HttpClient _httpClient;
        private Household household;
        private List<User> users;
        private List<Book> books;
        private Book book;
        private User user;

        [SetUp]
        public void SetUp()
        {
            _httpClient = new HttpClient();

            books = new List<Book>();
            users = new List<User>();

            _httpClient.BaseAddress = new Uri("http://localhost:3000");
            _httpClient.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }

        [Test]
        [Order(1)]
        public async Task CreateHousehold()
        {
            household = new Household() { Name = "Sofia" };
            var json = household.ToJson();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/households", content);

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            household = Household.FromJson(responseAsString);

            Assert.IsNotNull(household.Id);
        }

        [Test]
        [Order(2)]
        public async Task CreateUsers()
        {
            for (int i = 0; i < 2; i++)
            {
                user = new User() { Email = "test@gmail.com", HouseholdId = household?.Id };
                var json = user.ToJson();
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/users", content);

                response.EnsureSuccessStatusCode();

                var responseAsString = await response.Content.ReadAsStringAsync();
                user = User.FromJson(responseAsString);

                Assert.IsNotNull(user.Id);
                users.Add(user);
            }
        }

        [Test]
        [Order(3)]
        public async Task CreateBooks()
        {
            book = new Book() { Title = "Test Book" };
            var json = book.ToJson();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/books", content);

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            book = Book.FromJson(responseAsString);

            Assert.IsNotNull(book.Id);
        }

        [Test]
        [Order(4)]
        public async Task AssignToHouseHold()
        {
            var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/wishlists/{user.WishlistId}/books/{book.Id}", content);
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        [Order(5)]
        public async Task CheckHousehold()
        {
            var response = await _httpClient.GetAsync($"/households/{household.Id}/wishlistBooks");
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
