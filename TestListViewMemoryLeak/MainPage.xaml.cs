using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestListViewMemoryLeak
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<MyTestItem> MyItems { get; } = new ObservableCollection<MyTestItem>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            StartReloadWorkerAsync();
        }

        private async Task StartReloadWorkerAsync()
        {
            while (true)
            {
                await Task.Delay(5000);
                await RealodAsync();
            }
        }

        private async Task RealodAsync()
        {
            System.Diagnostics.Debug.WriteLine($"Loading data...");
            await Task.Delay(1000);
            MyItems.Clear();
            MyItems.Add(new MyTestItem { Name = "Item 1" });
            MyItems.Add(new MyTestItem { Name = "Item 2" });
            MyItems.Add(new MyTestItem { Name = "Item 3" });
            System.Diagnostics.Debug.WriteLine($"Loaded!");
        }
    }

    public class MyTestItem
    {
        public string Name { get; set; }
    }
}
