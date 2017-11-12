using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Foosball_Lib.ViewModels
{
    public abstract class BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
