using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using Microsoft.Maui.Storage;
using System;
using System.IO;
using System.Threading;

namespace NETMAUIBigFileSaveExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            //Example of attempting to save a large file using the Community Toolkit FileSaver.  This will work on Windows
            //but fail on Android wven on (for example the Windows Subsystem for Linux where you have the disk space.)



            //Generate a huge dummy file just for the example.
            String sDummyPath = Path.Combine(FileSystem.Current.CacheDirectory, "huge_dummy_file.txt");
            FileStream fs = new FileStream(sDummyPath, FileMode.OpenOrCreate);
            fs.Seek(2048L * 1024 * 1024, SeekOrigin.Begin);
            fs.WriteByte(0);
            fs.Close();


            try
            {
                using (FileStream fileStream = new FileStream(sDummyPath, FileMode.Open, FileAccess.Read))
                {
                    var fileSaverResult = await FileSaver.Default.SaveAsync("huge_dummy_copy.txt", fileStream);
                    if (fileSaverResult.IsSuccessful)
                    {
                        SaveBtn.Text = $"The file was saved successfully to location: {fileSaverResult.FilePath}"; ;
                    }
                    else
                    {
                        SaveBtn.Text = $"The file was not saved successfully with error: {fileSaverResult.Exception.Message}";
                    }
                    fileStream.Close();
                }
            }
            finally
            {

                //Cleanup the original dummy file.
                System.IO.File.Delete(sDummyPath);
            }


               

        }
    }

}
