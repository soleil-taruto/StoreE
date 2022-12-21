using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;
using Charlotte.Commons;
using Charlotte.TopViews.TVEnemies;
using Charlotte.TopViews.TVShots;
using Charlotte.TopViews.TVShots.Tests;
using Charlotte.TopViews.TVAttacks;

namespace Charlotte.TopViews
{
	/// <summary>
	/// プレイヤーに関する情報と機能
	/// 唯一のインスタンスを Game.I.Player に保持する。
	/// </summary>
	public class TVPlayer
	{
		public double X;
		public double Y;
		public int FaceDirection; // プレイヤーが向いている方向(8方向_テンキー方式)
		public DDCrash Crash;
		public int MoveFrame;
		public int AttackFrame;
		public int DamageFrame; // 0 == 無効, 1～ == ダメージ中
		public int InvincibleFrame; // 0 == 無効, 1～ == 無敵時間中
		public int HP = 1; // -1 == 死亡, 1～ == 生存

		public TVShotCatalog.武器_e 選択武器 = TVShotCatalog.武器_e.B_NORMAL;

		/// <summary>
		/// プレイヤーの攻撃モーション
		/// -- 攻撃(Attack)と言っても攻撃以外の利用(スライディング・梯子など)も想定する。
		/// null の場合は無効
		/// null ではない場合 Attack.EachFrame() が実行される代わりに、プレイヤーの入力・被弾処理などは実行されない。
		/// </summary>
		public TVAttack Attack = null;

		/// <summary>
		/// プレイヤー描画の代替タスクリスト
		/// 空の場合は無効
		/// 空ではない場合 Draw_EL.ExecuteAllTask() が実行される代わりに Draw() の主たる処理は実行されない。
		/// --- プレイヤーの攻撃モーションから使用されることを想定する。
		/// </summary>
		public DDTaskList Draw_EL = new DDTaskList();

		public void Draw()
		{
			if (1 <= this.Draw_EL.Count)
			{
				this.Draw_EL.ExecuteAllTask();
				return;
			}

			int koma = 1;

			if (1 <= this.MoveFrame)
			{
				koma = (TopView.I.Frame / 5) % 4;

				if (koma == 3)
					koma = 1;
			}

			DDPicture picture = Ground.I.Picture2.GetPlayer(TopView.I.Status.TVChara).GetPicture(this.FaceDirection, koma);

			if (1 <= this.DamageFrame || 1 <= this.InvincibleFrame)
			{
				DDDraw.SetTaskList(DDGround.EL); // 敵より前面に描画する。
				DDDraw.SetAlpha(0.5);
			}

			DDDraw.SetMosaic();
			DDDraw.DrawBegin(
				picture,
				(int)this.X - DDGround.Camera.X,
				(int)this.Y - DDGround.Camera.Y - 12.0
				);
			DDDraw.DrawZoom(2.0);
			DDDraw.DrawEnd();
			DDDraw.Reset();
		}

		private bool Fire_Wave_左回転Sw = false;

		/// <summary>
		/// 攻撃を行う。
		/// -- Attack から呼び出されるかもしれない。
		/// </summary>
		public void Fire()
		{
			// 将来的に武器毎にコードが実装され、メソッドがでかくなると思われる。

			switch (this.選択武器)
			{
				#region テスト用

				case TVShotCatalog.武器_e.B_NORMAL:
					if (this.AttackFrame % 10 == 1)
					{
						TopView.I.Shots.Add(new TVShot_BNormal(this.X, this.Y, this.FaceDirection));
					}
					break;

				case TVShotCatalog.武器_e.B_WAVE:
					if (this.AttackFrame % 20 == 1)
					{
						TopView.I.Shots.Add(new TVShot_BWave(this.X, this.Y, this.FaceDirection, this.Fire_Wave_左回転Sw));
						this.Fire_Wave_左回転Sw = !this.Fire_Wave_左回転Sw;
					}
					break;

				case TVShotCatalog.武器_e.B_SPREAD:
					if (this.AttackFrame % 10 == 1)
					{
						for (int c = -2; c <= 2; c++)
						{
							TopView.I.Shots.Add(new TVShot_BSpread(this.X, this.Y, this.FaceDirection, 0.3 * c));
						}
					}
					break;

				case TVShotCatalog.武器_e.B_BOUNCE:
					if (this.AttackFrame % 25 == 1)
					{
						for (int c = -1; c <= 1; c++)
						{
							TopView.I.Shots.Add(new TVShot_BBounce(this.X, this.Y, TopViewCommon.Rotate(this.FaceDirection, c)));
						}
					}
					break;

				#endregion

				case TVShotCatalog.武器_e.NORMAL:
					if (this.AttackFrame % 5 == 1)
					{
						TopView.I.Shots.Add(new TVShot_Normal(this.X, this.Y, this.FaceDirection));
					}
					break;

				default:
					throw null; // never
			}
		}
	}
}
