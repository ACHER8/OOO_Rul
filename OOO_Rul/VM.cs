using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOO_Rul
{
    public class VM: INotifyPropertyChanged
    {
        public Page CurrentPage { get; set; }
        public CustomCommand OpenPageRulList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public VM()
        {
            OpenPageRulList = new CustomCommand(()=>
                {
                    CurrentPage = new PageRulList();
                    SignalChanged("CurrentPage");
                });
        }
        void SignalChanged([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
