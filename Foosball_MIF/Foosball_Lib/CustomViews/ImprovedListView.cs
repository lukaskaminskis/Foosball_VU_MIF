using System.Windows.Input;
using Xamarin.Forms;

namespace Foosball_Lib.Views
{
    public class ImprovedListView : ListView
    {
        public static BindableProperty ItemClickedCommandProperty = BindableProperty.Create(nameof(ItemClickedCommand), typeof(ICommand), typeof(ImprovedListView), null);

        public ICommand ItemClickedCommand
        {
            get
            {
                return (ICommand)this.GetValue(ItemClickedCommandProperty);
            }
            set
            {
                this.SetValue(ItemClickedCommandProperty, value);
            }
        }
        public ImprovedListView()
        {
            this.ItemTapped += OnItemTapped;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                ItemClickedCommand?.Execute(e.Item);
                SelectedItem = null;
            }
        }

    }
}
