using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;

namespace Charlotte.TopViews.TVWalls
{
	public class TVWall_Dark : TVWall
	{
		protected override IEnumerable<bool> E_Draw()
		{
			for (; ; )
			{
				DDCurtain.DrawCurtain();
				yield return true;
			}
		}
	}
}
