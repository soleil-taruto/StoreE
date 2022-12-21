using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;

namespace Charlotte.Shootings.SHWalls
{
	public class SHWall_Dark : SHWall
	{
		public override IEnumerable<bool> E_Draw()
		{
			this.FilledFlag = true;

			for (; ; )
			{
				DDCurtain.DrawCurtain();
				yield return true;
			}
		}
	}
}
