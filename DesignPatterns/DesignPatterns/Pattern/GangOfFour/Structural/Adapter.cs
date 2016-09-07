using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Structural
{
    public class Adapter
    {
    }

    public interface IChart
    {
        string Title { get; set; }
        int X { get; set; }
        int Y { get; set; }

        void GenerateChart();
    }

    public class MyChart : IChart
    {
        public string Title
        { get; set; }
        public int X
        { get; set; }
        public int Y
        { get; set; }

        public void GenerateChart()
        {
            
        }
    }

    public class ThirdChart
    {
        public void DrawChart()
        {

        }
    }

    public class MyChartAdapter : IChart
    {
        public string Title
        { get; set; }
        public int X
        { get; set; }
        public int Y
        { get; set; }

        private ThirdChart _ThirdChart = new ThirdChart();
        public void GenerateChart()
        {
            _ThirdChart.DrawChart();
        }

    }

    public class MyChartAdapter2 : ThirdChart, IChart
    {
        public string Title
        { get; set; }
        public int X
        { get; set; }
        public int Y
        { get; set; }

        public void GenerateChart()
        {
            this.DrawChart();
        }

    }

}