using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.BusinessObjects
{
    public class SystemSettings
    {
        #region Private Variables

        private static SystemBO _system;
        private static SystemBO Settings
        {
            get
            {
                if (SystemSettings._system == null)
                {
                    _system = new SystemBO();
                    _system.FillAll();
                }
                return SystemSettings._system;
            }
        }

        #endregion

        #region Public Variables
        public static SystemBO GetSystemBO(bool reset = false)
        {
            if (reset)
                _system = null;

            if (_system == null)
            {
                _system = new SystemBO();
                _system.FillAll();
            }
            return _system;
        }

        public static string LayoutLocation
        {
            get
            {
                GetSystemBO();
                return _system.RetrieveSetting("Layout Location");
            }
        }




        #endregion
    }
}
