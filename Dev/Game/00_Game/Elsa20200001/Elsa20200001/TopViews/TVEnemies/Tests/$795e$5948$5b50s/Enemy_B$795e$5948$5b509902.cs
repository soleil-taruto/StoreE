using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.TopViews.TVTiles;
using Charlotte.TopViews.TVTiles.Tests;

namespace Charlotte.TopViews.TVEnemies.Tests.神奈子s
{
	public class Enemy_B神奈子9902 : TVEnemy
	{
		public Enemy_B神奈子9902()
			: base(0, 0, 0, 0, false)
		{ }

		protected override IEnumerable<bool> E_Draw()
		{
			return this.E_開放();
		}

		private IEnumerable<bool> E_開放()
		{
			// ---- game_制御 ----

			DDMusicUtils.Fadeout();

			// ----

			TopView.I.UserInputDisabled = true;

			for (int x = 0; x < TopView.I.Map.W; x++)
			{
				this.開放(x, 0);
				this.開放(x, TopView.I.Map.H - 1);

				yield return true;
			}
			for (int y = 0; y < TopView.I.Map.H; y++)
			{
				this.開放(0, y);
				this.開放(TopView.I.Map.W - 1, 0);

				yield return true;
			}
			TopView.I.UserInputDisabled = false;
		}

		private void 開放(int x, int y)
		{
			TVMapCell cell = TopView.I.Map.GetCell(x, y);

			if (cell.Tile is TVTile_Bボス部屋Shutter)
				cell.Tile = TVTileCatalog.Create("芝"); // restore

			DDGround.EL.Add(SCommon.Supplier(TVEffects.B閉鎖と開放(x * TopViewConsts.TILE_W + TopViewConsts.TILE_W / 2, y * TopViewConsts.TILE_H + TopViewConsts.TILE_H / 2)));
		}
	}
}
