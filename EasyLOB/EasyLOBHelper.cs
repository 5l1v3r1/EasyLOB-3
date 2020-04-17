using AutoMapper;

namespace EasyLOB
{
    /// <summary>
    /// EasyLOB Helper.
    /// </summary>
    public static class EasyLOBHelper
    {
        #region Properties

        public static IDIManager _diManager;

        /// <summary>
        /// DI Manager.
        /// </summary>
        public static IDIManager DIManager
        {
            get
            {
                return _diManager;
            }
            set
            {
                if (_diManager == null)
                {
                    _diManager = value;
                }
            }
        }

        public static IMapper _mapper;

        /// <summary>
        /// AutoMapper Mapper.
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
            set
            {
                if (_mapper == null)
                {
                    _mapper = value;
                }
            }
        }

        #endregion Properties

        #region Methods

        public static T GetService<T>()
        {
            return DIManager.GetService<T>();
        }

        #endregion Methods
    }
}