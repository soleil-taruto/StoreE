using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.Shootings.SHEnemies;
using Charlotte.Shootings.SHEnemies.Tests;
using Charlotte.Shootings.SHWalls;
using Charlotte.Shootings.SHWalls.Tests;

namespace Charlotte.Shootings.SHScripts.Tests
{
	public class SHScript_Test0004 : SHScript
	{
		protected override IEnumerable<bool> E_EachFrame()
		{
			DDRandom rand = new DDRandom(1);

			Ground.I.Music.SHStage_01.Play();

			Shooting.I.Walls.Add(new SHWall_Dark());
			Shooting.I.Walls.Add(new SHWall_Test0003());

			foreach (var relay in Enumerable.Repeat(true, 100))
				yield return relay;

			for (int c = 0; c < 3; c++)
			{
				Shooting.I.Enemies.Add(new SHEnemy_Test0002(DDConsts.Screen_W + 50, DDConsts.Screen_H / 4 * 1));
				foreach (var relay in Enumerable.Repeat(true, 120)) yield return relay;
			}

			Shooting.I.Enemies.Add(new SHEnemy_Test0002(DDConsts.Screen_W + 50, DDConsts.Screen_H / 4 * 1));
			SHEnemyCommon_Tests.AddKillEvent(
				Shooting.I.Enemies[Shooting.I.Enemies.Count - 1],
				enemy => Shooting.I.Enemies.Add(new SHEnemy_TestItem(enemy.X, enemy.Y, SHEnemy_TestItem.効用_e.POWER_UP_WEAPON))
				);

			foreach (var relay in Enumerable.Repeat(true, 120))
				yield return relay;

			Shooting.I.Walls.Add(new SHWall_Test0004());

			foreach (var relay in Enumerable.Repeat(true, 100))
				yield return relay;

			for (int c = 0; c < 3; c++)
			{
				Shooting.I.Enemies.Add(new SHEnemy_Test0002(DDConsts.Screen_W + 50, DDConsts.Screen_H / 4 * 3));

				foreach (var relay in Enumerable.Repeat(true, 120))
					yield return relay;
			}
			for (int c = 0; c < 10; c++)
			{
				Shooting.I.Enemies.Add(new SHEnemy_Test0001(DDConsts.Screen_W + 50, DDConsts.Screen_H / 2));

				foreach (var relay in Enumerable.Repeat(true, 30))
					yield return relay;
			}
			for (int c = 0; c < 10; c++)
			{
				Shooting.I.Enemies.Add(new SHEnemy_Test0001(DDConsts.Screen_W + 50, DDConsts.Screen_H / 4 * 1));
				Shooting.I.Enemies.Add(new SHEnemy_Test0001(DDConsts.Screen_W + 50, DDConsts.Screen_H / 4 * 3));

				foreach (var relay in Enumerable.Repeat(true, 30))
					yield return relay;
			}
			for (int c = 0; c < 30; c++)
			{
				Shooting.I.Enemies.Add(new SHEnemy_Test0001(DDConsts.Screen_W + 50, rand.GetInt(DDConsts.Screen_H)));

				foreach (var relay in Enumerable.Repeat(true, 10))
					yield return relay;
			}
			for (int c = 0; c < 60; c++)
			{
				Shooting.I.Enemies.Add(new SHEnemy_Test0001(DDConsts.Screen_W + 50, rand.GetInt(DDConsts.Screen_H)));

				foreach (var relay in Enumerable.Repeat(true, 5))
					yield return relay;
			}
			for (int c = 0; c < 120; c++)
			{
				Shooting.I.Enemies.Add(new SHEnemy_Test0001(DDConsts.Screen_W + 50, rand.GetInt(DDConsts.Screen_H)));

				foreach (var relay in Enumerable.Repeat(true, 2))
					yield return relay;
			}
			foreach (var relay in Enumerable.Repeat(true, 100))
				yield return relay;

			for (int c = 0; c < 3; c++)
			{
				Shooting.I.Enemies.Add(new SHEnemy_Test0002(DDConsts.Screen_W + 50, DDConsts.Screen_H / 4 * 1));
				Shooting.I.Enemies.Add(new SHEnemy_Test0002(DDConsts.Screen_W + 50, DDConsts.Screen_H / 4 * 3));

				foreach (var relay in Enumerable.Repeat(true, 120))
					yield return relay;
			}
			foreach (var relay in Enumerable.Repeat(true, 200))
				yield return relay;

			for (int c = 0; c < 3; c++)
			{
				Shooting.I.Enemies.Add(new SHEnemy_Test0002(DDConsts.Screen_W + 50, DDConsts.Screen_H / 6 * 1));

				foreach (var relay in Enumerable.Repeat(true, 30))
					yield return relay;

				Shooting.I.Enemies.Add(new SHEnemy_Test0002(DDConsts.Screen_W + 50, DDConsts.Screen_H / 6 * 3));

				foreach (var relay in Enumerable.Repeat(true, 30))
					yield return relay;

				Shooting.I.Enemies.Add(new SHEnemy_Test0002(DDConsts.Screen_W + 50, DDConsts.Screen_H / 6 * 5));

				foreach (var relay in Enumerable.Repeat(true, 60))
					yield return relay;
			}
			foreach (var relay in Enumerable.Repeat(true, 300))
				yield return relay;

			// ---- ここからボス ----

			Ground.I.Music.SHBoss_01.Play();

			Shooting.I.Enemies.Add(new SHEnemy_Testボス0001());

			for (; ; )
				yield return true; // 以降何もしない。
		}
	}
}
