using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WaitTimeViewer.Models;

namespace WaitTimeViewer.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private int currentIndex = 0;
        public MainWindowViewModel()
        {
            prefferedParks = "Disney Hollywood Studios,Disney Magic Kingdom,Epcot".Split(',').ToList();
            GetParks();
            timer = new System.Timers.Timer(60000)
            {
                AutoReset = true
            };
            timer.Elapsed += (source, e) =>
            {
                var currentPark = parks[currentIndex % parks.Count];
                GetLand(currentPark.id);
                ParkName = currentPark.name;
                currentIndex++;
            };
            ParkName = parks.First().name;
            GetLand(parks.First().id);


        }
        public ObservableCollection<Ride> Rides { get; set; } = new ObservableCollection<Ride>();
        public string ParkName { get; set; }
        private List<Park> parks = new List<Park>();
        private System.Timers.Timer timer;
        private List<string> prefferedParks;
        public void GetLand(int id)
        {
            Rides.Clear();
            var client = new RestClient("https://queue-times.com/");

            var request = new RestRequest($"parks/{id}/queue_times.json");
            var result = client.Get(request);
            var park = JsonConvert.DeserializeObject<QueueTimes>(result.Content);

            foreach (var land in park.lands)
            {
                foreach(var ride in land.rides)
                {
                    Rides.Add(ride);

                }
            }

        }
        protected void GetParks()
        {
            var client = new RestClient("https://queue-times.com/");
            var request = new RestRequest("parks.json");
            var result = client.Get(request);
            var groups = JsonConvert.DeserializeObject<ParkGroup[]>(result.Content);
            this.parks = groups.FirstOrDefault<ParkGroup>(x => x.id == 2)!.parks.Where(x => prefferedParks.Contains(x.name)).ToList<Park>();

            currentIndex++;
        }
    }
}
