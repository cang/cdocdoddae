using System;
using System.Collections;
using System.Collections.Specialized;
namespace DDADBRObjects
{
	/// <summary>
	/// Summary description for IRSchemaMethod.
	/// </summary>
	public interface IRSchemaMethod
	{
		SchemaEvent RequireSchema();
		void SaveSchema(SchemaEvent e);

		string RunProcess(params int[] processid);
		void StopProcess(params int[] processid);
		string RunAllProcesses();
		void StopAllProcesses();

		byte[]	RequireApplicationConfig();
		bool	SaveApplicationConfig(byte[] lpbyte);

		SiGlaz.DAL.ConnectionParam GetConnectionParam();
		void SetConnectionParam(SiGlaz.DAL.ConnectionParam param);

		void RegisterEvent();
		void UnRegisterEvent();

		StringCollection RequireOutput(int processid);
		StringCollection RequireTrace(int processid);

		bool RequireWaiting(int processid);
		bool RequireRunning(int processid);

		bool RefreshExternalData();

		bool AnyRun();

	}
}
