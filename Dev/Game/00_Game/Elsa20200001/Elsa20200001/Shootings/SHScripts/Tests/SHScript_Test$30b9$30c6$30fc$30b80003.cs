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
using Charlotte.Novels;

namespace Charlotte.Shootings.SHScripts.Tests
{
	public class SHScript_Testステージ0003 : SHScript
	{
		protected override IEnumerable<bool> E_EachFrame()
		{
			DDRandom rand = new DDRandom(3);
			DDRandom rand_Sub = new DDRandom(103);

			Ground.I.Music.SHStage_03.Play();
			Shooting.I.Walls.Add(new SHWall_Test0004());

			foreach (var relay in Enumerable.Repeat(true, 100))
				yield return relay;

			foreach (DDScene scene in DDSceneUtils.Create((1 * 60 + 35) * 60))
			{
				DDGround.EL.Add(() =>
				{
					DDPrint.SetDebug(DDConsts.Screen_W - 180, 0);
					DDPrint.SetBorder(new I3Color(0, 0, 0));
					DDPrint.Print(scene.Numer + " / " + scene.Denom + " = " + scene.Rate.ToString("F3"));
					DDPrint.Reset();

					return false;
				});

				if (rand.GetReal1() < scene.Rate * 0.1)
				{
					if (rand.GetReal1() < 0.1)
					{
						SHEnemy_TestItem.効用_e 効用;

						if (rand_Sub.GetReal1() < 0.1)
							効用 = SHEnemy_TestItem.効用_e.ZANKI_UP;
						else if (rand_Sub.GetReal1() < 0.2)
							効用 = SHEnemy_TestItem.効用_e.BOMB_ADD;
						else
							効用 = SHEnemy_TestItem.効用_e.POWER_UP_WEAPON;

						Shooting.I.Enemies.Add(new SHEnemy_Test0002(DDConsts.Screen_W + 50, rand.GetReal1() * DDConsts.Screen_H));
						SHEnemyCommon_Tests.AddKillEvent(
							Shooting.I.Enemies[Shooting.I.Enemies.Count - 1],
							enemy => Shooting.I.Enemies.Add(new SHEnemy_TestItem(enemy.X, enemy.Y, 効用))
							);
					}
					else if (rand.GetReal1() < 0.3)
					{
						Shooting.I.Enemies.Add(new SHEnemy_Test0002(DDConsts.Screen_W + 50, rand.GetReal1() * DDConsts.Screen_H));
					}
					else
					{
						Shooting.I.Enemies.Add(new SHEnemy_Test0001(DDConsts.Screen_W + 50, rand.GetReal1() * DDConsts.Screen_H));
					}
				}
				yield return true;
			}

			Shooting.I.システム的な敵クリア();

			foreach (var relay in Enumerable.Repeat(true, 120))
				yield return relay;

			Ground.I.Music.SHBoss_03.Play();
			Shooting.I.Walls.Add(new SHWall_Test0003());

			foreach (var relay in Enumerable.Repeat(true, 120))
				yield return relay;

			{
				SHEnemy boss = new SHEnemy_Testボス0003();

				Shooting.I.Enemies.Add(boss);

				while (!boss.DeadFlag)
				{
					DDGround.EL.Add(() =>
					{
						DDPrint.SetDebug(DDConsts.Screen_W - 140, 0);
						DDPrint.SetBorder(new I3Color(0, 0, 0));
						DDPrint.Print("BOSS_HP = " + boss.HP);
						DDPrint.Reset();

						return false;
					});

					yield return true;
				}
			}

			foreach (var relay in Enumerable.Repeat(true, 120))
				yield return relay;

			DDMusicUtils.Fadeout();

			foreach (var relay in Enumerable.Repeat(true, 120))
				yield return relay;

			// ここは最終ステージ

			DDCurtain.SetCurtain(30, -1.0);

			foreach (var relay in Enumerable.Repeat(true, 40))
				yield return relay;

			Shooting.I.EndReason = Shooting.EndReason_e.AllStageCleared;
		}
	}
}
