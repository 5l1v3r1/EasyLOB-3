using AutoMapper;

namespace EasyLOB
{
    /// <summary>
    /// EasyLOB Helper.
    /// </summary>
    public static class EasyLOBHelper
    {
        #region Properties

        /// <summary>
        /// DI Manager.
        /// </summary>
        public static IDIManager DIManager { get; private set; }

        /// <summary>
        /// AutoMapper Mapper.
        /// </summary>
        public static IMapper Mapper { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Setup.
        /// </summary>
        /// <param name="diManager">DI Manager</param>
        /// <param name="mapper">AutoMapper Mapper</param>
        public static void Setup(IDIManager diManager,
            IMapper mapper)
        {
            DIManager = diManager;
            Mapper = mapper;
        }

        public static T GetService<T>()
        {
            return DIManager.GetService<T>();
        }

        #endregion Methods
    }
}