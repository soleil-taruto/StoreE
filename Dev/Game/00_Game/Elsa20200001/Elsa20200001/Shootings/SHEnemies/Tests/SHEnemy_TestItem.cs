using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.Shootings.SHShots;

namespace Charlotte.Shootings.SHEnemies.Tests
{
	public class SHEnemy_TestItem : SHEnemy
	{
		public enum 効用_e
		{
			ZANKI_UP,
			BOMB_ADD,
			POWER_UP_WEAPON,
		}

		public static string[] 効用_e_Names = new string[]
		{
			"★★★ 残 機 追 加 ★★★",
			"☆☆☆ ボ ム 追 加 ☆☆☆",
			"武器パワーアップ",
		};

		private 効用_e 効用;

		public SHEnemy_TestItem(double x, double y, 効用_e 効用)
			: base(x, y, 0, Kind_e.アイテム)
		{
			this.効用 = 効用;
		}

		protected override IEnumerable<bool> E_Draw()
		{
			double xSpeed = 1.0;

			for (; ; )
			{
				xSpeed -= 0.1;
				this.X += xSpeed;

				if (DDUtils.GetDistance(new D2Point(Shooting.I.Player.X, Shooting.I.Player.Y), new D2Point(this.X, this.Y)) < 60.0)
				{
					this.プレイヤーがアイテムを取得した();
					break;
				}

				DDDraw.DrawBegin(Ground.I.Picture.Dummy, this.X, this.Y);
				DDDraw.DrawRotate(DDEngine.ProcFrame / 10.0);
				DDDraw.DrawEnd();

				DDPrint.SetDebug((int)this.X, (int)this.Y);
				DDPrint.SetBorder(new I3Color(0, 0, 0));
				DDPrint.PrintLine("アイテム");
				DDPrint.PrintLine("効用：" + 効用_e_Names[(int)this.効用]);
				DDPrint.Reset();

				// 当たり判定無し

				yield return true;
			}
		}

		private void プレイヤーがアイテムを取得した()
		{
			switch (this.効用)
			{
				case 効用_e.ZANKI_UP:
					Shooting.I.Status.SHZanki++;
					break;

				case 効用_e.BOMB_ADD:
					Shooting.I.Status.SHZanBomb++;
					break;

				case 効用_e.POWER_UP_WEAPON:
					Shooting.I.Status.SHAttackLevel = Math.Min(Shooting.I.Status.SHAttackLevel + 1, ShootingConsts.ATTACK_LEVEL_MAX);
					break;

				default:
					throw null; // never
			}
			Ground.I.SE.SHPowerUp.Play();
		}

		protected override void P_Damaged(SHShot shot, int damagePoint)
		{
			// noop
		}

		protected override void P_Killed(bool destroyed)
		{
			// noop
		}
	}
}
