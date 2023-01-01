using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0005
	{
		public void Test01()
		{
			int m = 0;

			for (int c = 0; c < 256; c++)
			{
				m ^= c;

				Console.WriteLine(c + " ==> " + m);
			}
		}
	}
}
