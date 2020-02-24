using EasyLOB.Activity;
using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Identity;
using EasyLOB.Identity.Data;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DemoDI()
        {
            Console.WriteLine("\nDI Demo");

            try
            {
                {

                    // Activity

                    Console.WriteLine();

                    IActivityGenericApplication<EasyLOB.Activity.Data.Activity> application =
                        EasyLOBHelper.DIManager.GetService<IActivityGenericApplication<EasyLOB.Activity.Data.Activity>>();
                    Console.WriteLine(application.ToString());

                    IActivityGenericApplicationDTO<EasyLOB.Activity.Data.ActivityDTO, EasyLOB.Activity.Data.Activity> applicationDTO =
                        EasyLOBHelper.DIManager.GetService<IActivityGenericApplicationDTO<EasyLOB.Activity.Data.ActivityDTO, EasyLOB.Activity.Data.Activity>>();
                    Console.WriteLine(applicationDTO.ToString());

                    IUnitOfWork unitOfWork =
                        EasyLOBHelper.DIManager.GetService<IActivityUnitOfWork>();
                    Console.WriteLine(unitOfWork.ToString());

                    IActivityGenericRepository<EasyLOB.Activity.Data.Activity> repository =
                        EasyLOBHelper.DIManager.GetService<IActivityGenericRepository<EasyLOB.Activity.Data.Activity>>();
                    Console.WriteLine(repository.ToString());
                }

                {

                    // AuditTrail

                    Console.WriteLine();

                    IAuditTrailGenericApplication<AuditTrailConfiguration> application =
                        EasyLOBHelper.DIManager.GetService<IAuditTrailGenericApplication<AuditTrailConfiguration>>();
                    Console.WriteLine(application.ToString());

                    IAuditTrailGenericApplicationDTO<AuditTrailConfigurationDTO, AuditTrailConfiguration> applicationDTO =
                        EasyLOBHelper.DIManager.GetService<IAuditTrailGenericApplicationDTO<AuditTrailConfigurationDTO, AuditTrailConfiguration>>();
                    Console.WriteLine(applicationDTO.ToString());

                    IUnitOfWork unitOfWork =
                        EasyLOBHelper.DIManager.GetService<IAuditTrailUnitOfWork>();
                    Console.WriteLine(unitOfWork.ToString());

                    IAuditTrailGenericRepository<AuditTrailConfiguration> repository =
                        EasyLOBHelper.DIManager.GetService<IAuditTrailGenericRepository<AuditTrailConfiguration>>();
                    Console.WriteLine(repository.ToString());
                }


                {

                    // Identity

                    Console.WriteLine();

                    IIdentityGenericApplication<User> application =
                        EasyLOBHelper.DIManager.GetService<IIdentityGenericApplication<User>>();
                    Console.WriteLine(application.ToString());

                    IIdentityGenericApplicationDTO<UserDTO, User> applicationDTO =
                        EasyLOBHelper.DIManager.GetService<IIdentityGenericApplicationDTO<UserDTO, User>>();
                    Console.WriteLine(applicationDTO.ToString());

                    IUnitOfWork unitOfWork =
                        EasyLOBHelper.DIManager.GetService<IIdentityUnitOfWork>();
                    Console.WriteLine(unitOfWork.ToString());

                    IIdentityGenericRepository<User> repository =
                        EasyLOBHelper.DIManager.GetService<IIdentityGenericRepository<User>>();
                    Console.WriteLine(repository.ToString());

                    Console.WriteLine();

                    ZOperationResult operationResult = new ZOperationResult();
                    User user = application.Get(operationResult, x => x.UserName.ToLower() == "administrator");
                    Console.WriteLine(user.UserName);
                }
            }
            catch (Exception exception)
            {
                WriteException(exception);
            }
        }
    }
}