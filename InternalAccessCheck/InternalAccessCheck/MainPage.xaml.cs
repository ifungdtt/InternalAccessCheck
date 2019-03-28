using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InternalAccessCheck
{
    public partial class MainPage : ContentPage
    {
        private string TAG = "INTERNAL_ACCESS_CHECK";
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {

                Console.WriteLine(TAG + ": Button_Clicked");
                RestService restService = new RestService();
                if (await restService.IsReachable(Entry.Text))
                {
                    Label.Text = Entry.Text + " is reachable";
                    Console.WriteLine(TAG + ": "+ Entry.Text + " is reachable");
                }
                else
                {
                    Label.Text = Entry.Text + " is not reachable";
                    Console.WriteLine(TAG + ": " + Entry.Text + " is not reachable");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(TAG + ":" + ex.Message + ", " + ex.StackTrace);
            }
            
        }
    }
}
