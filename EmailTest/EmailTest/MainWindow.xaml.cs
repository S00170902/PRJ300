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
using System.Web;
using System.Net.Mail;

namespace EmailTest
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
            MailMessage mail = new MailMessage("xxxx@gmail.com", "xxxx@gmail.com", "Subject", "Success!");
            //from , to , subject, success
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            //e.g smtp.outlook.com
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("xxxx@gmail.com", "xxxxxxxx");
            //username , password
            client.EnableSsl = true;
            client.Send(mail);
        }
    }
}
