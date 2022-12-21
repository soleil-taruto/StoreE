using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.TopViews.TVEnemies
{
	/// <summary>
	/// このマップから開始する場合のプレイヤーの初期位置
	/// </summary>
	public class TVEnemy_スタート地点 : TVEnemy
	{
		/// <summary>
		/// { 2, 4, 5, 6, 8, 101 } == { 下, 左, 中央(デフォルト), 右, 上, ロード }
		/// その他の場合、他のマップからの階段の上り下り・ワープ等を想定
		/// </summary>
		public int Direction;

		public TVEnemy_スタート地点(double x, double y, int direction)
			: base(x, y, 0, 0, false)
		{
			this.Direction = direction;
		}

		protected override IEnumerable<bool> E_Draw()
		{
			for (; ; )
			{
				// noop

				yield return true;
			}
		}
	}
}
