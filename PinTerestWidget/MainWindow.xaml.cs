using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PinTerestWidget
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string lnk = "https://ru.pinterest.com/explore/%D0%BC%D0%B5%D0%B3%D0%B0%D1%87%D0%B5%D0%BB%D0%BE%D0%B2%D0%B5%D0%BA-953456390872/";
        string txtSite;

        public void TryCatch()
        {
            HttpWebRequest proxy_request = (HttpWebRequest)WebRequest.Create("https://ru.pinterest.com/explore/%D0%BC%D0%B5%D0%B3%D0%B0%D1%87%D0%B5%D0%BB%D0%BE%D0%B2%D0%B5%D0%BA-953456390872/");
            proxy_request.Method = "GET";
            proxy_request.ContentType = "application/x-www-form-urlencoded";
            proxy_request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/532.5 (KHTML, like Gecko) Chrome/4.0.249.89 Safari/532.5";
            proxy_request.KeepAlive = true;
            HttpWebResponse resp = proxy_request.GetResponse() as HttpWebResponse;
            string html = "";
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding(1251));
            html = sr.ReadToEnd();
            html = html.Trim();
        }

        public void parseHTML()
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(lnk, "test.txt");
            }
            catch {}
        }
        public List<string> stringMassive() // Получить лист ТХТ
        {
            List<string> fullTXT = new List<string>();
            string line;
            StreamReader reader = new StreamReader("test.txt");
            //string s = File.ReadAllText(fileN);
            while ((line = reader.ReadLine()) != null)
            {
                fullTXT.Add(line);
            }
            reader.Close();
            return fullTXT;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            parseHTML();
            stringMassive();
        }
    }
}
