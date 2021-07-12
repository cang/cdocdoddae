using System;
using System.Collections;
using System.Text;
using System.Xml.Serialization;

namespace SiGlaz.Common.DDA.Basic
{
    [XmlRootAttribute("Header")]
    public class RuleHeader
    {
        #region Private members
        private string _version;
        private RuleType _type;
        private DateTime _createdTime;
        private DateTime _modifiedTime;	
        #endregion

        #region Properties

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public RuleType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public DateTime CreatedTime
        {
            get { return _createdTime; }
            set { _createdTime = value; }
        }

        public DateTime ModifiedTime
        {
            get { return _modifiedTime; }
            set { _modifiedTime = value; }
        }

        #endregion

        #region Constructors

        public RuleHeader()
        {

        }

        #endregion
    }
}
