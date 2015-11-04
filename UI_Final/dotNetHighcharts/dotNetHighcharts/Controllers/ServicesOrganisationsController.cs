using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dotNetHighcharts.DAL;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;
using System.Drawing;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts;
using dotNetHighcharts.Models;


namespace dotNetHighcharts.Controllers
{
    public class ServicesOrganisationsController : Controller
    {
        private NHSPatientServicesEntities db = new NHSPatientServicesEntities();

        public ActionResult BindDecimalValues()
        {
            List<ServiceTotals> data = new List<ServiceTotals>
                                   { new ServiceTotals { name = "VW", TotalServiceType2 = 300000 },
                                     new ServiceTotals { name = "Mazda", TotalServiceType2 = 600000 },
                                     new ServiceTotals { name = "seat", TotalServiceType2 = 100000 },

                                   };
            List<ServiceTotals> newData = new List<ServiceTotals>
                                   { new ServiceTotals { TotalServiceType3 = 500000 },
                                     new ServiceTotals { TotalServiceType3 = 700000 },
                                     new ServiceTotals { TotalServiceType3 = 900000 },

                                   };
            object[,] chartData = new object[data.Count(), 2];
            int i = 0;
            foreach (ServiceTotals item in data)
            {
                chartData.SetValue(item.name, i, 0);
                chartData.SetValue(item.TotalServiceType2, i, 1);
                i++;
            }
            object[] newChartData = new object[newData.Count()];
            int j = 0;
            foreach (ServiceTotals nItem in newData)
            {
                newChartData.SetValue(nItem.TotalServiceType3, j);
                j++;
            }

            Highcharts chart1 = new Highcharts("chart1")
                .InitChart(new Chart { Type = ChartTypes.Column })
                .SetTitle(new Title { Text = "Chart 1" })
                 .SetYAxis(new YAxis
                 {
                     PlotLines = new[]
                    {
                        new YAxisPlotLines
                        {
                            Value = 500000,
                            Width = 5,
                            Color = Color.Yellow
                        },
                        new YAxisPlotLines
                         {
                            Value = 350000,
                            Width = 5,
                            Color = Color.Green
                        }
                     }
                 }
                 )
                .SetXAxis(new XAxis { Type = AxisTypes.Category })
                .SetSeries(new[]
                {
                    new Series {Name = "Models Sold 2014",
                                Color = Color.IndianRed,
                                Data = new Data(chartData) },
                    new Series {Name = "Models Sold 2015",
                                Color = Color.Silver,
                                Data = new Data(newChartData) },
                    new Series
                            {
                                Type = ChartTypes.Line,
                                Name = "Average between Years",
                                Color = Color.Purple,
                                Data = new Data(new object[] { 400000, 200000,300000 })
                            } });
            return View(chart1);
        }

        public ActionResult HighMap()
        {

            List<MapDetails> MapD = new List<MapDetails>
                                    {new MapDetails {name = "NHS Trust London", lon = -0.1275,
                                        lat = 51.507222, avgStaff= 5000.2, z = 2.34 },
                                    new MapDetails {name = "NHS Trust Leeds", lon = -1.893611,
                                        lat =  52.483056, avgStaff = 700, z = 4.2},
                                    new MapDetails {name = "NHS Trust Birmingham", lat = 53.383611,
                                                    lon = -1.466944, avgStaff = 60.33, z = 5.22},
                                    new MapDetails {name = "NHS Trust Liverpool", lat = 53.4,
                                                    lon = -3, avgStaff = 300.33, z = 2.88},
                                    new MapDetails {name = "NHS Trust Bristol", lat = 51.45,
                                                    lon = -2.583333, avgStaff = 250.33, z = 3}};


            List<MapDetails> MapD1 = new List<MapDetails>
                                    {new MapDetails {name = "NHS Trust", lon = -0.1275,
                                        lat = 51.507222, avgStaff= 5000.2, z = 2.34 },
                                    new MapDetails {name = "NHS Trust Leeds", lon = -1.893611,
                                        lat =  52.483056, avgStaff = 700, z = 4.2},
                                    new MapDetails {name = "NHS Trust Birmingham", lat = 53.383611,
                                                    lon = -1.466944, avgStaff = 60.33, z = 5.22},
                                    new MapDetails {name = "NHS Trust Liverpool", lat = 53.4,
                                                    lon = -3, avgStaff = 300.33, z = 2.88},
                                    new MapDetails {name = "NHS Trust Bristol", lat = 51.45,
                                                    lon = -2.583333, avgStaff = 250.33, z = 3}};
            ViewBag.Cancer = MapD1.ToList();
            return View(MapD.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

       