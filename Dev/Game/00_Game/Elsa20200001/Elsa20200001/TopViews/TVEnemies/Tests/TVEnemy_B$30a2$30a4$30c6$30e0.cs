using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.TopViews.TVShots;

namespace Charlotte.TopViews.TVEnemies.Tests
{
	public class TVEnemy_Bアイテム : TVEnemy
	{
		public enum 効用_e
		{
			WEAPON_BOUNCE,
			WEAPON_SPREAD,
			WEAPON_WAVE,
		}

		public static string[] 効用_e_Names = new string[]
		{
			"WEAPON_BOUNCE",
			"WEAPON_SPREAD",
			"WEAPON_WAVE",
		};

		private 効用_e 効用;

		public TVEnemy_Bアイテム(double x, double y, 効用_e 効用)
			: base(x, y, 0, 0, false)
		{
			this.効用 = 効用;
		}

		protected override IEnumerable<bool> E_Draw()
		{
			for (; ; )
			{
				if (DDUtils.GetDistanceLessThan(new D2Point(TopView.I.Player.X, TopView.I.Player.Y), new D2Point(this.X, this.Y), 30.0))
				{
					this.プレイヤーがアイテムを取得した();
					break;
				}

				if (!DDUtils.IsOutOfCamera(new D2Point(this.X, this.Y), 50.0))
				{
					DDDraw.DrawBegin(Ground.I.Picture.Dummy, this.X - DDGround.Camera.X, this.Y - DDGround.Camera.Y);
					DDDraw.DrawRotate(DDEngine.ProcFrame / 10.0);
					DDDraw.DrawEnd();

					DDPrint.SetDebug((int)this.X - DDGround.Camera.X, (int)this.Y - DDGround.Camera.Y);
					DDPrint.SetBorder(new I3Color(0, 0, 0));
					DDPrint.PrintLine("アイテム");
					DDPrint.PrintLine("効用：" + 効用_e_Names[(int)this.効用]);
					DDPrint.Reset();

					// 当たり判定無し
				}
				yield return true;
			}
		}

		private void プレイヤーがアイテムを取得した()
		{
			switch (this.効用)
			{
				case 効用_e.WEAPON_BOUNCE:
					TopView.I.Player.選択武器 = TVShotCatalog.武器_e.B_BOUNCE;
					break;

				case 効用_e.WEAPON_SPREAD:
					TopView.I.Player.選択武器 = TVShotCatalog.武器_e.B_SPREAD;
					break;

				case 効用_e.WEAPON_WAVE:
					TopView.I.Player.選択武器 = TVShotCatalog.武器_e.B_WAVE;
					break;

				default:
					throw null; // never
			}
		}
	}
}
