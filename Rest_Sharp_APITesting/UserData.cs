using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Sharp_APITesting
{
    public class UserData
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Avatar { get; set; }
    }

    public class SupportData
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }

    public class ApiResponse
    {
        public UserData Data { get; set; }
        public SupportData Support { get; set; }
    }

    public class AllUser
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }

        public List<UserData> data { get; set; }

        public SupportData support { get; set; }
    }
}
