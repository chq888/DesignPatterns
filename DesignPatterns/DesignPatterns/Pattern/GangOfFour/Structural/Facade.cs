using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Structural
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class ServiceA
    {
        public Book Get(int id)
        {
            return new Book();
        }
    }

    public class ServiceB
    {
        public Book Get(int id)
        {
            return new Book();
        }
    }

    public class PriceComparer
    {
        public IList<Book> Compare(int id)
        {
            ServiceA a = new ServiceA();
            ServiceB b = new ServiceB();
            IList<Book> list = new List<Book>();
            list.Add(a.Get(0));
            list.Add(b.Get(0));

            return list;
        }
    }
}