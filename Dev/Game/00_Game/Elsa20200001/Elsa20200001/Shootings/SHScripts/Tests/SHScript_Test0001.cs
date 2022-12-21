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
	public class SHScript_Test0001 : SHScript
	{
		protected override IEnumerable<bool> E_EachFrame()
		{
			Shooting.I.Walls.Add(new SHWall_Dark());

			for (; ; )
			{
				Shooting.I.Walls.Add(new SHWall_Test0001());

				foreach (DDScene scene in DDSceneUtils.Create(10))
				{
					Shooting.I.Enemies.Add(new SHEnemy_Test0001(
						DDConsts.Screen_W + 50.0,
						100.0 + scene.Rate * 200.0
						));

					for (int c = 0; c < 20; c++)
						yield return true;
				}

				for (int c = 0; c < 60; c++)
					yield return true;

				foreach (DDScene scene in DDSceneUtils.Create(10))
				{
					Shooting.I.Enemies.Add(new SHEnemy_Test0001(
						DDConsts.Screen_W + 50.0,
						DDConsts.Screen_H - 100.0 - scene.Rate * 200.0
						));

					for (int c = 0; c < 20; c++)
						yield return true;
				}

				for (int c = 0; c < 60; c++)
					yield return true;

				Shooting.I.Walls.Add(new SHWall_Test0002());

				foreach (DDScene scene in DDSceneUtils.Create(20))
				{
					Shooting.I.Enemies.Add(new SHEnemy_Test0001(
						DDConsts.Screen_W + 50.0,
						DDConsts.Screen_H * DDUtils.Random.GetReal1()
						));

					for (int c = 0; c < 10; c++)
						yield return true;
				}

				for (int c = 0; c < 60; c++)
					yield return true;

				foreach (DDScene scene in DDSceneUtils.Create(20))
				{
					Shooting.I.Enemies.Add(new SHEnemy_Test0001(
						DDConsts.Screen_W + 50.0,
						DDConsts.Screen_H * DDUtils.Random.GetReal1()
						));

					for (int c = 0; c < 10; c++)
						yield return true;
				}

				for (int c = 0; c < 60; c++)
					yield return true;
			}
		}
	}
}
