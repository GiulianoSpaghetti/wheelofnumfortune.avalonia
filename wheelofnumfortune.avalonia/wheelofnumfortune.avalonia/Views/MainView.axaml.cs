using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Net;
using wheelofnumfortune.avalonia.ViewModels;

namespace wheelofnumfortune.avalonia.Views
{
    public partial class MainView : UserControl
    {

        private static string s;
        public MainView()
        {
            InitializeComponent();
            OnTick_Click(null, null);
        }



        public void OnTick_Click(object obj, RoutedEventArgs args) {
            
           s = MainViewModel.Tick();
            lblStatus.Content = "";
            if (MainViewModel.ObtainedResponse()) {
                txtCookie.Text = s;
                txtSolution.Text = "";
                txtSolution.IsEnabled = true;
                btnDiscover.IsEnabled = true;
                btnCheck.IsEnabled = true;
            }
            else
            {
                lblStatus.Content = s;
                txtSolution.IsEnabled = false;
                btnDiscover.IsEnabled = false;
                btnCheck.IsEnabled = false;

            }
        }
        public void CheckSolution_Click(object sender, RoutedEventArgs e)
        {
            if (MainViewModel.CheckRisposta(txtSolution.Text))
            {
                lblStatus.Content = "You are right";
                txtSolution.IsEnabled = false;
                btnDiscover.IsEnabled = false;
                btnCheck.IsEnabled = false;
            }
            else
            {
                lblStatus.Content = "You are wrong";
            }
        }

        public void DiscoverLetter_Click(object sender, RoutedEventArgs e)
        {
            lblStatus.Content = "";
            if (MainViewModel.DiscoverLetter())
               txtCookie.Text = MainViewModel.getVisualizzazione();
            else
            {
                lblStatus.Content = "You lost";
                txtSolution.IsEnabled = false;
                btnDiscover.IsEnabled = false;
                btnCheck.IsEnabled = false;

            }
        }
    }
}