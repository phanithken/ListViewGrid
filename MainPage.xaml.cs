using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public MainPage()
        {
            this.InitializeComponent();
        }

        public Presenter[] Presenters { get; } = new Presenter[]
        {
            (
                new String[]{ "Name 1", "Name 1", "Name 1" }, 
                new String[]{ "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS" },
                new String[]{ "¥990", "¥990", "¥990" },
                new String[]{ "Assets/img.png", "Assets/img.png", "Assets/img.png" }
            ),
            (
                new String[]{ "Name 1", "Name 1", "Name 1" },
                new String[]{ "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS" },
                new String[]{ "¥990", "¥990", "¥990" },
                new String[]{ "Assets/img.png", "Assets/img.png", "Assets/img.png" }
            ),
            (
                new String[]{ "Name 1", "Name 1", "Name 1" },
                new String[]{ "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS" },
                new String[]{ "¥990", "¥990", "¥990" },
                new String[]{ "Assets/img.png", "Assets/img.png", "Assets/img.png" }
            ),
            (
                new String[]{ "Name 1", "Name 1", "Name 1" },
                new String[]{ "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS" },
                new String[]{ "¥990", "¥990", "¥990" },
                new String[]{ "Assets/img.png", "Assets/img.png", "Assets/img.png" }
            ),
            (
                new String[]{ "Name 1", "Name 1", "Name 1" },
                new String[]{ "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS" },
                new String[]{ "¥990", "¥990", "¥990" },
                new String[]{ "Assets/img.png", "Assets/img.png", "Assets/img.png" }
            ),
            (
                new String[]{ "Name 1", "Name 1", "Name 1" },
                new String[]{ "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS" },
                new String[]{ "¥990", "¥990", "¥990" },
                new String[]{ "Assets/img.png", "Assets/img.png", "Assets/img.png" }
            ),
            (
                new String[]{ "Name 1", "Name 1", "Name 1" },
                new String[]{ "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS" },
                new String[]{ "¥990", "¥990", "¥990" },
                new String[]{ "Assets/img.png", "Assets/img.png", "Assets/img.png" }
            ),
            (
                new String[]{ "Name 1", "Name 1", "Name 1" },
                new String[]{ "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS" },
                new String[]{ "¥990", "¥990", "¥990" },
                new String[]{ "Assets/img.png", "Assets/img.png", "Assets/img.png" }
            ),
            (
                new String[]{ "Name 1", "Name 1", "Name 1" },
                new String[]{ "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS", "サイドシームレススポーツ\nブラ(グラデーション)GS" },
                new String[]{ "¥990", "¥990", "¥990" },
                new String[]{ "Assets/img.png", "Assets/img.png", "Assets/img.png" }
            )
        };
    }

    public class Presenter
    {
        public string[] ItemImage { get; set; }
        public string[] ItemName { get; set; }
        public string[] ItemTitle { get; set; }
        public string[] ItemPrice { get; set; }
        public static implicit operator Presenter((string[] Name, string[] Title, string[] Company, string[] AvartarUrl) info)
        {
            return new Presenter { ItemName = info.Name, ItemTitle = info.Title, ItemPrice = info.Company, ItemImage = info.AvartarUrl };
        }
    }
}
