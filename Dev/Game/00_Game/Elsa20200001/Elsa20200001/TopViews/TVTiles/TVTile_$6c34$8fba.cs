using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;

namespace Charlotte.TopViews.TVTiles
{
	public class TVTile_水辺 : TVTile_水辺系
	{
		public TVTile_水辺(DDPicture[,] pictbl, int pictbl_l, int pictbl_t, int animeKomaNum, int animeKomaSpan)
			: base(pictbl, pictbl_l, pictbl_t, animeKomaNum, animeKomaSpan)
		{ }

		protected override bool IsFriend(TVMapCell cell)
		{
			return cell.Tile.GetKind() == Kind_e.RIVER || cell.IsDefault;
		}

		public override TVTile.Kind_e GetKind()
		{
			return Kind_e.RIVER;
		}
	}
}
