using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;
using Charlotte.Games;

namespace Charlotte.TopViews.TVEnemies.Tests.神奈子s
{
	/// <summary>
	/// 神奈子
	/// 死亡
	/// </summary>
	public class Enemy_B神奈子9901 : TVEnemy
	{
		public Enemy_B神奈子9901(double x, double y)
			: base(x, y, 0, 0, false)
		{ }

		protected override IEnumerable<bool> E_Draw()
		{
			// ---- game_制御 ----

			TopView.I.Status.InventoryFlags[GameStatus.Inventory_e.B神奈子を倒した] = true;

			// ----

			double targ_x = (TopView.I.Map.W * TopViewConsts.TILE_W) / 2;
			double targ_y = (TopView.I.Map.H * TopViewConsts.TILE_H) / 2;

			foreach (DDScene scene in DDSceneUtils.Create(120))
			{
				double xBuru = DDUtils.Random.GetReal1() * 30.0;
				double yBuru = DDUtils.Random.GetReal1() * 30.0;

				DDUtils.Approach(ref this.X, targ_x, 0.99);
				DDUtils.Approach(ref this.Y, targ_y, 0.99);

				bool facingLeft = scene.Numer / 20 % 2 == 0;
				//bool facingLeft = Game.I.Player.X < this.X;

				DDDraw.DrawBegin(Ground.I.Picture2.Enemy_神奈子[10], this.X + xBuru, this.Y + yBuru);
				DDDraw.DrawZoom_X(facingLeft ? 1 : -1);
				DDDraw.DrawEnd();

				// 当たり判定無し

				yield return true;
			}

			this.Kill(true);
			TopView.I.Enemies.Add(new Enemy_B神奈子9902());
		}
	}
}
