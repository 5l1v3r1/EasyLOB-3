using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EasyLOB.Environment
{
    /// <summary>
    /// Environment Helper.
    /// </summary>
    public static class EnvironmentHelper
    {
        #region Properties

        /// <summary>
        /// EasyLOB-Configuration/DashboardResources.ini Manager.
        /// </summary>
        private static IIniManager IniManagerDashboard { get; }

        /// <summary>
        /// EasyLOB-Configuration/MenuResources.ini Manager.
        /// </summary>
        private static IIniManager IniManagerMenu { get; }

        /// <summary>
        /// EasyLOB-Configuration/ReportResources.ini Manager.
        /// </summary>
        private static IIniManager IniManagerReport { get; }

        /// <summary>
        /// Resources namespaces.
        /// </summary>
        private static List<string> Namespaces { get; }

        #endregion Properties

        #region Methods

        static EnvironmentHelper()
        {
            IEnvironmentManager environmentManager = EasyLOBHelper.GetService<IEnvironmentManager>();
            string iniPath;

            iniPath = Path.Combine(environmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                "INI/DashboardResources.ini");
            IniManagerDashboard = EasyLOBHelper.GetService<IIniManager>();
            IniManagerDashboard.Load(iniPath);

            iniPath = Path.Combine(environmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                "INI/MenuResources.ini");
            IniManagerMenu = EasyLOBHelper.GetService<IIniManager>();
            IniManagerMenu.Load(iniPath);

            iniPath = Path.Combine(environmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                "INI/ReportResources.ini");
            IniManagerReport = EasyLOBHelper.GetService<IIniManager>();
            IniManagerReport.Load(iniPath);

            Namespaces = new List<string>()
            {
                "EasyLOB.Resources",
                "EasyLOB.Activity.Resources",
                "EasyLOB.Activity.Data.Resources",
                "EasyLOB.AuditTrail.Resources",
                "EasyLOB.AuditTrail.Data.Resources",
                "EasyLOB.Extensions.Edm.Resources",
                "EasyLOB.Identity.Resources",
                "EasyLOB.Identity.Data.Resources",
                "EasyLOB.Log.Resources",
                "EasyLOB.Security.Resources"
            };

            string[] resources = ConfigurationHelper.AppSettings<string>("EasyLOB.Resources").Split(',');
            foreach (string r in resources.Reverse())
            {
                Namespaces.Insert(0, r);
            }
        }

        /// <summary>
        /// Get Dashboard resources.
        /// </summary>
        /// <param name="resourceKey">Resource</param>
        /// <returns></returns>
        public static string GetDashboardResource(string resourceKey)
        {
            return GetINIResource(IniManagerDashboard, resourceKey);
        }

        /// <summary>
        /// Get Menu resources.
        /// </summary>
        /// <param name="resourceKey">Resource</param>
        /// <returns></returns>
        public static string GetMenuResource(string resourceKey)
        {
            return GetINIResource(IniManagerMenu, resourceKey);
        }

        /// <summary>
        /// Get Report resources.
        /// </summary>
        /// <param name="resourceKey">Resource</param>
        /// <returns></returns>
        public static string GetReportResource(string resourceKey)
        {
            return GetINIResource(IniManagerReport, resourceKey);
        }

        /// <summary>
        /// Get INI resource.
        /// </summary>
        /// <param name="iniManager">INI manager</param>
        /// <param name="resourceKey">Resource</param>
        /// <returns></returns>
        private static string GetINIResource(IIniManager iniManager, string resourceKey)
        {
            string resourceValue = iniManager.Read(CultureInfo.CurrentCulture.Name, resourceKey);

            if (string.IsNullOrEmpty(resourceValue))
            {
                resourceValue = iniManager.Read("culture", resourceKey);
            }

            if (string.IsNullOrEmpty(resourceValue))
            {
                resourceValue = "? " + resourceKey.Trim() + " ?";
            }

            return resourceValue;
        }

        /// <summary>
        /// Get Class resource.
        /// </summary>
        /// <param name="resourceClass">Class</param>
        /// <param name="resourceKey">Resource</param>
        /// <returns></returns>
        public static string GetResource(string resourceClass, string resourceKey)
        {
            string result = "";

            Type type;
            foreach (string n in Namespaces)
            {
                type = LibraryHelper.GetType(n + "." + resourceClass);
                if (type != null)
                {
                    try
                    {
                        result = (string)LibraryHelper.GetStaticPropertyValue(type, resourceKey);

                        break;
                    }
                    catch { }
                }
            }

            return result;
        }

        #endregion Methods
    }
}