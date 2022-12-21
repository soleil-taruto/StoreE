using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.Shootings.SHShots;

namespace Charlotte.Shootings.SHEnemies
{
	public static class SHEnemyCommon
	{
		/// <summary>
		/// 汎用・被弾イベント
		/// </summary>
		/// <param name="enemy">敵</param>
		/// <param name="shot">被弾した自弾</param>
		/// <param name="damagePoint">削られた体力</param>
		public static void Damaged(SHEnemy enemy, SHShot shot, int damagePoint)
		{
			Ground.I.SE.SHEnemyDamaged.Play();
		}

		/// <summary>
		/// 汎用・消滅イベント
		/// </summary>
		/// <param name="enemy">敵</param>
		/// <param name="destroyed">プレイヤー等(の攻撃行動)によって撃破されたか</param>
		public static void Killed(SHEnemy enemy, bool destroyed)
		{
			DDGround.EL.Add(SCommon.Supplier(SHEffects.中爆発(enemy.X, enemy.Y)));
			Ground.I.SE.SHEnemyDead.Play();
		}
	}
}
