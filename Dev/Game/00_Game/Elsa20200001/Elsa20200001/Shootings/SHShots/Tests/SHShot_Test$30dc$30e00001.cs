using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.Shootings.SHEnemies;

namespace Charlotte.Shootings.SHShots.Tests
{
	public class SHShot_Testボム0001 : SHShot
	{
		public SHShot_Testボム0001()
			: base(0.0, 0.0, SCommon.IMAX / 2, true, SHShot.Kind_e.ボム)
		{ }

		protected override IEnumerable<bool> E_Draw()
		{
			foreach (DDScene scene in DDSceneUtils.Create(90))
			{
				無敵の通常敵を全消し();

				DDGround.EL.Add(() =>
				{
					DDCurtain.DrawCurtain(0.5 * (1.0 - scene.Rate));
					return false;
				});

				this.Crash = DDCrashUtils.Rect(new D4Rect(0, 0, DDConsts.Screen_W, DDConsts.Screen_H));

				yield return true;
			}
		}

		private static void 無敵の通常敵を全消し()
		{
			foreach (SHEnemy enemy in Shooting.I.Enemies.Iterate())
			{
				if (
					enemy.Kind == SHEnemy.Kind_e.通常敵 &&
					enemy.HP == 0 // ? 無敵
					)
					enemy.DeadFlag = true;
			}
		}

		protected override void P_Killed()
		{
			// noop
		}
	}
}
