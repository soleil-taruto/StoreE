using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Shootings.SHWalls;
using Charlotte.Shootings.SHWalls.Tests;

namespace Charlotte.Shootings.SHScripts.Tests
{
	public class SHScript_Test壁紙0001 : SHScript
	{
		protected override IEnumerable<bool> E_EachFrame()
		{
			Shooting.I.Walls.Add(new SHWall_Dark());

			for (; ; )
			{
				Shooting.I.Walls.Add(new SHWall_Test0001());

				for (int c = 0; c < 300; c++)
					yield return true;

				Shooting.I.Walls.Add(new SHWall_Test0002());

				for (int c = 0; c < 300; c++)
					yield return true;

				Shooting.I.Walls.Add(new SHWall_Test0003());

				for (int c = 0; c < 300; c++)
					yield return true;

				Shooting.I.Walls.Add(new SHWall_Test0004());

				for (int c = 0; c < 300; c++)
					yield return true;
			}
		}
	}
}
