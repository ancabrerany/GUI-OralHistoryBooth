using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Documents;

namespace OralHistoryBooth.Models
{
#pragma warning disable IDE1006

    public class UserData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int decade { get; set; }

        public bool isHardingStudent { get; set; }
    }
}
