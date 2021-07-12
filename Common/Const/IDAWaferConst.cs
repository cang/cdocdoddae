using System;
using System.Collections;

namespace SiGlaz.Common.DDA.Const
{
	public class IDAWaferConst
	{
		#region Members
		public const string WaferID = "Wafer ID";
		public const string SlotID = "Slot ID";
		public const string LotID = "Lot ID";
		public const string StepID = "Step ID";
		public const string GroupStep = "Group Step";
		public const string GroupDevice = "Group Device";
		public const string DeviceID = "Device ID";
		public const string SetupID = "Setup ID";
		public const string ResultTimestamp = "ResultTimestamp";
		public const string SignatureName = "Signature Name";
		public const string SignatureDefectCount = "Signature Defect Count";
		public const string SignatureDefectiveDieCount = "Signature Defective Die Count";
		public const string SignatureDefectiveDiePercentage = "Signature Defective Die Percentage";
		public const string InspectionEquipmentID = "Inspection Equipment ID";
		public const string InspectionEquipmentManufacturer = "Inspection Equipment Manufacturer";
		public const string InspectionModel = "Inspection Model";
		public const string CreateTime = "Create Time";
		public const string FabID = "Fab ID";
		public const string WaferDefectCount = "Wafer Defect Count";
		public const string WaferDefectiveDieCount = "Wafer Defective Die Count";
		public const string WaferInspectedDieCount = "Wafer Inspected Die Count";
		public const string ProcessEquipmentList = "Process Equipment List";
		#endregion
		
		#region Constructor
		public IDAWaferConst()
		{
		}
		#endregion

		#region Staic Methods
		public static string GetColumnName(string name)
		{
			switch (name)
			{
				case WaferID:
					return "WaferID";
				case SlotID:
					return "SlotID";
				case LotID:
					return "LotID";
				case StepID:
					return "StepID";
				case GroupDevice:
					return "GroupDevice";
				case GroupStep:
					return "GroupStep";
				case DeviceID:
					return "DeviceID";
				case SetupID:
					return "SetupID";
				case ResultTimestamp:
					return "ResultTimestamp";
				case SignatureName:
					return "SignatureName";
				case SignatureDefectCount:
					return "NumOfDefect";
				case SignatureDefectiveDieCount:
					return "NumOfDefectiveDie";
				case SignatureDefectiveDiePercentage:
					return "DefDiePercentage";
				case InspectionEquipmentID:
					return "InspectionEquipmentID";
				case InspectionEquipmentManufacturer:
					return "InspectionEquipmentManufacturer";
				case InspectionModel:
					return "InspectionModel";
				case CreateTime:
					return "CreateTime";
				case FabID:
					return "FabID";
				case WaferDefectCount:
					return "DefectCount";
				case WaferDefectiveDieCount:
					return "NumOfDefectiveDie";
				case WaferInspectedDieCount:
					return "NumOfInspectedDie";
				case ProcessEquipmentList:
					return "ProcessEquipmentList";
				default:
					return string.Empty;
			}
		}

		public static ArrayList IDAWaferFieldListOption
		{
			get 
			{ 
				ArrayList alResult = new ArrayList();
				alResult.Add(CreateTime);
				alResult.Add(DeviceID);
				alResult.Add(FabID);
				alResult.Add(GroupDevice);
				alResult.Add(GroupStep);
				alResult.Add(InspectionEquipmentID);
				alResult.Add(LotID);
				alResult.Add(ResultTimestamp);
				alResult.Add(SetupID);
				alResult.Add(SignatureDefectCount);
				alResult.Add(SignatureDefectiveDieCount);
				alResult.Add(SignatureDefectiveDiePercentage);
				alResult.Add(SignatureName);
				alResult.Add(SlotID);
				alResult.Add(StepID);
				alResult.Add(WaferID);
				alResult.Add(WaferDefectCount);
				alResult.Add(WaferDefectiveDieCount);
				alResult.Add(WaferInspectedDieCount);

				return alResult;
			}
		}
		#endregion
	}
}
