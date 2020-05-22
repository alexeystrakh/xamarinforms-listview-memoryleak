using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestListViewMemoryLeak
{
    public partial class DetailsPage : ContentPage
    {
        public ObservableCollection<MyTestItem> MyItems { get; } = new ObservableCollection<MyTestItem>();

        public DetailsPage()
        {
            InitializeComponent();
            BindingContext = this;
            StartReloadWorkerAsync();
        }

        private async Task StartReloadWorkerAsync()
        {
            for (int i = 0; i < 3; i++)
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
