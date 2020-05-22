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
        public ObservableCollection<List<MyTestItem>> MyItems { get; } = new ObservableCollection<List<MyTestItem>>();

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

            var group1 = new List<MyTestItem>
            {
                new MyTestItem { Name = $"Item {Environment.TickCount}" },
                new MyTestItem { Name = $"Item {Environment.TickCount}" }
            };
            var group2 = new List<MyTestItem>
            {
                new MyTestItem { Name = $"Item {Environment.TickCount}" },
                new MyTestItem { Name = $"Item {Environment.TickCount}" },
                new MyTestItem { Name = $"Item {Environment.TickCount}" },
            };

            MyItems.Add(group1);
            MyItems.Add(group2);
            System.Diagnostics.Debug.WriteLine($"Loaded!");
        }
    }

    public class MyTestItem
    {
        public string Name { get; set; }
    }
}
