using System;
using SiGlaz.Common.DDA;

namespace SiGlaz.DDA.Engine
{
	/// <summary>
	/// Summary description for ClusterParam.
	/// </summary>
	public class ClusterParam
	{
		public		float		Distance = 1;
		public		int			LimitNumber = 1;
		public		int			LimitSize = 1;

		public ClusterParam()
		{
		}

		public ClusterParam Copy()
		{
			return MemberwiseClone() as ClusterParam;
		}
	}

	public class KnnMinMaxParam
	{
		public	int			K=1;
		public	float		MinDistance=0f;
		public	float		MaxDistance=1000f;
		public  eOutputType	OutputType = eOutputType.Keep;

		public KnnMinMaxParam Copy()
		{
			return MemberwiseClone() as KnnMinMaxParam;
		}
	}

	public class KnnPercentParam
	{
		public	int			K=1;
		public	float		Percent=50f;
		public	bool		MinToMax=true;
		public  eOutputType	OutputType = eOutputType.Keep;

		public KnnPercentParam Copy()
		{
			return MemberwiseClone() as KnnPercentParam;
		}
	}

}
