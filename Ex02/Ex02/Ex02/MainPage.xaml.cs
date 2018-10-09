using Ex02.Model;
using Ex02.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ex02
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadMajor();
            PickCat();
        }
        private void LoadMajor()
        {
            List<Major> lijst = Major.ReadMajorList();
            // de list met klasse objecten worden gekoppeld aan listview
            //door data binding worden alle velden gevuld
            lvwMajors.ItemsSource = lijst;
        }

        private void lvwMajors_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //er is een item geselecteerd
            //controleer
            if (lvwMajors.SelectedItem != null)
            {
                //welke guest
                Major major = (Major)lvwMajors.SelectedItem; //wie is geselecteerd
                //object doorgeven naar detailpage
                Navigation.PushAsync(new DetailPage(major));
            }
        }

        private void PickCat()
        {
            List<Major> allMajors = Major.ReadMajorList();
            List<string> categories = Major.GetUniqueCategories(allMajors);
            pickCategories.ItemsSource = categories;
        }

    }
}