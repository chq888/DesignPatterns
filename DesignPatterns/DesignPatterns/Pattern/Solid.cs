using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern
{
    public class SOLID
    {
    }

    #region SRP problem
    public class SRPProblem
    {
        public void SearchByContactName()
        {

        }

        public void SearchByComName()
        {

        }

        public void Export()
        {

        }
    }

    #endregion
    #region SRP
    public class CustomerSearch
    {
        public static void SearchByContactName()
        {

        }

        public static void SearchByComName()
        {

        }
    }

    public class CustomerDataExporter
    {
        public static void Export()
        {

        }
    }
    #endregion


    #region OCP problem
    public class OCPProblem
    {

        public decimal Calculate(decimal income, decimal deduction, string country)
        {
            decimal taxAmount = 0;
            decimal taxableIncome = income - deduction;
            switch (country)
            {
                case "US":
                    break;
                case "UK":
                    break;
            }

            return taxAmount;
        }
    }
    #endregion
    #region OCP
    public interface ITaxCalculator
    {
        decimal Income { get; set; }
        decimal Deduction { get; set; }
        decimal Calculate();
    }

    public class USTaxCalculator : ITaxCalculator
    {
        public decimal Deduction
        {
            get;
            set;
        }

        public decimal Income
        {
            get;
            set;
        }

        public decimal Calculate()
        {
            decimal taxableIncome = Income - Deduction;
            return taxableIncome * 30 / 100;
        }
    }

    public class UKTaxCalculator : ITaxCalculator
    {
        public decimal Deduction
        {
            get;
            set;
        }

        public decimal Income
        {
            get;
            set;
        }

        public decimal Calculate()
        {
            decimal taxableIncome = Income - Deduction;
            return taxableIncome * 35 / 100;
        }
    }

    public class TaxCalculator
    {
        public decimal Calculate(ITaxCalculator cal)
        {
            return cal.Calculate();
        }

    }
    #endregion


    #region LSP problem
    public interface ISettings
    {
        IDictionary<string, string> GetSettings();
        void SetSettings(IDictionary<string, string> setting);
    }

    public class GlobalSettings1 : ISettings
    {
        public IDictionary<string, string> GetSettings()
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Theme", "Admin");
            return dic;
        }

        public void SetSettings(IDictionary<string, string> setting)
        {
            foreach(var item in setting)
            {
                // save to persitence store
            }
        }
    }

    public class UserSettings1 : ISettings
    {
        public IDictionary<string, string> GetSettings()
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Theme", "User");
            return dic;
        }

        public void SetSettings(IDictionary<string, string> setting)
        {
            throw new NotImplementedException();
        }
    }

    public class SettingHelper1
    {
        public static IDictionary<ISettings, IDictionary<string, string>> GetAllSettings(IList<ISettings> items)
        {
            IDictionary<ISettings, IDictionary<string, string>> all = new Dictionary<ISettings, IDictionary<string, string>>();
            foreach (var item in items)
            {
                all.Add(item, item.GetSettings());
            }

            return all;
        }

        public static void SetAllSettings(IList<ISettings> items, IList<IDictionary<string, string>> values)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].SetSettings(values[i]);
            }
        }
    }
    #endregion
    #region LSP
    public interface IReadableSettings
    {
        IDictionary<string, string> GetSettings();
    }

    public interface IWritableSettings
    {
        void SetSettings(IDictionary<string, string> setting);
    }

    public class GlobalSettings : IReadableSettings, IWritableSettings
    {
        public IDictionary<string, string> GetSettings()
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Theme", "Admin");
            return dic;
        }

        public void SetSettings(IDictionary<string, string> setting)
        {
            foreach (var item in setting)
            {
                // save to persitence store
            }
        }
    }

    public class UserSettings : IReadableSettings
    {
        public IDictionary<string, string> GetSettings()
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Theme", "User");
            return dic;
        }
    }

    public class SettingHelper
    {
        public static IDictionary<IReadableSettings, IDictionary<string, string>> GetAllSettings(IList<IReadableSettings> items)
        {
            IDictionary<IReadableSettings, IDictionary<string, string>> all = new Dictionary<IReadableSettings, IDictionary<string, string>>();
            foreach (var item in items)
            {
                all.Add(item, item.GetSettings());
            }

            return all;
        }

        public static void SetAllSettings(IList<IWritableSettings> items, IList<IDictionary<string, string>> values)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].SetSettings(values[i]);
            }
        }
    }
    #endregion


    #region ISP problem
    public interface IOrderProcessor1
    {
        bool ValidateCardInfo();
        bool ValidateShippingAddress();
        void ProcessOrder();
    }

    public class OnlineOrderProcessor1 : IOrderProcessor1
    {
        public void ProcessOrder()
        {
        }

        public bool ValidateCardInfo()
        {
            return true;
        }

        public bool ValidateShippingAddress()
        {
            return true;
        }
    }

    public class CashOnDeliveryOrderProcessor1 : IOrderProcessor1
    {
        public void ProcessOrder()
        {
        }

        public bool ValidateCardInfo()
        {
            throw new NotImplementedException();
        }

        public bool ValidateShippingAddress()
        {
            return true;
        }
    }


    #endregion
    #region ISP
    public interface IOrderProcessor
    {
        bool ValidateShippingAddress();
        void ProcessOrder();
    }

    public interface IOnlineOrderProcessor
    {
        bool ValidateCardInfo();
    }

    public class OnlineOrderProcessor : IOrderProcessor, IOnlineOrderProcessor
    {
        public void ProcessOrder()
        {
        }

        public bool ValidateCardInfo()
        {
            return true;
        }

        public bool ValidateShippingAddress()
        {
            return true;
        }
    }

    public class CashOnDeliveryOrderProcessor : IOrderProcessor
    {
        public void ProcessOrder()
        {
        }

        public bool ValidateShippingAddress()
        {
            return true;
        }
    }
    #endregion


    #region DIP problem
    public class UserManager1
    {
        // UserManager depends on EmailNotifier
        // UserManager has much dependency on EmailNotifier
        // if EmailNotifier changes, this might need some adjustment
        // EmailNotifier must be made available before coding high-level classes
        // if provide SMS notification in which case must change the code in this class to replace EmailNotifier with the new notification class
        EmailNotifier1 notifier = new EmailNotifier1();
        public void ChangePassword()
        {
            notifier.Notify();
        }
    }

    public class EmailNotifier1
    {
        public void Notify()
        {

        }
    }
    #endregion
    #region DIP
    public class UserManager
    {
        // this way, can either set it while instantiating UserManager or change it through the Notifier property
        public INotifier Notifier
        {
            get;
            set;
        }

        // supply the dependency from outside
        public UserManager(INotifier notifier)
        {
            Notifier = notifier;
        }

        public void ChangePassword(string user, string oldPassword, string newPassword)
        {
            Notifier.Notify("done");
        }
    }

    /// <summary>
    /// abstraction
    /// design INotifier by looking at the needs of UserManager
    /// INotifier shouldn't be designed while looking at the needs of EmailNotifier
    /// </summary>
    public interface INotifier
    {
        void Notify(string message);
    }

    /// <summary>
    /// detail
    /// </summary>
    public class EmailNotifier : INotifier
    {
        public void Notify(string message)
        {

        }
    }

    public class SMSNotifier : INotifier
    {
        public void Notify(string message)
        {

        }
    }
    #endregion

}