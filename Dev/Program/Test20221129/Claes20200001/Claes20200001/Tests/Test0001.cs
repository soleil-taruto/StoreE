using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			foreach (string file in Directory.GetFiles(@"C:\Dev", "*.cs", SearchOption.AllDirectories).Where(v => !v.EndsWith(".Designer.cs")))
			{
				string[] lines = File.ReadAllLines(file, Encoding.UTF8);

				foreach (string line in lines)
				{
					if (line != "" && line[0] == ' ')
					{
						Console.WriteLine(file);
						break;
					}
				}
			}
		}
	}
}
