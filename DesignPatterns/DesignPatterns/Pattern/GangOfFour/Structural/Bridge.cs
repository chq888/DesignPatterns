using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Structural
{
    public class Bridge
    {
    }

    public interface ILogger
    {
        void Log(string msg);
    }

    public class TextLogger : ILogger
    {
        public void Log(string msg)
        {
        }
    }

    public class XmlLogger : ILogger
    {
        public void Log(string msg)
        {
        }
    }

    public interface IDataImporter
    {
        ILogger Logger { get; set; }
        void Import();
    }

    public class BasicDataImporter : IDataImporter
    {
        public ILogger Logger { get; set; }

        public void Import()
        {
        }
    }

    public class AdvanceDataImporter : IDataImporter
    {
        public ILogger Logger { get; set; }

        public void Import()
        {
        }
    }
}