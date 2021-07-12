using System;
using System.Collections;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for SyntaxRule.
	/// </summary>
	public class SyntaxRule
	{
		public Type			SourceType;

		/// <summary>
		/// Array list of NodeNextRuleAttribute
		/// </summary>
		public ArrayList	NextRule = new ArrayList();

		public SyntaxRule()
		{
		}

		public SyntaxRule(Type sourcetype)
		{
			this.SourceType = sourcetype;
		}

		public void Add(NodeNextRuleAttribute rule)
		{
			NextRule.Add(rule);
		}

		public void Remove(NodeNextRuleAttribute rule)
		{
			NextRule.Remove(rule);
		}

	}

}
