using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOHOANGGIA_5951071018_Weather
{
    public partial class Form1 : Form
    {
        const string APIID = "c29afe3e832f6b1abbe214254b5ee718";
        string cityID = "1566083";
        public Form1()
        {
            InitializeComponent();
            getWeather(cityID);
            getForcast(cityID);
        }

        void getWeather(string city)
        {
            //
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}&units=metric&cnt=6", city, APIID);
                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<WeatherInfo.root > (json);
                WeatherInfo.root output = result;

                lbl_City.Text = string.Format("{0}", output.name);
                lbl_Country.Text = string.Format("{0}", output.sys.country);
                lbl_Degree.Text = string.Format("{0} \u00B0" +"C", output.main.temp);
            }
        }

        //void getForcast(string city)
        //{
        //    int day = 5;
        //    string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?id={0}&units=metric&cnt={1}&appid={2}", city, day, APIID);
        //    using (WebClient web = new WebClient())
        //    {
                
        //        var json = web.DownloadString(url);
        //        var Object = JsonConvert.DeserializeObject<WeatherForcasts>(json);
        //        WeatherForcasts forcasts = Object;

        //        lbl_Con.Text = string.Format("{0}", forcasts.list[1].weather[0].main);
        //        lbl_Des.Text = string.Format("{0}", forcasts.list[1].weather[0].descriptions);
        //        lbl_Des2.Text = string.Format("{0} \u00B0" + "C", forcasts.list[1].temp);
        //        lbl_Speed.Text = string.Format("{0} \u00B0" + "C", forcasts.list[1].speed);

        //    }
        }
    }
}
