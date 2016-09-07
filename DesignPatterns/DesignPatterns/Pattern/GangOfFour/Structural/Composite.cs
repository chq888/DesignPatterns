using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Structural
{
    public interface IMenuComponent
    {
        string Text { get; set; }
        string Url { get; set; }
        IList<IMenuComponent> Children { get; set; }
    }

    public class MenuItem : IMenuComponent
    {
        public IList<IMenuComponent> Children { get; set; }

        public string Text { get; set; }

        public string Url { get; set; }
    }

    public class Menu : IMenuComponent
    {
        public IList<IMenuComponent> Children { get; set; }

        public string Text { get; set; }

        public string Url { get; set; }

        public bool OpenInNewWindow { get; set; }
    }

}