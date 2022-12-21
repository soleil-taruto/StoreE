using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;

namespace Charlotte.TopViews.TVTiles
{
	/// <summary>
	/// 川などの水域
	/// </summary>
	public class TVTile_River : TVTile
	{
		private DDPicture Picture;

		public TVTile_River(DDPicture picture)
		{
			this.Picture = picture;
		}

		public override TVTile.Kind_e GetKind()
		{
			return Kind_e.RIVER;
		}

		public override void Draw(double draw_x, double draw_y, int map_x, int map_y)
		{
			DDDraw.DrawCenter(this.Picture, draw_x, draw_y);
		}
	}
}
