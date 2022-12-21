using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;
using Charlotte.TopViews.TVTiles;

namespace Charlotte.TopViews
{
	/// <summary>
	/// マップセル
	/// </summary>
	public class TVMapCell
	{
		public string TileName; // セーブ・ロード用
		public TVTile Tile;
		public string EnemyName;

		// <---- prm

		/// <summary>
		/// このマップセルは「デフォルトのマップセル」か
		/// </summary>
		public bool IsDefault
		{
			get
			{
				return this == TopViewCommon.DefaultMapCell;
			}
		}
	}
}
