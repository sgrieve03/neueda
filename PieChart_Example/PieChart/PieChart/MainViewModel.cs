using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieChart
{
    public class MainViewModel
    {
        private readonly ObservableCollection<Population> _populations = new ObservableCollection<Population>();
        public ObservableCollection<Population> Populations
        {
            get
            {
                return _populations;
            }
        }

        public MainViewModel()
        {
            _populations.Add(new Population() { Name = "Aidan", Count = 1340 });
            _populations.Add(new Population() { Name = "Pat", Count = 1220 });
            _populations.Add(new Population() { Name = "THE BIG FELLA", Count = 4000 });

        }
    }
}
