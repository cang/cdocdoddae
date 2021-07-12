using System;

namespace SiGlaz.Common.DDA.Basic
{
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://siglaz.com")]
	[Serializable]
	public class CubeInfo
	{
		#region Members
		private CubeType _type = CubeType.Yield4H;
		private string _name = string.Empty;
		private bool _isActive = false;
		#endregion

		#region Constructor
		public CubeInfo()
		{

		}
		#endregion

		#region Properties
		public CubeType Type
		{
			get { return _type; }
			set { _type = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value; }
		}
		#endregion

		#region Public Methods
		public string GetSqlWhere()
		{
			if (_isActive)
				return string.Format("[IsActive] = 'true' AND [CubeType] = '{0}' AND [CubeName] = '{1}'", _type.ToString(), _name);
			else
				return string.Format("[CubeType] = '{0}' AND [CubeName] = '{1}'", _type.ToString(), _name);
		}
		#endregion
	}
}
