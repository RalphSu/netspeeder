using System;
using System.Text;
using System.Net;
using System.ComponentModel;

namespace netspeeder
{
    class CompFound : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public String hostname;
        public IPAddress ip;

        private void NotifyPropertyChanged(String name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
