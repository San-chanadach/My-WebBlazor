using Microsoft.AspNetCore.Components;
using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Common;
using PSC.Blazor.Components.Chartjs.Models.Doughnut;
using RapidNRIMs.Data;
using RapidNRIMs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidNRIMs.Pages.ComponentBased.IndexDashboardBased
{
    public class PieChartBase : ComponentBase
    {
        /// <summary>
        /// Chart JS
        /// </summary>
        protected DoughnutChartConfig _config;

        /// <summary>
        /// Inject
        /// </summary>
        [Inject]
        protected AppData AppData { get; set; }

        /// <summary>
        /// void OnInitialized
        /// </summary>
        //protected override void OnInitialized()
        //{
        //    ///***************ChartJs****************************************
        //    _config = new PieConfig
        //    {
        //        Options = new PieOptions
        //        {
        //            Responsive = true,
        //            AspectRatio = 1.2,
        //            MaintainAspectRatio = false,

        //        }
        //    };

        //    foreach (var item in AppData.recordEvents)
        //    {
        //        if (item.EventID >= 1 && item.EventID <= 1015)
        //        {
        //            _config.Data.Labels.Add(item.EventNumber);
        //        }
        //    }


        //    ///+++++++++int List array+++++++++++++
        //    List<int> resultListEvent = AppData.recordEvents.Select(o => o.EventID).ToList();

        //    PieDataset<int> dataset = new PieDataset<int>(new[] { 3, 6, 9, 12, 15 })
        //    {

        //        BackgroundColor = new[]
        //        {
        //        ColorUtil.ColorHexString(255, 99, 132), // Slice 1 aka "Red"
        //        ColorUtil.ColorHexString(255, 205, 86), // Slice 2 aka "Yellow"
        //        ColorUtil.ColorHexString(75, 192, 192), // Slice 3 aka "Green"
        //        ColorUtil.ColorHexString(54, 162, 235), // Slice 4 aka "Blue"
        //        ColorUtil.ColorHexString(0, 0, 0), // Slice 4 aka "Black"

        //        },
        //    };

        //    _config.Data.Datasets.Add(dataset);
        //}

        protected DoughnutChartConfig _config1;
        public Chart _chartTest;

        protected override void OnInitialized()
        {
            _config1 = new DoughnutChartConfig()
            {
                Options = new Options()
                {
                    Responsive = true,
                    MaintainAspectRatio = false,
                    Plugins = new Plugins()
                    {
                        Legend = new Legend()
                        {
                            Display = true,
                            Position = LegendPosition.Left
                        }
                    }
                }
            };
            foreach (var item in AppData.recordEvents)
            {
                if (item.EventID >= 1 && item.EventID <= 1015)
                {
                    _config1.Data.Labels.Add(item.EventNumber);


                }
            }
            ////List<int> array = list.Select(int.Parse).ToList();
            var list = AppData.recordEvents.Where(f => f.EventID <= 1015).Select(n => n.EventID);
            List<decimal> doubles = list.Select(i => (decimal)i).ToList();

            _config1.Data.Datasets.Add(new DoughnutDataset()
            {
                Data = PieDataExamples.SimplePie,
                BackgroundColor = Colors.PaletteBorder1,
                HoverOffset = 10
            });

            //_config1.Data.Labels = PieDataExamples.SimplePieText;


        }
    }
}
