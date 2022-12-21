using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;

namespace Charlotte.Shootings.SHShots
{
	public static class SHShotCommon
	{
		/// <summary>
		/// 汎用・消滅イベント
		/// </summary>
		/// <param name="shot">自弾</param>
		public static void Killed(SHShot shot)
		{
			DDGround.EL.Add(SCommon.Supplier(SHEffects.小爆発(shot.X, shot.Y)));
		}
	}
}
