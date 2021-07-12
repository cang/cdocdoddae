using System;
using System.Collections;
using System.IO;

namespace SiGlaz.Common.DDA
{
	public class DDAResultData 
	{
		#region Members
		private byte[] _DataSourceRaw = null;
		private byte[] _DefectListRaw = null;

		//Processed Data
        //private SSA.SystemFrameworks.KlarfParserFile _Klarf = null;
        //private ArrayList	_DefectList=null;

		#endregion

		#region Constructtor & Destructor 
		public DDAResultData() : base()
		{
		}
		#endregion

		#region Properties
		public byte[] DataSourceRaw
		{
			get { return _DataSourceRaw; }
			set { _DataSourceRaw = value; }
		}

		public byte[] DefectListRaw
		{
			get { return _DefectListRaw; }
			set { _DefectListRaw = value; }
		}

        //public SSA.SystemFrameworks.KlarfParserFile DataSourceKlarf
        //{
        //    get
        //    {
        //        if(_Klarf==null)
        //            UpdateStructFromDrawData();
        //        return _Klarf;
        //    }
        //}

        //public ArrayList	DefectList
        //{
        //    get
        //    {
        //        if(_DefectList==null)
        //            UpdateStructFromDrawData();
        //        return _DefectList;
        //    }
        //}

        //public SSA.SystemFrameworks.KlarfParserFile ResultKlarf
        //{
        //    get
        //    {
        //        if(_Klarf==null)
        //            UpdateStructFromDrawData();

        //        if(this.DataSourceKlarf==null || this.DefectList==null)
        //            return null;

        //        SSA.SystemFrameworks.KlarfParserFile result = _Klarf.CopyHeader();
        //        result.AddDefectsList(this.DefectList);
        //        return result;
        //    }
        //}

		#endregion

		#region archive

		public void SerializeBinary(string filepath)
		{
			if( File.Exists(filepath))
			{
				File.SetAttributes(filepath,FileAttributes.Normal);
				File.Delete(filepath);
			}

			FileStream fs =null;
			BinaryWriter bw  = null;
			try
			{
				fs = File.Create(filepath);
				bw = new BinaryWriter(fs);
				this.Serialize(bw);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(bw!=null)
				{
					bw.Close();
					bw = null;
				}
				if(fs!=null)
				{
					fs.Close();
					fs = null;
				}
			}
		}

		public void	DeserializeBinary(string filepath)
		{
			if(!File.Exists(filepath))
				throw new IOException("File do not exist");

			FileStream fs =null;
			BinaryReader br  = null;
			try
			{
				fs = File.Open(filepath,FileMode.Open,FileAccess.Read,FileShare.Read);
				br = new BinaryReader(fs );
				this.Deserialize(br);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(br!=null)
				{
					br.Close();
					br = null;
				}
				if(fs!=null)
				{
					fs.Close();
					fs = null;
				}
			}
		}

		public void Serialize(BinaryWriter stream)
		{
			//Length Klarf File
			stream.Write(_DataSourceRaw.Length);
			
			//Write Klarf File
			stream.Write(_DataSourceRaw);

			//Length Result Defect List
			int length = 0;

			if (_DefectListRaw != null)
				length = _DefectListRaw.Length;

			stream.Write(length);

			//Write Result Defect List
			if (_DefectListRaw != null)
				stream.Write(_DefectListRaw);
		}

		public void Deserialize(BinaryReader stream)
		{
			int lengthKlarfFile = stream.ReadInt32();
			_DataSourceRaw = stream.ReadBytes(lengthKlarfFile);

			int lengthResultDefectList = stream.ReadInt32();

			if (lengthResultDefectList > 0)
				_DefectListRaw = stream.ReadBytes(lengthResultDefectList);
		}
		#endregion archive

		#region Public Methods

        //public void UpdateStructFromDrawData()
        //{
        //    _Klarf = null;
        //    _DefectList = null;

        //    try
        //    {
        //        //Update Klarf
        //        if(_DataSourceRaw!=null)
        //        {
        //            byte[] buffer = SiGlaz.Utility.Compression.Compressor.DeCompress(_DataSourceRaw);
        //            _Klarf = SSA.SystemFrameworks.KlarfParserFile.OpenSURF(buffer)[0] as SSA.SystemFrameworks.KlarfParserFile;
        //        }

        //        //Update DefectList
        //        if(_DefectListRaw!=null && _Klarf!=null)
        //        {
        //            byte[] buffer = SiGlaz.Utility.Compression.Compressor.DeCompress(_DefectListRaw);
        //            SiGlaz.Common.DDA.ResultDefectList resultDefectList = SiGlaz.Common.DDA.ResultDefectList.Deserialize(buffer) as SiGlaz.Common.DDA.ResultDefectList;

        //            if(resultDefectList!=null && resultDefectList.alDefectListID!=null)
        //                _DefectList = _Klarf.GetDefectList(resultDefectList.alDefectListID);
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //}

		#endregion
	}


	public class DDAResultDataCollection
	{
		#region Members
		private ArrayList _results = null;
		private int _focusedIndex = 0;
		#endregion
		
		#region Constructor
		public DDAResultDataCollection()
		{
			_results = new ArrayList();
		}
		#endregion

		#region Properties
		public int FocusedIndex
		{
			get { return _focusedIndex; }
			set { _focusedIndex = value; }
		}

		public int Count
		{
			get { return _results.Count; }
		}

		public DDAResultData this[int index]
		{
			get
			{
				if (index < 0 || index >= _results.Count)
					return null;

				return (DDAResultData)_results[index];
			}

			set { _results[index] = value; }
		}

		public void Add(DDAResultData result)
		{
			_results.Add(result);
		}
		#endregion
		
		#region Archive
		public void SerializeBinary(string filepath)
		{
			if( File.Exists(filepath))
			{
				File.SetAttributes(filepath,FileAttributes.Normal);
				File.Delete(filepath);
			}

			FileStream fs =null;
			BinaryWriter bw  = null;
			try
			{
				fs = File.Create(filepath);
				bw = new BinaryWriter(fs);
				this.Serialize(bw);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(bw!=null)
				{
					bw.Close();
					bw = null;
				}
				if(fs!=null)
				{
					fs.Close();
					fs = null;
				}
			}
		}

		public void	DeserializeBinary(string filepath)
		{
			if(!File.Exists(filepath))
				throw new IOException("File do not exist");

			FileStream fs =null;
			BinaryReader br  = null;
			try
			{
				fs = File.Open(filepath,FileMode.Open,FileAccess.Read,FileShare.Read);
				br = new BinaryReader(fs );
				this.Deserialize(br);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(br!=null)
				{
					br.Close();
					br = null;
				}
				if(fs!=null)
				{
					fs.Close();
					fs = null;
				}
			}
		}

		public void Serialize(BinaryWriter stream)
		{
			stream.Write(_results.Count);

			foreach (DDAResultData result in _results)
			{
				//Length Klarf File
				stream.Write(result.DataSourceRaw.Length);
			
				//Write Klarf File
				stream.Write(result.DataSourceRaw);

				//Length Result Defect List
				int length = 0;

				if (result.DefectListRaw != null)
					length = result.DefectListRaw.Length;

				stream.Write(length);

				//Write Result Defect List
				if (result.DefectListRaw != null)
					stream.Write(result.DefectListRaw);
			}

			stream.Write(_focusedIndex);
		}

		public void Deserialize(BinaryReader stream)
		{
			if (_results.Count > 0)
				_results.Clear();

			int lengthResult = stream.ReadInt32();

			for (int i = 0; i < lengthResult; i++)
			{
				DDAResultData result = new DDAResultData();

				int lengthKlarfFile = stream.ReadInt32();
				result.DataSourceRaw = stream.ReadBytes(lengthKlarfFile);

				int lengthResultDefectList = stream.ReadInt32();

				if (lengthResultDefectList > 0)
					result.DefectListRaw = stream.ReadBytes(lengthResultDefectList);

				_results.Add(result);
			}
			
			_focusedIndex = stream.ReadInt32();
		}
		#endregion archive
	};
}
