using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ListViewGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static string VISIBLE = "1";
        private static string COLLAPSED = "0";
        public MainPage()
        {
            this.InitializeComponent();
            this.FetchList();
        }

        public async void FetchList()
        {
            string Height = (this.Container.Height / 3).ToString();
            string dir = "Json";
            string filename = "Sample.json";
            string data = await this.Fetch(dir, filename);
            JObject obj = JObject.Parse(data);
            var dataValue = obj["data"];
            //Debug.WriteLine(dataValue.ToString());

            List<ItemModel> objResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemModel>>(dataValue.ToString());

            var counter = 0;
            var i = 0;
            string[] id = new string[3];
            string[] name = new string[3];
            string[] title = new string[3];
            string[] price = new string[3];
            string[] image = new string[3];
            string[] visibility = new string[3];
            foreach (var item in objResponse)
            {
                if (counter > 2)
                {
                    this.Presenters.Add((Height, visibility, id, name, title, price, image));
                    visibility = new string[3];
                    id = new string[3];
                    name = new string[3];
                    title = new string[3];
                    price = new string[3];
                    image = new string[3];
                    counter = 0;
                }

                visibility[counter] = VISIBLE;
                id[counter] = item.ID;
                name[counter] = item.Name;
                title[counter] = item.Title;
                price[counter] = item.Price;
                image[counter] = item.Image;

                if (i == objResponse.Count - 1 && counter < 2)
                {
                    Debug.WriteLine(item.Price);
                    for (var j=counter+1; j <= 2; j++)
                    {
                        visibility[j] = COLLAPSED;
                        id[j] = "";
                        name[j] = "";
                        title[j] = "";
                        price[j] = "";
                        image[j] = "Assets/img.png";
                    }
                    Debug.WriteLine(id[0]);
                    this.Presenters.Add((Height, visibility, id, name, title, price, image));
                }

                counter++;
                i++;
            }

            //Debug.WriteLine(this.Presenters.Length);
            /*
            this.Presenters.Add((
                    new String[] { "1", "2", "3" },
                    new String[] { "Name", "Name", "Name" },
                    new String[] { "asdfasdf", "asdfasdf", "asdf" },
                    new String[] { "324", "234", "234" },
                    new String[] { "Assets/img.png", "Assets/img.png", "Assets/img.png" }
                ));
                */
            this.ListView.ItemsSource = this.Presenters;
        }

        public async Task<string> Fetch(string dir, string fileName)
        {
            var storage = KnownFolders.DocumentsLibrary;
            var folder = await storage.GetFolderAsync(dir);
            var file = await folder.GetFileAsync(fileName);
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            using (var inputStream = stream.GetInputStreamAt(0))
            using (var dataReader = new DataReader(inputStream))
            {
                try
                {
                    ulong size = stream.Size;
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                    return dataReader.ReadString(numBytesLoaded);
                }
                catch
                {
                    throw; // Stack traceを追えるようにするため、再度throwを実行する
                }
                finally
                {
                    // 例外発生時にも解放処理は入れる。
                    dataReader.Dispose();
                    inputStream.Dispose();
                    stream.Dispose();
                }
            }
        }

        private void FirstItemClick(object sender, RoutedEventArgs args)
        {
            var value = (Presenter)((Button)sender).Tag;
            ItemModel model = new ItemModel();
            model.ID = value.ItemID[0];
            model.Name = value.ItemName[0];
            model.Title = value.ItemTitle[0];
            model.Price = value.ItemPrice[0];
            model.Image = value.ItemImage[0];
            Frame.Navigate(typeof(ReceivePage), model);
        }

        private void SecondItemClick(object sender, RoutedEventArgs args)
        {
            var value = (Presenter)((Button)sender).Tag;
            ItemModel model = new ItemModel();
            model.ID = value.ItemID[1];
            model.Name = value.ItemName[1];
            model.Title = value.ItemTitle[1];
            model.Price = value.ItemPrice[1];
            model.Image = value.ItemImage[1];
            Frame.Navigate(typeof(ReceivePage), model);
        }

        private void ThirdItemClick(object sender, RoutedEventArgs args)
        {
            var value = (Presenter)((Button)sender).Tag;
            ItemModel model = new ItemModel();
            model.ID = value.ItemID[2];
            model.Name = value.ItemName[2];
            model.Title = value.ItemTitle[2];
            model.Price = value.ItemPrice[2];
            model.Image = value.ItemImage[2];
            Frame.Navigate(typeof(ReceivePage), model);
        }

        public List<Presenter> Presenters { get; } = new List<Presenter>();
    }

    public class Presenter
    {
        public string Height { get; set; }
        public string[] Visibility { get; set; }
        public string[] ItemID { get; set; }
        public string[] ItemImage { get; set; }
        public string[] ItemName { get; set; }
        public string[] ItemTitle { get; set; }
        public string[] ItemPrice { get; set; }

        public static implicit operator Presenter((string height, string[] visibility, string[] id, string[] Name, string[] Title, string[] Price, string[] AvartarUrl) info)
        {
            return new Presenter { Height = info.height, Visibility = info.visibility, ItemID = info.id, ItemName = info.Name, ItemTitle = info.Title, ItemPrice = info.Price, ItemImage = info.AvartarUrl };
        }
    }
}