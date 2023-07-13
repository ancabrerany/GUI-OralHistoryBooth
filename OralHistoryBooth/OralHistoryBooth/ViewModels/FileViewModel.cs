using OralHistoryBooth.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace OralHistoryBooth.ViewModels
{
    public class FileViewModel
    {
        public async void EditFile(UserData Data)
        {
            string path = ApplicationData.Current.LocalFolder.Path + "\\audio.mp3";

            var tfile = TagLib.File.Create($@"{path}");
            string[] UsersName = new string[1];
            UsersName[0] = Data.firstName + " " + Data.lastName;
            string Title = tfile.Tag.Title;
            tfile.Tag.Title = Data.firstName + " " + Data.lastName + Data.decade;
            tfile.Tag.Performers = UsersName;
            tfile.Tag.Year = (uint)Data.decade;
            if(Data.isHardingStudent) {
                tfile.Tag.Comment = "Harding Student";
            }
            else
            {
                tfile.Tag.Comment = "Not Harding Student";
            }
            tfile.Save();
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            string FileName = "audio.mp3";
            StorageFile RenameFile = await folder.GetFileAsync(FileName);
            await RenameFile.RenameAsync(Data.firstName + " " + Data.lastName + ".mp3");
            

                }

        public async void DeleteFile()
        {
            // Code from https://stackoverflow.com/questions/47214957/how-to-delete-a-file-from-local-disk-in-uwp
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            string FileName = "audio.mp3";
            StorageFile AudioFile = await folder.GetFileAsync(FileName);
            await AudioFile.DeleteAsync();
        }


    }
}
