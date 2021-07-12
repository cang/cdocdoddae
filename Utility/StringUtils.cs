using System;
using System.Text;
using System.IO;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for StringUtils.
	/// </summary>
	public class StringUtils
	{
		public StringUtils()
		{
		}

		public static System.Collections.Specialized.StringCollection GetTokenOfString(string input)
		{
			System.Collections.Specialized.StringCollection slResult=new System.Collections.Specialized.StringCollection();

			//get token from this
			int i0=0;
			bool bdatatag=false;
			for(int i=0;i<input.Length;i++)
			{
				if( input[i]=='"' && !bdatatag) //begin string data tag
				{
					bdatatag=true;
					i0=i;
				}
				else if( input[i]=='"' && bdatatag) //end string data tag
				{
					bdatatag=false;
					//get string 
					string sss=input.Substring(i0,i-i0+1);
					if( sss[0]==' ' ||  sss[sss.Length-1]==' ' || sss[0]=='\t' ||  sss[sss.Length-1]=='\t')
						sss=sss.Trim(' ','\t');
					if(sss!="")
						slResult.Add(sss);
					i0=i+1;
					//Vu~ fix mem
					sss=null;
				}
				else if( !bdatatag && (input[i]==' ' || input[i]==';' || input[i]=='\t') &&  i-i0 >0 )
				{
					string sss=input.Substring(i0,i-i0);
					if( sss[0]==' ' ||  sss[sss.Length-1]==' ' || sss[0]=='\t' ||  sss[sss.Length-1]=='\t')
						sss=sss.Trim(' ','\t');
					i0=i+1;
					if(sss!="")
						slResult.Add(sss);

					//Vu~ fix mem
					sss=null;
				}
				else if( i==input.Length-1)
				{
					string sss=input.Substring(i0,i-i0+1);
					if( sss[0]==' ' ||  sss[sss.Length-1]==' ' || sss[0]=='\t' ||  sss[sss.Length-1]=='\t')
						sss=sss.Trim(' ','\t');
					if(sss!="" || sss!=";")
						slResult.Add(sss);
					//Vu~ fix mem
					sss=null;
				}
			}
			return slResult;
		}

		public static System.Collections.Specialized.StringCollection ReadUntilEndRecord(StreamReader f3,bool oneline)//end record was mark with ";" character
		{
			string line=null;
			StringBuilder sb=new StringBuilder();
			while(f3.Peek()>-1)
			{
				line=f3.ReadLine();
				if(line=="")
				{
					line = null; //DTL
					continue;
				}

				if( line[0]==' ' ||  line[line.Length-1]==' ' ||  line[0]=='\t' || line[line.Length-1]=='\t')
					line=line.Trim(' ','\t');

				if(line=="")
				{
					line = null; //DTL
					continue;
				}

				sb.Append(" ");
				sb.Append(line);

				if(oneline || line[line.Length-1]==';')//end record
				{
					string ss=sb.ToString();
					sb=null; //DTL
					ss=ss.Substring(1);
					System.Collections.Specialized.StringCollection slResult=GetTokenOfString(ss);
					if(line[line.Length-1]==';')
						slResult.Add(";");
					ss=null; //DTL
					line=null; //DTL
					return slResult;
				}
				line = null; //DTL
			}

			if( line==null || line=="")
				return null;
			else
				throw new Exception("Invalid KLARF file Format.");
		}

		public static bool	IsNumber(string exp)
		{
			try
			{
				double.Parse(exp);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool  StrLikeOut(string values,string patern)
		{
			string spattern=patern.Trim();
			if( spattern.Length<=0)
				return false;

			if(values==patern)
				return true;

			if( spattern[spattern.Length-1]!='*')
				spattern=string.Concat(spattern,"*");

			return Wildcard.Match(spattern,values);
		}

		public static bool  StrLike(string values,string patern)
		{
			string spattern=patern.Trim();
			if( spattern.Length<=0)
				return false;

			if(values==patern)
				return true;

			return Wildcard.Match(spattern,values);
		}

		public static bool Read(StreamReader sr,StringBuilder sb,int length)
		{
			while(sb.Length<length && sr.Peek()>-1)
			{
				string line=sr.ReadLine();
				sb.Append(line);
			}
			return sb.Length>=length;
		}

		public static string ReadString(StreamReader sr,StringBuilder sb,int length)
		{
			if(sb.Length<length)
				if(Read(sr,sb,length)==false)
					return null;

			string sreturn = sb.ToString(0,length);
			sb.Remove(0,length);
			return sreturn;
		}

		public static string ReadTag(StreamReader sr,StringBuilder sb)
		{
			return ReadString(sr,sb,8);
		}

		public static int ReadLength(StreamReader sr,StringBuilder sb)
		{
			string slength = ReadString(sr,sb,8);
			if(slength==null)
				return 0;
			else
				return Convert.ToInt32(slength);
		}


		public static void GetExpressOfEndQuery(string expr, ref string fieldname, ref string operation, ref object value)
		{
			if(expr.IndexOf(">=")>=0 )
			{
				string []sss=expr.Split(">=".ToCharArray());
				fieldname=sss[0];
				operation=">=";
				value= Convert.ToString(sss[sss.Length-1]);
			}
			else if(expr.IndexOf("<=")>=0 )
			{
				string []sss=expr.Split("<=".ToCharArray());
				fieldname=sss[0];
				operation="<=";
				value= Convert.ToString(sss[sss.Length-1]);
			}
			else if(expr.IndexOf("!=")>=0 )
			{
				string []sss=expr.Split("!=".ToCharArray());
				fieldname=sss[0];
				operation="<>";
				value= Convert.ToString(sss[sss.Length-1]);
			}
			else if( expr.IndexOf("=") >=0 )
			{
				string []sss=expr.Split("=".ToCharArray());
				fieldname=sss[0];
				operation="=";
				value= Convert.ToString(sss[sss.Length-1]);
			}
			else if(expr.IndexOf(">")>=0 )
			{
				string []sss=expr.Split(">".ToCharArray());
				fieldname=sss[0];
				operation=">";
				value= Convert.ToString(sss[sss.Length-1]);
			}
			else if(expr.IndexOf("<")>=0 )
			{
				string []sss=expr.Split("<".ToCharArray());
				fieldname=sss[0];
				operation="<";
				value= Convert.ToString(sss[sss.Length-1]);
			}
			else if(expr.IndexOf("!~")>=0 )
			{
				string []sss=expr.Split("!~".ToCharArray());
				fieldname=sss[0];
				operation="NOT LIKE";
				value= Convert.ToString(sss[sss.Length-1]);
			}
			else if(expr.IndexOf("~")>=0 )
			{
				string []sss=expr.Split("~".ToCharArray());
				fieldname=sss[0];
				operation="LIKE";
				value= Convert.ToString(sss[sss.Length-1]);
			}
			
			value = ((string)value).Substring(1,((string)value).Length -2);
		}


	}
}
