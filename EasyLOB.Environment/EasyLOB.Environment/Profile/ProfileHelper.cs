using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB.Environment
{
    /// <summary>
    /// Profile Helper.
    /// </summary>
    public static class ProfileHelper
    {
        #region Fields

        /// <summary>
        /// Session name.
        /// </summary>
        private static string _sessionName = "EasyLOB.Profile";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Profile.
        /// </summary>
        public static AppProfile Profile
        {
            get
            {
                AppProfile profile = (AppProfile)EasyLOBHelper.GetService<IEnvironmentManager>().SessionRead(_sessionName);

                return profile ?? new AppProfile();
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="authenticationManager">Authentication manager</param>
        /// <param name="auditTrailunitOfWork">Authorization manager</param>
        public static void Login(IAuthenticationManager authenticationManager, IAuditTrailUnitOfWork auditTrailunitOfWork)
        {
            AppProfile profile = Profile;
            if (profile == null || string.IsNullOrEmpty(profile.UserName))
            {
                IEnvironmentManager environmentManager = EasyLOBHelper.GetService<IEnvironmentManager>();

                // User

                profile = new AppProfile(authenticationManager);

                // AuditTrail

                List<AuditTrailConfiguration> auditTrailConfigurations = auditTrailunitOfWork
                    .GetQuery<AuditTrailConfiguration>()
                    .OrderBy(x => x.Domain)
                    .ThenBy(x => x.Entity)
                    .ToList();
                foreach (AuditTrailConfiguration auditTrailConfiguration in auditTrailConfigurations)
                {
                    AppProfileAuditTrail auditTrail = new AppProfileAuditTrail();
                    auditTrail.Domain = auditTrailConfiguration.Domain;
                    auditTrail.Entity = auditTrailConfiguration.Entity;
                    auditTrail.LogMode = auditTrailConfiguration.LogMode;
                    auditTrail.LogOperations = auditTrailConfiguration.LogOperations;

                    profile.AuditTrail.Add(auditTrail);
                }

                environmentManager.SessionWrite(_sessionName, profile);
            }
        }

        #endregion Methods
    }
}