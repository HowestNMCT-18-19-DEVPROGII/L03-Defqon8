using Ex02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ex02.view
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
        public DetailPage(Major major)
        {
            InitializeComponent();
            ShowMajor(major);
        }
        private void ShowMajor(Major major)
        {
            lblEmployed.Text = major.Employed.ToString();
            lblFemale.Text = major.Women.ToString();
            lblMajor.Text = major.Name;
            lblMale.Text = major.Men.ToString();
            lblShareOfWomen.Text = major.ShareofWomen.ToString();
            lblUnemployed.Text = major.Unemployed.ToString();
            lblUnemploymentRate.Text = major.UnemploymentRate.ToString();

        }
    }
}