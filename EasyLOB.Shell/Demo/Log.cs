using EasyLOB.Environment;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DemoLog()
        {
            Console.WriteLine("\nLog Demo");

            try
            {
                DIHelper.LogManager.Fatal("Fatal");
                DIHelper.LogManager.Fatal("Fatal {Parameter1} {Parameter2} {Parameter3}", new object[] { "ABC", 1.23, DateTime.Now });
                DIHelper.LogManager.Fatal("Fatal {Parameter1} {Parameter2} {Parameter3}", "ABC", 1.23, DateTime.Now);

                try
                {
                    int x = Int32.Parse("ABC");
                    int y = x + 1;
                }
                catch (Exception exception)
                {
                    DIHelper.LogManager.Exception(exception, "ABC");
                }

                try
                {
                    int x = Int32.Parse("ABC");
                    int y = x + 1;
                }
                catch (Exception exception)
                {
                    ZOperationResult operationResult = new ZOperationResult();
                    operationResult.ParseException(exception);
                    string header =
                        MultiTenantHelper.Tenant.Name + System.Environment.NewLine
                        + ProfileHelper.Profile.UserName;
                    string footer =
                        DateTime.Now.ToString();
                    DIHelper.LogManager.OperationResult(operationResult, header, footer);
                }
            }
            catch (Exception exception)
            {
                WriteException(exception);
            }
        }
    }
}