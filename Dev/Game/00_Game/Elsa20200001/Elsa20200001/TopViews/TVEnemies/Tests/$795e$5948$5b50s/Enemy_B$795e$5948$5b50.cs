using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.Games;
using Charlotte.TopViews.TVTiles;
using Charlotte.TopViews.TVTiles.Tests;

namespace Charlotte.TopViews.TVEnemies.Tests.神奈子s
{
	/// <summary>
	/// 神奈子
	/// 登場
	/// </summary>
	public class Enemy_B神奈子 : TVEnemy
	{
		public Enemy_B神奈子(double x, double y)
			: base(x, y, 0, 0, false)
		{ }

		protected override IEnumerable<bool> E_Draw()
		{
			// ---- game_制御 ----

			if (TopView.I.Status.InventoryFlags[GameStatus.Inventory_e.B神奈子を倒した])
				yield break;

			// ----

			Func<bool> f_閉鎖 = SCommon.Supplier(this.E_閉鎖());

			double targ_x = this.X;
			double targ_y = this.Y;

			this.X = TopView.I.Map.W / 2.0;
			this.Y = -100.0;

			foreach (DDScene scene in DDSceneUtils.Create(150))
			{
				f_閉鎖();

				DDUtils.Approach(ref this.X, targ_x, 0.9);
				DDUtils.Approach(ref this.Y, targ_y, 0.9);

				bool facingLeft = TopView.I.Player.X < this.X;

				DDDraw.DrawBegin(Ground.I.Picture2.Enemy_神奈子[0], this.X, this.Y);
				DDDraw.DrawSlide(20.0, 10.0);
				DDDraw.DrawZoom_X(facingLeft ? 1 : -1);
				DDDraw.DrawEnd();

				// 当たり判定無し

				yield return true;
			}
			TopView.I.Enemies.Add(new Enemy_B神奈子0001(this.X, this.Y));
		}

		private IEnumerable<bool> E_閉鎖()
		{
			TopView.I.UserInputDisabled = true;

			for (int c = 0; c < 30; c++)
				yield return true;

			for (int x = 0; x < TopView.I.Map.W; x++)
			{
				this.閉鎖(x, 0);
				this.閉鎖(x, TopView.I.Map.H - 1);

				yield return true;
			}
			for (int y = 0; y < TopView.I.Map.H; y++)
			{
				this.閉鎖(0, y);
				this.閉鎖(TopView.I.Map.W - 1, 0);

				yield return true;
			}
			TopView.I.UserInputDisabled = false;
		}

		private void 閉鎖(int x, int y)
		{
			TVMapCell cell = TopView.I.Map.GetCell(x, y);

			if (cell.Tile is TVTile_Space) // ? 芝
				cell.Tile = new TVTile_Bボス部屋Shutter();

			DDGround.EL.Add(SCommon.Supplier(TVEffects.B閉鎖と開放(x * TopViewConsts.TILE_W + TopViewConsts.TILE_W / 2, y * TopViewConsts.TILE_H + TopViewConsts.TILE_H / 2)));
		}
	}
}
