using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;
using Charlotte.Shootings.SHShots;
using Charlotte.Shootings.SHShots.Tests;

namespace Charlotte.Shootings
{
	/// <summary>
	/// プレイヤーに関する情報と機能
	/// 唯一のインスタンスを Game.I.Player に保持する。
	/// </summary>
	public class SHPlayer
	{
		public double X;
		public double Y;
		public double Reborn_X;
		public double Reborn_Y;
		public DDCrash Crash;
		public int DeadFrame = 0; // 0 == 無効, 1～ == 死亡中
		public int RebornFrame = 0; // 0 == 無効, 1～ == 登場中
		public int InvincibleFrame = 0; // 0 == 無効, 1～ == 無敵時間中

		public void Draw()
		{
			if (1 <= this.RebornFrame)
			{
				DDDraw.SetAlpha(0.5);
				DDDraw.DrawCenter(Ground.I.Picture.SHPlayer, this.Reborn_X, this.Reborn_Y);
				DDDraw.Reset();

				return;
			}
			if (1 <= this.DeadFrame)
			{
				// noop // 描画は Game.Perform で行う。

				return;
			}
			if (1 <= this.InvincibleFrame)
			{
				DDDraw.SetAlpha(0.5);
				DDDraw.DrawCenter(Ground.I.Picture.SHPlayer, this.X, this.Y);
				DDDraw.Reset();

				return;
			}
			DDDraw.DrawCenter(Ground.I.Picture.SHPlayer, this.X, this.Y);
		}

		/// <summary>
		/// 攻撃を行う。
		/// </summary>
		public void Fire()
		{
			// memo: 将来的に武器毎にコードが実装され、メソッドがでかくなると思われる。

			if (Shooting.I.Frame % 6 == 0)
			{
				switch (Shooting.I.Status.SHAttackLevel)
				{
					case 0:
						Shooting.I.Shots.Add(new SHShot_Test0001(this.X + 38.0, this.Y));
						break;

					case 1:
						Shooting.I.Shots.Add(new SHShot_Test0001(this.X + 38.0, this.Y - 16.0));
						Shooting.I.Shots.Add(new SHShot_Test0001(this.X + 38.0, this.Y + 16.0));
						break;

					case 2:
						Shooting.I.Shots.Add(new SHShot_Test0001(this.X + 38.0, this.Y - 32.0));
						Shooting.I.Shots.Add(new SHShot_Test0001(this.X + 38.0, this.Y));
						Shooting.I.Shots.Add(new SHShot_Test0001(this.X + 38.0, this.Y + 32.0));
						break;

					case 3:
						Shooting.I.Shots.Add(new SHShot_Test0001(this.X + 20.0, this.Y - 48.0));
						Shooting.I.Shots.Add(new SHShot_Test0001(this.X + 38.0, this.Y - 16.0));
						Shooting.I.Shots.Add(new SHShot_Test0001(this.X + 38.0, this.Y + 16.0));
						Shooting.I.Shots.Add(new SHShot_Test0001(this.X + 20.0, this.Y + 48.0));
						break;

					default:
						throw null; // never
				}
				Ground.I.SE.SHPlayerShoot.Play();
			}
		}

		public void Bomb()
		{
			if (!Isボム発動中() && DDUtils.CountDown(ref Shooting.I.Status.SHZanBomb))
			{
				Shooting.I.Shots.Add(new SHShot_Testボム0001());
			}
		}

		private static bool Isボム発動中()
		{
			return Shooting.I.Shots.Iterate().Any(shot => shot.Kind == SHShot.Kind_e.ボム);
		}
	}
}
