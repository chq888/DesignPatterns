using DesignPatterns.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignPatterns.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        #region SOLID

        public ActionResult SRP(string criteria, string searchBy)
        {
            switch(searchBy)
            {
                case "comName":
                    CustomerSearch.SearchByComName();
                    break;
                case "contactName":
                    CustomerSearch.SearchByContactName();
                    break;
            }


            return View();
        }

        public ActionResult OCP(decimal income, decimal deduction, string country)
        {
            ITaxCalculator countryCal = null;
            switch (country)
            {
                case "US":
                    countryCal = new USTaxCalculator();
                    break;
                case "UK":
                    countryCal = new UKTaxCalculator();
                    break;
            }

            countryCal.Deduction = deduction;
            countryCal.Income = income;
            TaxCalculator cal = new TaxCalculator();
            cal.Calculate(countryCal);
            return View();
        }

        public ActionResult LSPProblem()
        {
            // display info
            IList<ISettings> sList = new List<ISettings>();
            GlobalSettings1 g = new GlobalSettings1();
            UserSettings1 u = new UserSettings1();
            sList.Add(g);
            sList.Add(u);
            var allSettings = SettingHelper1.GetAllSettings(sList);
            // try to save it
            IList<IDictionary<string, string>> newSettings = new List<IDictionary<string, string>>();
            IDictionary<string, string> app = new Dictionary<string, string>();
            app.Add("Theme", "Admin");
            IDictionary<string, string> user = new Dictionary<string, string>();
            user.Add("DisplayName", "AAA");
            newSettings.Add(app);
            newSettings.Add(user);
            // throw exception incaseof usersetting
            SettingHelper1.SetAllSettings(sList, newSettings);

            //SettingHelper.SetAllSettings(sList, )
            return View();
        }

        public ActionResult LSP()
        {
            // display info
            IList<IReadableSettings> rList = new List<IReadableSettings>();
            IList<IWritableSettings> wList = new List<IWritableSettings>();

            GlobalSettings g = new GlobalSettings();
            UserSettings u = new UserSettings();
            rList.Add(g);
            rList.Add(u);
            wList.Add(g);

            var allSettings = SettingHelper.GetAllSettings(rList);

            // try to save it
            IList<IDictionary<string, string>> newSettings = new List<IDictionary<string, string>>();
            IDictionary<string, string> app = new Dictionary<string, string>();
            app.Add("Theme", "Admin");
            IDictionary<string, string> user = new Dictionary<string, string>();
            user.Add("DisplayName", "AAA");
            newSettings.Add(app);
            newSettings.Add(user);
            // throw exception incaseof usersetting
            SettingHelper.SetAllSettings(wList, newSettings);

            return View();
        }

        public ActionResult ISP(string paymentMode)
        {
            switch (paymentMode)
            {
                case "cash":
                    CashOnDeliveryOrderProcessor cp = new CashOnDeliveryOrderProcessor();
                    cp.ValidateShippingAddress();
                    cp.ProcessOrder();
                    break;
                case "online":
                    OnlineOrderProcessor op = new OnlineOrderProcessor();
                    op.ValidateCardInfo();
                    op.ValidateShippingAddress();
                    op.ProcessOrder();
                    break;
            }


            return View();
        }

        public ActionResult DIP(string notificationType)
        {
            UserManager um = null;
            switch (notificationType)
            {
                case "email":
                    um = new UserManager(new EmailNotifier());
                    break;
                case "sms":
                    um = new UserManager(new SMSNotifier());
                    break;
            }
            
            um.ChangePassword("user", "old", "new");
            return View();
        }
        #endregion

    }
}