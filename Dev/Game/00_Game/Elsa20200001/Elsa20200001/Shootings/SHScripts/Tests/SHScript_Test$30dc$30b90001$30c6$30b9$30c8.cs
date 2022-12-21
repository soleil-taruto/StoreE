using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Shootings.SHEnemies;
using Charlotte.Shootings.SHEnemies.Tests;
using Charlotte.Shootings.SHWalls;

namespace Charlotte.Shootings.SHScripts.Tests
{
	public class SHScript_Testボス0001テスト : SHScript
	{
		protected override IEnumerable<bool> E_EachFrame()
		{
			Shooting.I.Walls.Add(new SHWall_Dark());

			Shooting.I.Enemies.Add(new SHEnemy_Testボス0001());

			for (; ; )
			{
				yield return true;
			}
		}
	}
}
