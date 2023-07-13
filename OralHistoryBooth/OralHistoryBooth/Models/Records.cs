using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OralHistoryBooth.Models
{
    public class Records
    {
        public string Project { get; set; }
        public List<UserData> UserData { get; set; }  
 
        public string Username { get; set; }
        public string Password { get; set; }
    
        public Records()
        {
            Project = "Oral History Booth";

            UserData = new List<UserData>();

            Username = "abc";
            Password = "123";
        }
    }
}
