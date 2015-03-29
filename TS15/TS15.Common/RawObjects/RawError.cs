using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TS15.Common.RawObjects
{
    public class RawError
    {
        bool bitError;
        string strMessage;

        public RawError()
        {
            this.bitError = false;
            this.strMessage = string.Empty;
        }

        public string Message
        {
            get { return strMessage; }
            set { strMessage = value; }
        }

        public bool Error
        {
            get { return bitError; }
            set { bitError = value; }
        }
    }
}
