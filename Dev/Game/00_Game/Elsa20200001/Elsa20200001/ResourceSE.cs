using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;

namespace Charlotte
{
	public class ResourceSE
	{
		//public DDSE Muon = new DDSE(@"dat\General\muon.wav"); // ★サンプルとしてキープ

		public DDSE[] テスト用s = new DDSE[]
		{
			new DDSE(@"dat\小森平\coin01.mp3"),
			new DDSE(@"dat\小森平\coin02.mp3"),
			new DDSE(@"dat\小森平\coin04.mp3"),
		};

		public DDSE PlayerDamaged = new DDSE(@"dat\小森平\damage5.mp3");
		public DDSE PlayerJump = new DDSE(@"dat\小森平\coin01.mp3"); // 仮

		public DDSE EnemyDamaged = new DDSE(@"dat\小森平\hit04.mp3");
		public DDSE EnemyKilled = new DDSE(@"dat\小森平\explosion06.mp3");

		public DDSE SHEnemyDamaged = new DDSE(@"dat\出処不明\EnemyDamaged.mp3");
		public DDSE SHPlayerShoot = new DDSE(@"dat\出処不明\PlayerShoot.mp3");
		public DDSE SHEnemyDead = new DDSE(@"dat\小森平\explosion01.mp3");
		public DDSE SHPowerUp = new DDSE(@"dat\小森平\powerup03.mp3");

		public ResourceSE()
		{
			// none
		}
	}
}
