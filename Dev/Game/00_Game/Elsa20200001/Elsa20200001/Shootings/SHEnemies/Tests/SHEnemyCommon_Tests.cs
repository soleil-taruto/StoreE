using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;

namespace Charlotte.Shootings.SHEnemies.Tests
{
	public static class SHEnemyCommon_Tests
	{
		/// <summary>
		/// 敵の死亡時のイベントを追加する。
		/// </summary>
		/// <param name="enemy">敵</param>
		/// <param name="reaction">イベント</param>
		public static void AddKillEvent(SHEnemy enemy, Action<SHEnemy> reaction)
		{
			Shooting.I.Tasks.Add(SCommon.Supplier(E_KillMonitor(enemy, reaction)));
		}

		private static IEnumerable<bool> E_KillMonitor(SHEnemy enemy, Action<SHEnemy> reaction)
		{
			for (; ; )
			{
				if (enemy.DeadFlag) // ? 死亡した -> 待ち終了
					break;

				yield return true;
			}

			if (DDUtils.IsOutOfScreen(new D2Point(enemy.X, enemy.Y), 100.0)) // ? 画面外 -> 退場と見なし何もしない。
				yield break;

			reaction(enemy); // イベント実行
		}
	}
}
