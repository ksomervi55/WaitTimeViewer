using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using WaitTimeViewer.ViewModels;
using WaitTimeViewer.Models;
using System.Timers;
using Avalonia.Threading;
namespace WaitTimeViewer.Views
{
    public partial class MainWindow : Window
    {
        private Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new Timer()
            {
                Interval = 5000
            };
            timer.Elapsed += async (source , e) => await Dispatcher.UIThread.InvokeAsync(slides.Next);
            timer.Start();
        }
        public void Next(object source, RoutedEventArgs args)
        {
            slides.Next();
        }

        public void Previous(object source, RoutedEventArgs args)
        {
            slides.Previous();
        }
        public void LoadSlides()
        {
            
            
        }
    }
}