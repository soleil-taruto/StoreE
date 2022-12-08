using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0002
	{
		public void Test01()
		{
			Test01_a(@"C:\Factory", "*.c", SCommon.ENCODING_SJIS);
			Test01_a(@"C:\Factory", "*.h", SCommon.ENCODING_SJIS);
			Test01_a(@"C:\Dev", "*.cs", Encoding.UTF8);
		}

		private void Test01_a(string rootDir, string wildCard, Encoding encoding)
		{
			string[] files = Directory.GetFiles(rootDir, wildCard, SearchOption.AllDirectories);

			foreach (string file in files)
			{
				string[] lines = File.ReadAllLines(file, encoding);

				for (int index = 1; index + 1 < lines.Length; index++)
				{
					string trLine_01 = lines[index - 1].Trim();
					string trLine_02 = lines[index].Trim();
					string trLine_03 = lines[index + 1].Trim();

					if (trLine_02.StartsWith("else"))
					{
						int c = 0;

						if (trLine_01.StartsWith("}")) c++;
						if (trLine_03.StartsWith("{")) c++;

						if (c == 1)
						{
							Console.WriteLine(file);
						}
					}
				}

				/*
				foreach (string line in lines)
					if (line.EndsWith("\t") || line.EndsWith(" "))
						Console.WriteLine(file);
				 * */
			}
		}
	}
}
