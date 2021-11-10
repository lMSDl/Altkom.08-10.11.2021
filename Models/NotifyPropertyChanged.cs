using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    if(PropertyChanged != null)
        //    {
        //        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                var eventArgs = new PropertyChangedEventArgs(propertyName);
                foreach (var handler in PropertyChanged.GetInvocationList())
                {
                    if (handler.Target is ISynchronizeInvoke sync && sync.InvokeRequired)
                    {
                        sync.Invoke(PropertyChanged, new object[] { this, eventArgs });
                    }
                    else
                        PropertyChanged.Invoke(this, eventArgs);
                }
            }
        }
    }
}
