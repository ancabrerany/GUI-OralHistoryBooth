using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace OralHistoryBooth.Models
{
    public class OtherData 
    {
        public string TimeLeftString { get; set; } = "10:00";  // Default is "10:00"
        public Visibility MicrophoneDetected  {  get; set;  } = Visibility.Collapsed;  // Sets the default value
        public Visibility RecordingFinished { get; set; } = Visibility.Collapsed;


        public bool IsStartEnabled { get; set; } = true;

        public bool IsPauseEnabled { get; set; } = false;

        public bool IsResumeEnabled { get;  set; } = false; 
        public bool IsStopEnabled { get;  set; } = false;

        public Visibility MediaPlayerActive { get; set; } = Visibility.Collapsed;

    }
}
