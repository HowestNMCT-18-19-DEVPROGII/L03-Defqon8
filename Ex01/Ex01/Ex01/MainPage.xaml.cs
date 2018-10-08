using Ex01.Model;
using Ex01.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ex01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadGuests();
        }
        private void LoadGuests() {
            List<Guest> lijst = Guest.ReadGuestList();
            // de list met klasse objecten worden gekoppeld aan listview
            //door data binding worden alle velden gevuld
            lvwGuests.ItemsSource = lijst;
        }

        private void lvwGuests_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        //er is een item geselecteerd
        //controleer
        if(lvwGuests.SelectedItem != null)
            {
                //welke guest
                Guest guest = (Guest) lvwGuests.SelectedItem; //wie is geselecteerd
                //object doorgeven naar detailpage
                Navigation.PushAsync(new DetailPage(guest));
            }
        }
    }
}
