using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;
using Charlotte.Shootings.SHEnemies;
using Charlotte.Shootings.SHEnemies.Tests;
using Charlotte.Shootings.SHWalls;
using Charlotte.Shootings.SHWalls.Tests;

namespace Charlotte.Shootings.SHScripts.Tests
{
	public class SHScript_Test0002 : SHScript
	{
		protected override IEnumerable<bool> E_EachFrame()
		{
			Shooting.I.Walls.Add(new SHWall_Dark());

			for (; ; )
			{
				Shooting.I.Walls.Add(new SHWall_Test0003());

				Shooting.I.Enemies.Add(new SHEnemy_Test0001(DDConsts.Screen_W + 50.0, DDConsts.Screen_H / 2.0));

				for (int c = 0; c < 500; c++)
					yield return true;

				Shooting.I.Walls.Add(new SHWall_Test0004());

				Shooting.I.Enemies.Add(new SHEnemy_Test0001(DDConsts.Screen_W + 50.0, DDConsts.Screen_H / 2.0));

				for (int c = 0; c < 500; c++)
					yield return true;
			}
		}
	}
}
