﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;

namespace Charlotte.TopViews.TVTiles
{
	public class TVTile_森林 : TVTile_森林系
	{
		public TVTile_森林(DDPicture[,] pictbl, int 密集_l, int 密集_t, int 単独_l, int 単独_t, DDPicture groundPicture, DDPicture 単独セルPicture)
			: base(pictbl, 密集_l, 密集_t, 単独_l, 単独_t, groundPicture, 単独セルPicture)
		{ }

		protected override bool IsFriend(TVMapCell cell)
		{
			return cell.Tile is TVTile_森林 || cell.IsDefault;
		}

		public override TVTile.Kind_e GetKind()
		{
			return Kind_e.WALL;
		}
	}
}
