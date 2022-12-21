using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;

namespace Charlotte
{
	public class ResourceMusic
	{
		public DDMusic Muon = new DDMusic(@"dat\General\muon.wav"); // ★サンプルとしてキープ

		// 例：ループ有り
		//public DDMusic AAA = new DDMusic(@"dat\AAA.mp3").SetLoopByStLength(123456, 789123); // ★サンプルとしてキープ

		public DDMusic Title = new DDMusic(@"dat\ユーフルカ\Voyage_loop\Voyage_loop.ogg").SetLoopByStLength(655565, 4860197);

		public DDMusic XXXField_01 = new DDMusic(@"dat\ユーフルカ\The-sacred-place_loop\The-sacred-place_loop.ogg").SetLoopByStLength(800621, 4233349);

		public DDMusic 神さびた古戦場 = new DDMusic(@"dat\みるふぃ\nc200903.mp3");

		public DDMusic SHStage_01 = new DDMusic(@"dat\hmix\n138.mp3");
		public DDMusic SHStage_02 = new DDMusic(@"dat\hmix\n70.mp3");
		public DDMusic SHStage_03 = new DDMusic(@"dat\hmix\n13.mp3");

		public DDMusic SHBoss_01 = new DDMusic(@"dat\ユーフルカ\Battle-Vampire_loop\Battle-Vampire_loop.ogg").SetLoopByStLength(241468, 4205876);
		public DDMusic SHBoss_02 = new DDMusic(@"dat\ユーフルカ\Battle-Conflict_loop\Battle-Conflict_loop.ogg").SetLoopByStLength(281888, 3704134);
		public DDMusic SHBoss_03 = new DDMusic(@"dat\ユーフルカ\Battle-rapier_loop\Battle-rapier_loop.ogg").SetLoopByStLength(422312, 2767055);

		public DDMusic Field_01 = new DDMusic(@"dat\hmix\m2.mp3");
		public DDMusic Field_02 = new DDMusic(@"dat\hmix\n19.mp3");

		public ResourceMusic()
		{
			// none
		}
	}
}
