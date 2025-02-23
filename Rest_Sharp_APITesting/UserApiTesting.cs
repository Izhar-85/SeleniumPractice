using Bogus;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;
using System.Text.Json;
using System.Threading;

namespace Rest_Sharp_APITesting
{
    public class UserApiTesting
    {
        private IRestClient restClient;

        [SetUp]
        public void Create_the_RestSharp_Client()
        {
            restClient = new RestClient("https://reqres.in/api/");
        }

        [Test, Description("Get record By ID")]
        public void Get_the_user_data_by_using_id()
        {
            var request = new RestRequest("users/{id}", Method.Get);
            request.AddUrlSegment("id", 2);
            var response = restClient.Execute(request);
            Assert.That(response.StatusCode.ToString(), Is.EqualTo("OK"));
            if (response.IsSuccessStatusCode)
            {
                //JObject obj = JObject.Parse(response.Content);
                //var name = obj["data"]["first_name"].ToString();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
                Assert.Multiple(() =>
                {
                    Assert.That(apiResponse.Data.First_Name, Is.EqualTo("Janet"), "Wrong name is appearing");
                    Assert.That(apiResponse.Data.Last_Name, Is.EqualTo("Weaver"), "Wrong name is appearing");
                });
            }
        }

        [Test, Description("Get all the users")]
        public void Get_all_the_user()
        {
            var request = new RestRequest("users", Method.Get);
            request.AddQueryParameter("page", "2");
            var response = restClient.Execute(request);
            if (response.IsSuccessful)
            {
                var objectData = JsonConvert.DeserializeObject<AllUser>(response.Content);
                Assert.That(objectData.data.FirstOrDefault(x => x.First_Name.Equals("George")), Is.Not.Null);
            }
        }

        [Test, Description("Create the new user ")]
        public void Create_the_new_user()
        {
            var request = new RestRequest("users", Method.Post);
            request.AddJsonBody(new { name = "Izhar", job = "Softwer Engineer" });
            var response = restClient.Execute(request);
            if (response.IsSuccessful)
            {
                JObject obj = JObject.Parse(response.Content);
                var name = obj["job"].ToString();
            }
        }

        [Test, Description("Update the user details")]
        public void Update_the_user_details_using_userID()
        {
            var request = new RestRequest("users/{id}", Method.Put);
            request.AddUrlSegment("id", 2);
            request.AddJsonBody(new { name = "Izhar", job = "leader" });
            var response = restClient.Execute(request);
            if (response.IsSuccessful)
            {
                JObject obj = JObject.Parse(response.Content);
                var name = obj["name"].ToString();
                var job = obj["job"].ToString();
                var time = obj["updatedAt"].ToString();
            }
        }

        [Test, Description("Delete the perticuler user by ID")]
        public void Delete_the_user_by_userID()
        {
            var request = new RestRequest("users/{id}", Method.Delete);
            request.AddUrlSegment("id", 2);
            var response = restClient.Execute(request);
            if (response.IsSuccessful)
            {
                Console.WriteLine("user deleted successfully...");
            }
        }

        [Test, Description("HttpBasicAuthenticator is set at the client level,Every request made using this RestClient will automatically include the Authorization header")]
        public void Check_the_basic_authantication_at_client_level()
        {
            var options = new RestClientOptions("https://httpbin.org/basic-auth/");
            options.Authenticator = new HttpBasicAuthenticator("izhar", "izhar123");
            var client = new RestClient(options);
            var request = new RestRequest("izhar/izhar123", Method.Get);
            var response = client.Execute(request);
            var data = JsonConvert.DeserializeObject<dynamic>(response.Content);
            string userName = (string)data.user;
        }

        [Test, Description("Authentication only to this specific request.")]
        public void Check_the_basic_authantication_at_specific_request_level()
        {
            var client = new RestClient("https://httpbin.org/basic-auth/");
            var request = new RestRequest("izhar/izhar123", Method.Get);
            var credentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("izhar:izhar123"));
            request.AddHeader("Authorization", $"Basic {credentials}");
            var response = client.Execute(request);
            var data = JsonConvert.DeserializeObject<dynamic>(response.Content);
            string userName = (string)data.user;
        }

        [Test]
        public void Varify_the_cookies_and_get_the_values()
        {
            var client = new RestClient("https://httpbin.org/");
            var request = new RestRequest("cookies", Method.Get);
            var response = client.Execute(request);
            var ss = response.Cookies;
            foreach(var cokk in response.Cookies)
            {
                Console.WriteLine($"{cokk}");
            }
        }

        [Test]
        public void Add_the_header_to_handle_different_type_of_content_like_json_xml()
        {
            var client = new RestClient("https://httpbin.org/");
            var request = new RestRequest("headers", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            request.AddHeader("name", "Izhar khan");
            var response = client.Execute(request);
            foreach(var had in response.Headers) 
            {
                Console.WriteLine($"{had.Name} : { had.Value}");
            }
            //Assert.That(response.Headers.Any(h => h.Name == "Connection" && h.Value == "keep-alive"), Is.True);
            //var data = JsonConvert.DeserializeObject<dynamic>(response.Content);
        }

        [Test]
        public void Handle_query_parameters_in_RestSharp()
        {
            var client = new RestClient("https://httpbin.org/");
            var request = new RestRequest("response-headers", Method.Get);
            request.AddQueryParameter("freeform", "2003");
            request.AddQueryParameter("form", "2005");
            var response = client.Execute(request);
            var data = JsonConvert.DeserializeObject<dynamic>(response.Content);
        }

        [Test]
        public async Task Mock_API_responses_in_unit_tests_using_RestSharpAsync()
        {
            var mockClient = new Mock<RestClient>(); // Mock RestClient
            var mockRequest = new Mock<RestRequest>(); // Mock RestRequest

            var fakeResponseObject = new { message = "Success" };
            string jsonResponse = JsonConvert.SerializeObject(fakeResponseObject);

            var mockResponse = new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content = jsonResponse
            };

            // Use ReturnsAsync for async Execute() method
            mockClient.Setup(client => client.ExecuteAsync(It.IsAny<RestRequest>(), Method.Get)).ReturnsAsync(mockResponse);

            var result = await mockClient.Object.ExecuteAsync(mockRequest.Object, Method.Get);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(result.Content, Is.EqualTo(jsonResponse));
        }

        [Test]
        public void Create_the_User_and_post_the_data_using_faker_library()
        {
            var request = new RestRequest("users", Method.Post);
            var fakeUser = new Faker();
            string firstname =fakeUser.Name.FullName();
            string jobname = fakeUser.Name.JobTitle();

            request.AddJsonBody(new { name = firstname, job = jobname });
            var response = restClient.Execute(request);
            if (response.IsSuccessful)
            {
                JObject obj = JObject.Parse(response.Content);
                var job = obj["job"].ToString();
                var name = obj["name"].ToString();
                Console.WriteLine($"{name} is a {job}");
            }
        }
    }
}