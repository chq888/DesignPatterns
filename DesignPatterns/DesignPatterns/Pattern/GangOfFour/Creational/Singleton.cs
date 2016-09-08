using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Creational
{
    public class Singleton1
    {
        private static Singleton1 _singleton = new Singleton1();
        static Singleton1()
        {
        }

        public static Singleton1 Instance
        {
            get
            {
                return _singleton;
            }
        }

        public void Test()
        {

        }
    }

    public class Singleton2
    {
        private static readonly object theLock = new object();
        private static Singleton2 _Instance;
        private Singleton2()
        {

        }

        public static Singleton2 Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (theLock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new Singleton2();
                        }
                    }
                }

                return _Instance;
            }
        }

        public void Test()
        {

        }
    }

    public class Singleton3
    {
        private static readonly Singleton3 _Instance = new Singleton3();
        private Singleton3()
        {

        }

        public static Singleton3 Instance
        {
            get
            {
                return _Instance;
            }
        }

        public void Test()
        {

        }
    }


}