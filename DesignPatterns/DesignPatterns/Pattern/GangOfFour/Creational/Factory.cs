using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Creational
{
    public class Factory
    {
    }

    public interface IChart
    {
        string Title { get; set; }
        Bitmap GenerateChart();
    }

    public class BarChart : IChart
    {
        public string Title
        {
            get;
            set;
        }

        public Bitmap GenerateChart()
        {
            return null;
        }
    }

    public class PieChart : IChart
    {
        public string Title
        {
            get;
            set;
        }

        public Bitmap GenerateChart()
        {
            return null;
        }
    }

    public interface IChartProvider
    {
        IChart GetChart();
    }

    public class FreeChartProvider : IChartProvider
    {
        public IChart GetChart()
        {
            return new BarChart();
        }
    }

    public class PaidChartProvider : IChartProvider
    {
        public IChart GetChart()
        {
            return new PieChart();
        }
    }

}