﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Charlotte.Commons;
using Charlotte.Tests;

namespace Charlotte
{
	class Program
	{
		static void Main(string[] args)
		{
			ProcMain.CUIMain(new Program().Main2);
		}

		private void Main2(ArgsReader ar)
		{
			if (ProcMain.DEBUG)
			{
				Main3();
			}
			else
			{
				Main4(ar);
			}
			SCommon.OpenOutputDirIfCreated();
		}

		private void Main3()
		{
			// -- choose one --

			Main4(new ArgsReader(new string[] { }));
			//new Test0001().Test01();
			//new Test0002().Test01();
			//new Test0003().Test01();

			// --

			//SCommon.Pause();
		}

		private void Main4(ArgsReader ar)
		{
			try
			{
				Main5(ar);
			}
			catch (Exception ex)
			{
				ProcMain.WriteLog(ex);

				MessageBox.Show("" + ex, Path.GetFileNameWithoutExtension(ProcMain.SelfFile) + " / エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

				//Console.WriteLine("Press ENTER key. (エラーによりプログラムを終了します)");
				//Console.ReadLine();
			}
		}

		private void Main5(ArgsReader ar)
		{
			using (WorkingDir wd = new WorkingDir())
			{
				ProcLogFile = wd.MakePath();
				try
				{
					Main6();
				}
				finally
				{
					ProcLogFile = null;
				}
			}
		}

		private string ProcLogFile;

		private void Main6()
		{
			File.WriteAllBytes(ProcLogFile, SCommon.EMPTY_BYTES);

			ProcMain.WriteLog = message =>
			{
				string line = "[" + DateTime.Now + "] " + message;

				Console.WriteLine(line);

				if (ProcLogFile != null)
				{
					File.AppendAllLines(ProcLogFile, new string[] { line }, SCommon.ENCODING_SJIS);
				}
			};

			ProcMain.WriteLog("BACKUP_ST");

			ProcMain.WriteLog("コピー元：" + Consts.SRC_DIR);
			ProcMain.WriteLog("コピー先：" + Consts.DEST_DIR);

			if (!Directory.Exists(Consts.SRC_DIR))
				throw new Exception("コピー元が存在しません。");

			if (!Directory.Exists(Consts.DEST_DIR))
				throw new Exception("コピー先が存在しません。");

			DistributeLogFile(); // テスト配布

			string[] rDirs = Directory.GetDirectories(Consts.SRC_DIR);
			string[] wDirs = Directory.GetDirectories(Consts.DEST_DIR);

			Array.Sort(rDirs, SCommon.Comp);
			Array.Sort(wDirs, SCommon.Comp);

			foreach (string dir in rDirs)
				ProcMain.WriteLog("1 " + dir);

			foreach (string dir in wDirs)
				ProcMain.WriteLog("2 " + dir);

			string[] rNames = rDirs.Select(dir => SCommon.ChangeRoot(dir, Consts.SRC_DIR)).ToArray();
			string[] wNames = wDirs.Select(dir => SCommon.ChangeRoot(dir, Consts.DEST_DIR)).ToArray();

			rNames = rNames.Where(name => !Consts.SRC_IGNORE_NAMES.Any(ignoreName => SCommon.EqualsIgnoreCase(ignoreName, name))).ToArray();
			wNames = wNames.Where(name => !Consts.DEST_IGNORE_NAMES.Any(ignoreName => SCommon.EqualsIgnoreCase(ignoreName, name))).ToArray();

			List<string> rOnlyNames = new List<string>();
			List<string> wOnlyNames = new List<string>();
			List<string> beNames = new List<string>();
			List<string> beNames_dummy = new List<string>();

			SCommon.Merge(rNames, wNames, SCommon.Comp, rOnlyNames, beNames, beNames_dummy, wOnlyNames);

			beNames_dummy = null;

			ProcMain.WriteLog("---- 新規 ----");
			foreach (string name in rOnlyNames) ProcMain.WriteLog("< " + name);
			ProcMain.WriteLog("---- 更新 ----");
			foreach (string name in beNames) ProcMain.WriteLog("* " + name);
			ProcMain.WriteLog("---- 削除 (特別なフォルダは一旦削除されます) ----");
			foreach (string name in wOnlyNames) ProcMain.WriteLog("> " + name);
			ProcMain.WriteLog("----");

			ProcMain.WriteLog("CONFIRM_OPEN");
			if (MessageBox.Show(
				"バックアップを開始します。\n" +
				"以下のプログラムは終了させて下さい。\n" +
				"・CrystalDiskInfo\n" +
				"・Becky",
				"バックアップ開始",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Information
				) != DialogResult.OK
				)
			{
				ProcMain.WriteLog("BACKUP_CANCELLED");
				DistributeLogFile();
				return;
			}
			ProcMain.WriteLog("CONFIRM_CLOSED");

			foreach (string name in wOnlyNames)
			{
				string dir = Path.Combine(Consts.DEST_DIR, name);

				ProcMain.WriteLog("RD " + dir);

				P_Batch(string.Format(@"RD /S /Q ""{0}""", dir));
			}
			foreach (string name in rOnlyNames)
			{
				string dir = Path.Combine(Consts.DEST_DIR, name);

				ProcMain.WriteLog("MD " + dir);

				SCommon.CreateDir(dir);
			}
			foreach (string name in beNames.Concat(rOnlyNames))
			{
				string title = name;
				string rDir = Path.Combine(Consts.SRC_DIR, name);
				string wDir = Path.Combine(Consts.DEST_DIR, name);

				ProcMain.WriteLog("< " + rDir);
				ProcMain.WriteLog("> " + wDir);

				ProcMain.WriteLog("ROBOCOPY_ST " + title);

				P_Batch(string.Format(@"ROBOCOPY.EXE ""{0}"" ""{1}"" /MIR", rDir, wDir));

				ProcMain.WriteLog("ROBOCOPY_ED " + title);
			}

			CopySpecialDir(
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				Path.Combine(Consts.DEST_DIR, "デスクトップ"),
				"デスクトップ"
				);

			ProcMain.WriteLog("BACKUP_ED");

			DistributeLogFile();
		}

		private void CopySpecialDir(string rDir, string wDir, string title)
		{
			ProcMain.WriteLog("< " + rDir);
			ProcMain.WriteLog("> " + wDir);

			ProcMain.WriteLog("MD " + wDir);
			SCommon.CreateDir(wDir);

			ProcMain.WriteLog("ROBOCOPY_ST " + title);

			P_Batch(string.Format(@"ROBOCOPY.EXE ""{0}"" ""{1}"" /MIR", rDir, wDir));

			ProcMain.WriteLog("ROBOCOPY_ED " + title);
		}

		private void DistributeLogFile()
		{
			DistributeLogFile_File(Consts.LOG_FILE_1);
			DistributeLogFile_File(Consts.LOG_FILE_2);
		}

		private void DistributeLogFile_File(string destFile)
		{
			SCommon.DeletePath(destFile);

			File.Copy(ProcLogFile, destFile);
		}

		private void P_Batch(string command)
		{
			using (WorkingDir wd = new WorkingDir())
			{
				string outFile = wd.MakePath();
				string errFile = wd.MakePath();
				string outFile2 = wd.MakePath();

				SCommon.Batch(new string[]
				{
					string.Format(@"{0} > ""{1}"" 2> ""{2}""", command, outFile, errFile),
					string.Format(@"> ""{0}"" ECHO ERRORLEVEL=%ERRORLEVEL%", outFile2),
				});

				using (FileStream writer = new FileStream(ProcLogFile, FileMode.Append, FileAccess.Write))
				{
					Action<string> a = file =>
					{
						using (FileStream reader = new FileStream(file, FileMode.Open, FileAccess.Read))
						{
							SCommon.ReadToEnd(reader.Read, writer.Write);
						}
					};

					a(outFile);
					a(errFile);
					a(outFile2);
				}
			}
		}
	}
}
