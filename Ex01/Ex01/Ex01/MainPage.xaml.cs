using Ex01.Model;
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
    }
}
