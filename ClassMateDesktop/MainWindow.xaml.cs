using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClassMateDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            string email = textBox.Text;
            string password = passwordBox.Password;
            connectServer(email, password);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void connectServer(string email,string password)
        {
            var client = new RestClient("http://localhost:3000/api");
            var request = new RestRequest("authenticate",Method.POST);
            request.AddParameter("email", email);
            request.AddParameter("password", password);

            IRestResponse<Key> response = client.Execute<Key>(request);

            Console.WriteLine("**********************");
            if (response.Data.success.Equals("True"))
            {
                Manager.getInstance().setToken(response.Data.token);
                
                Dashboard d = new Dashboard();
                d.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Incorrect password or user name");
                
            }
            

        }
    }

    public class Key
    {
        public string success { get; set; }
        public string token { get; set; }

    }
}
