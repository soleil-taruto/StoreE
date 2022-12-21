using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Shootings.SHWalls;

namespace Charlotte.Shootings.SHScripts.Tests
{
	public class SHScript_Test何もなし0001 : SHScript
	{
		protected override IEnumerable<bool> E_EachFrame()
		{
			Shooting.I.Walls.Add(new SHWall_Dark());

			for (; ; )
			{
				yield return true;
			}
		}
	}
}
