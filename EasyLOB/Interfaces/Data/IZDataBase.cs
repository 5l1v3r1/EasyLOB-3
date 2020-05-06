﻿namespace EasyLOB
{
    /// <summary>
    /// IZDataBase.
    /// </summary>
    public interface IZDataBase
    {
        #region Properties

        /// <summary>
        /// Lookup text.
        /// </summary>
        string LookupText { get; set; } // ??? "LookupText" could be read-only, but OData needs "set"

        #endregion Properties

        #region Methods

        /// <summary>
        /// Get entity Id.
        /// </summary>
        /// <returns></returns>
        object[] GetId();

        /// <summary>
        /// On constructor ( called from Constructor ).
        /// </summary>
        void OnConstructor();

        /// <summary>
        /// Set entity Id.
        /// </summary>
        /// <param name="ids"></param>
        void SetId(object[] ids);

        #endregion Methods

        #region Triggers

        /// <summary>
        /// Before create Trigger.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool BeforeCreate(ZOperationResult operationResult);

        /// <summary>
        /// After create Trigger.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool AfterCreate(ZOperationResult operationResult);

        /// <summary>
        /// Before delete Trigger.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool BeforeDelete(ZOperationResult operationResult);

        /// <summary>
        /// After delete Trigger.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool AfterDelete(ZOperationResult operationResult);

        /// <summary>
        /// Before update Trigger.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool BeforeUpdate(ZOperationResult operationResult);

        /// <summary>
        /// After update Trigger.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool AfterUpdate(ZOperationResult operationResult);

        #endregion Triggers
    }
}