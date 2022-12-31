using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using System.IO;

namespace Charlotte
{
	/// <summary>
	/// 差分情報
	/// </summary>
	public class DifferenceData
	{
		public class FileData
		{
			public string StrPath;
			public string EntityFilePath;
			public long LastWriteTimeStamp;

			public static FileData Create(CatalogData.FileData cfd, string rootDir)
			{
				string entityFilePath = Path.Combine(rootDir, cfd.StrPath);

				if (!File.Exists(entityFilePath))
					throw new Exception("no entityFilePath");

				return new FileData()
				{
					StrPath = cfd.StrPath,
					EntityFilePath = entityFilePath,
					LastWriteTimeStamp = cfd.LastWriteTimeStamp,
				};
			}
		}

		public List<string> LostDirs;
		public List<string> AddedDirs;
		public List<string> LostFiles;
		public List<FileData> AddedFiles;
		public List<FileData> UpdatedFiles;

		/// <summary>
		/// カタログ情報から差分情報を生成する。
		/// </summary>
		/// <param name="rCatalog">入力側カタログ情報</param>
		/// <param name="wCatalog">出力側カタログ情報</param>
		/// <param name="inputDir">入力ディレクトリ</param>
		/// <returns>差分情報</returns>
		public static DifferenceData Create(CatalogData rCatalog, CatalogData wCatalog, string inputDir)
		{
			if (rCatalog == null)
				throw new Exception("no rCatalog");

			if (wCatalog == null)
				throw new Exception("no wCatalog");

			inputDir = SCommon.MakeFullPath(inputDir);

			if (!Directory.Exists(inputDir))
				throw new Exception("no inputDir");

			// ----

			DifferenceData difference = new DifferenceData();

			// ディレクトリ
			{
				List<string> only1 = new List<string>();
				List<string> both1 = new List<string>();
				List<string> both2 = new List<string>();
				List<string> only2 = new List<string>();

				SCommon.Merge(rCatalog.Dirs, wCatalog.Dirs, SCommon.Comp, only1, both1, both2, only2);

				difference.LostDirs = only1;
				difference.AddedDirs = only2;
			}

			// ファイル
			{
				List<CatalogData.FileData> only1 = new List<CatalogData.FileData>();
				List<CatalogData.FileData> both1 = new List<CatalogData.FileData>();
				List<CatalogData.FileData> both2 = new List<CatalogData.FileData>();
				List<CatalogData.FileData> only2 = new List<CatalogData.FileData>();

				SCommon.Merge(rCatalog.Files, wCatalog.Files, (a, b) => SCommon.Comp(a.StrPath, b.StrPath), only1, both1, both2, only2);

				difference.LostFiles = only1.Select(v => v.StrPath).ToList();
				difference.AddedFiles = only2.Select(v => FileData.Create(v, inputDir)).ToList();
				difference.UpdatedFiles = new List<FileData>();

				for (int index = 0; index < both1.Count; index++)
				{
					CatalogData.FileData cfd1 = both1[index];
					CatalogData.FileData cfd2 = both2[index];

					if (P_IsDifference(cfd1, cfd2))
					{
						difference.UpdatedFiles.Add(FileData.Create(cfd1, inputDir));
					}
				}
			}

			return difference;
		}

		private static bool P_IsDifference(CatalogData.FileData a, CatalogData.FileData b)
		{
			if (a.Size != b.Size)
				return true;

			long sec1 = SCommon.TimeStampToSec.ToSec(a.LastWriteTimeStamp);
			long sec2 = SCommon.TimeStampToSec.ToSec(b.LastWriteTimeStamp);

			if (2 <= Math.Abs(sec1 - sec2))
				return true;

			return false;
		}

		/// <summary>
		/// 差分情報を指定ディレクトリに保存する。
		/// </summary>
		/// <param name="differenceDir">指定ディレクトリ</param>
		public void SaveToDiffDir(string differenceDir)
		{
			differenceDir = SCommon.MakeFullPath(differenceDir);

			SCommon.DeletePath(differenceDir);
			SCommon.CreateDir(differenceDir);

			// ----

			List<string> dest = new List<string>();

			dest.Add(Consts.DIFFERENCE_FILE_SIGNATURE);

			foreach (string dir in this.LostDirs)
			{
				dest.Add("R");
				dest.Add(dir);
			}
			foreach (string dir in this.AddedDirs)
			{
				dest.Add("M");
				dest.Add(dir);
			}
			foreach (string file in this.LostFiles)
			{
				dest.Add("D");
				dest.Add(file);
			}

			P_FileCounter = 1;

			foreach (FileData file in this.AddedFiles)
			{
				dest.Add("A");
				P_Write(dest, file, differenceDir);
			}
			foreach (FileData file in this.UpdatedFiles)
			{
				dest.Add("U");
				P_Write(dest, file, differenceDir);
			}

			File.WriteAllLines(Path.Combine(differenceDir, "0"), dest, Encoding.UTF8);
		}

		private int P_FileCounter;

		private void P_Write(List<string> dest, FileData file, string differenceDir)
		{
			string name = "" + (P_FileCounter++);

			string rFile = file.EntityFilePath;
			string wFile = Path.Combine(differenceDir, name);

			File.Copy(rFile, wFile);

			dest.Add(file.StrPath);
			dest.Add(name);
			dest.Add("" + file.LastWriteTimeStamp);
		}

		/// <summary>
		/// 差分情報を指定ディレクトリから読み込む。
		/// </summary>
		/// <param name="differenceDir">指定ディレクトリ</param>
		/// <returns>差分情報</returns>
		public static DifferenceData LoadFromDiffDir(string differenceDir)
		{
			differenceDir = SCommon.MakeFullPath(differenceDir);

			if (!Directory.Exists(differenceDir))
				throw new Exception("no differenceDir");

			// ----

			string[] lines = File.ReadAllLines(differenceDir, Encoding.UTF8);
			int r = 0;

			DifferenceData difference = new DifferenceData()
			{
				LostDirs = new List<string>(),
				AddedDirs = new List<string>(),
				LostFiles = new List<string>(),
				AddedFiles = new List<FileData>(),
				UpdatedFiles = new List<FileData>(),
			};

			if (lines[r++] != Consts.DIFFERENCE_FILE_SIGNATURE)
				throw new Exception("Bad DIFFERENCE_FILE_SIGNATURE");

			for (; ; )
			{
				switch (lines[r++])
				{
					case "R":
						difference.LostDirs.Add(lines[r++]);
						break;

					case "M":
						difference.AddedDirs.Add(lines[r++]);
						break;

					case "D":
						difference.LostFiles.Add(lines[r++]);
						break;

					case "A":
						P_Read(difference.AddedFiles, () => lines[r++], differenceDir);
						break;

					case "U":
						P_Read(difference.UpdatedFiles, () => lines[r++], differenceDir);
						break;

					case "E":
						goto endLoop;

					default:
						throw new Exception("Bad command");
				}
			}
		endLoop:

			// 簡単なチェック
			{
				foreach (string dir in difference.LostDirs)
				{
					if (string.IsNullOrEmpty(dir))
						throw new Exception("Bad LostDir");
				}

				foreach (string dir in difference.AddedDirs)
				{
					if (string.IsNullOrEmpty(dir))
						throw new Exception("Bad AddedDir");
				}

				foreach (string file in difference.LostFiles)
				{
					if (string.IsNullOrEmpty(file))
						throw new Exception("Bad LostFile");
				}

				foreach (FileData file in difference.AddedFiles)
				{
					if (string.IsNullOrEmpty(file.StrPath))
						throw new Exception("Bad AddedFile.StrPath");

					if (string.IsNullOrEmpty(file.EntityFilePath))
						throw new Exception("Bad AddedFile.EntityFilePath");

					if (!File.Exists(file.EntityFilePath))
						throw new Exception("no AddedFile.EntityFilePath");

					if (!Common.IsFairTimeStamp(file.LastWriteTimeStamp))
						throw new Exception("Bad AddedFile.LastWriteTimeStamp");
				}

				foreach (FileData file in difference.UpdatedFiles)
				{
					if (string.IsNullOrEmpty(file.StrPath))
						throw new Exception("Bad UpdatedFile.StrPath");

					if (string.IsNullOrEmpty(file.EntityFilePath))
						throw new Exception("Bad UpdatedFile.EntityFilePath");

					if (!File.Exists(file.EntityFilePath))
						throw new Exception("no UpdatedFile.EntityFilePath");

					if (!Common.IsFairTimeStamp(file.LastWriteTimeStamp))
						throw new Exception("Bad UpdatedFile.LastWriteTimeStamp");
				}
			}

			return difference;
		}

		private static void P_Read(List<FileData> dest, Func<string> reader, string differenceDir)
		{
			FileData file = new FileData();

			file.StrPath = reader();
			file.EntityFilePath = Path.Combine(differenceDir, reader());
			file.LastWriteTimeStamp = long.Parse(reader());

			dest.Add(file);
		}

		/// <summary>
		/// 差分を適用する。
		/// </summary>
		/// <param name="outputDir">出力ディレクトリ</param>
		public void Patching(string outputDir)
		{
			outputDir = SCommon.MakeFullPath(outputDir);

			if (!Directory.Exists(outputDir))
				throw new Exception("no outputDir");

			// ----

			foreach (string dir in this.LostDirs.Select(v => Path.Combine(outputDir, v)))
			{
				SCommon.DeletePath(dir);
			}
			foreach (string dir in this.LostDirs.Select(v => Path.Combine(outputDir, v)))
			{
				SCommon.CreateDir(dir);
			}
			foreach (string file in this.LostFiles.Select(v => Path.Combine(outputDir, v)))
			{
				SCommon.DeletePath(file);
			}
			foreach (FileData file in this.AddedFiles)
			{
				string rFile = file.EntityFilePath;
				string wFile = Path.Combine(outputDir, file.StrPath);

				File.Copy(rFile, wFile);
			}
			foreach (FileData file in this.UpdatedFiles)
			{
				string rFile = file.EntityFilePath;
				string wFile = Path.Combine(outputDir, file.StrPath);

				SCommon.DeletePath(wFile);

				File.Copy(rFile, wFile);
			}
		}
	}
}
