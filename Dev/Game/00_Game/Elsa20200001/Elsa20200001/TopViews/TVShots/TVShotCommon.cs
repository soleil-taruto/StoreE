using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;

namespace Charlotte.TopViews.TVShots
{
	public static class TVShotCommon
	{
		/// <summary>
		/// 汎用・消滅イベント
		/// </summary>
		/// <param name="shot">消滅する自弾</param>
		public static void Killed(TVShot shot)
		{
			DDGround.EL.Add(SCommon.Supplier(TVEffects.B小爆発(shot.X, shot.Y)));
		}
	}
}
