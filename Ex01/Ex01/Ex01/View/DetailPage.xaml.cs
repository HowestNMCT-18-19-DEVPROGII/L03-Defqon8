using Ex01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ex01.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		public DetailPage (Guest guest)
		{
			InitializeComponent ();
            ShowGuest(guest);
		}
        private void ShowGuest(Guest guest)
        {
            lblName.Text = guest.Name;
            lblGroup.Text = guest.Group;
            lblOccupation.Text = guest.GoogleKnowlege_Occcupation;
            lblShowDate.Text = guest.Show.ToString("dd-MM-yyyy");

        }
    }
}