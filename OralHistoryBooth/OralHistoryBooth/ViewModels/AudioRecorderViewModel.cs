using OralHistoryBooth.Models;
using System;
using System.ComponentModel;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml;



namespace OralHistoryBooth
{
    public class AudioRecorderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        LowLagMediaRecording _mediaRecording;
        MediaCapture mediaCapture;
        public OtherData TimeKeeper = new OtherData();
        private readonly DispatcherTimer Time;
        private int BaseTime;
        private TimeSpan converter;
        private OtherData TimeLeft;
        private Records records;
        private readonly OtherData Data;
        public Visibility MicrophoneWarning
        {
            get { return Data.MicrophoneDetected; }
            set { Data.MicrophoneDetected = value; }
        }

        public bool IsStartEnabled
        {
            get { return Data.IsStartEnabled; }
            set { Data.IsStartEnabled = value; }
        }

        public bool IsStopEnabled
        {
            get { return Data.IsStopEnabled; }
            set { Data.IsStopEnabled = value; }
        }

        public bool IsPauseEnabled
        {
            get { return Data.IsPauseEnabled; }
            set { Data.IsPauseEnabled = value; }
        }

        public bool IsResumeEnabled
        {
            get { return Data.IsResumeEnabled; }
            set { Data.IsResumeEnabled = value; }
        }

        public string TimerString
        {
            get { return Data.TimeLeftString; }
            set { Data.TimeLeftString = value; }
        }

        public Visibility MediaPlayerActive
        {
            get { return Data.MediaPlayerActive; }
            set { Data.MediaPlayerActive = value; }
        }
        public async void BeginRecording()
        {
                try
                {
                mediaCapture = new MediaCapture();
                await mediaCapture.InitializeAsync();
                mediaCapture.Failed += MediaCapture_Failed;
                mediaCapture.RecordLimitationExceeded += MediaCapture_RecordLimitationExceeded;
                var localFolder = ApplicationData.Current.LocalFolder;
                StorageFile file = await localFolder.CreateFileAsync("audio.mp3", CreationCollisionOption.GenerateUniqueName);

                _mediaRecording = await mediaCapture.PrepareLowLagRecordToStorageFileAsync(
                    MediaEncodingProfile.CreateMp3(AudioEncodingQuality.High), file);
                await _mediaRecording.StartAsync();
                IsStartEnabled = false; // Disable Start Recording button 
                IsStopEnabled = true;   // Enable Stop Recording button
                IsPauseEnabled = true;  // Enable Pause Recording button
                OnPropertyChanged("IsPauseEnabled");
                OnPropertyChanged("IsRecordEnabled");
                OnPropertyChanged("IsStopEnabled");
                MicrophoneWarning = Visibility.Collapsed;
                OnPropertyChanged("MicrophoneWarning");
                StartTimer();
                }  catch (System.Exception)
                {
                MicrophoneWarning = Visibility.Visible;
                OnPropertyChanged("MicrophoneWarning");
                }
        }

        public async void StopRecording()
        {
            MediaPlayerActive = Visibility.Visible;
            OnPropertyChanged("MediaPlayerActive");
           await _mediaRecording.StopAsync();
            Time.Stop();
        }

        public async void PauseRecording()
        {
            await _mediaRecording.PauseAsync(Windows.Media.Devices.MediaCapturePauseBehavior.ReleaseHardwareResources);
            Time.Stop();
        }
        public async void ResumeRecording()
        {
            await _mediaRecording.ResumeAsync();
            Time.Start();
        }
        private void MediaCapture_RecordLimitationExceeded(MediaCapture sender) // If recording exceeds 3 hours throw exception
        {
            throw new System.Exception("Media Capture Limitation Exceeded");
        }

        private void MediaCapture_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            throw new System.Exception("Error Message: " + errorEventArgs.Message);
        }
        
        public AudioRecorderViewModel()
        {
            this.records = new Records();
            Time = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            Time.Tick += Time_Tick;
           //TimeLeft = new Timer();
            Data = new OtherData();

        }

        public string Username
        {
            get { return records.Username; }
            set { records.Username = value; 
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return records.Password; }
            set
            {
                records.Password = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private void Time_Tick(object sender, object e)
        {
            BaseTime -= 1;
            converter = TimeSpan.FromSeconds(BaseTime);
            TimerString = converter.ToString().Substring(3);
            if (BaseTime == 0)
            {
                Time.Stop();
                StopRecording();
            }
            OnPropertyChanged("TimerString");
        }
        public void StartTimer()
        {
            BaseTime = 600;
            converter = TimeSpan.FromSeconds(BaseTime);
            TimerString = converter.ToString().Substring(3);
            Time.Start();
        }
        public void StartTimerLogOut()
        {
            BaseTime = 3;
            converter = TimeSpan.FromSeconds(BaseTime);
            TimerString = converter.ToString().Substring(3);
            Time.Start();
        }

        

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Theater name or MovieViewModel changed, so let UI know
            PropertyChanged?.Invoke(sender, e);
        }


        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
