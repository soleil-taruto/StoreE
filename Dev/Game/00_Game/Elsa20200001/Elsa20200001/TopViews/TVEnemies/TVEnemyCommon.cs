using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.TopViews.TVShots;

namespace Charlotte.TopViews.TVEnemies
{
	public static class TVEnemyCommon
	{
		/// <summary>
		/// 汎用・被弾イベント
		/// </summary>
		/// <param name="enemy">被弾した敵</param>
		/// <param name="shot">「被弾した敵」に当たった自弾</param>
		/// <param name="damagePoint">削られた体力</param>
		public static void Damaged(TVEnemy enemy, TVShot shot, int damagePoint)
		{
			Ground.I.SE.EnemyDamaged.Play();
		}

		/// <summary>
		/// 汎用・消滅イベント
		/// </summary>
		/// <param name="enemy">敵</param>
		/// <param name="destroyed">プレイヤー等(の攻撃行動)によって撃破されたか</param>
		public static void Killed(TVEnemy enemy, bool destroyed)
		{
			if (destroyed) // ? 撃破された。
			{
				DDGround.EL.Add(SCommon.Supplier(TVEffects.B中爆発(enemy.X, enemy.Y)));
				Ground.I.SE.EnemyKilled.Play();
			}
			else // ? 自滅・消滅 etc.
			{
				DDGround.EL.Add(SCommon.Supplier(TVEffects.BFireBall爆発(enemy.X, enemy.Y)));
			}
		}
	}
}
