using System;
using System.Text;
using System.Net;
using System.ComponentModel;

namespace netspeeder
{
    public class CompFound : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String _hostname;
        private String _ip;
        public String hostname
        {
            get { return _hostname; }
            set
            {
                _hostname = value;
                this.NotifyPropertyChanged("hostname");
            }
        }
        public String ip
        {
            get { return _ip; }
            set
            {
                _ip = value;
                this.NotifyPropertyChanged("ip");
            }
        }

        private void NotifyPropertyChanged(String name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
