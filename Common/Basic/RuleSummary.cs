using System;
using System.Collections;
using System.Text;
using System.Xml.Serialization;

namespace SiGlaz.Common.DDA.Basic
{
    [XmlRootAttribute("Summary")]
    public class RuleSummary
    {
        #region Private members
        private string _title;
        private string _subject;
        private string _category;
        private string _description;
        private string _revision;
        #endregion

        #region Properties
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Revision
        {
            get { return _revision; }
            set { _revision = value; }
        }
        #endregion
    }
}
