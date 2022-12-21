using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.TopViews;

namespace Charlotte
{
	public class ResourcePicture2
	{
		public DDPicture[,] Dummy = DDDerivations.GetAnimation(Ground.I.Picture.Dummy, 0, 0, 25, 25, 2, 2); // ★サンプルとしてキープ

		// ---- 因幡てゐ ----

		private class D_Tewi
		{
			// http://zassoh.starfree.jp/

			// 基本動作

			public DDPicture[] Tewi_01 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_01, 0, 0, 80, 96).ToArray(); // ニュートラル・しゃがみ・振り向き・ジャンプ
			public DDPicture[] Tewi_02 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_02, 0, 0, 80, 96).ToArray(); // 前進・後退
			public DDPicture[] Tewi_03 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_03, 0, 0, 80, 96).ToArray(); // ダッシュ・バックステップ
			//public DDPicture[] Tewi_04 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_04, 0, 0, 80, 96).ToArray(); // ガード
			public DDPicture[] Tewi_05 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_05, 0, 0, 80, 96).ToArray(); // ダメージ
			//public DDPicture[] Tewi_06 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_06, 0, 0, 80, 96).ToArray(); // その場(足払い？)転倒・起き上がり
			//public DDPicture[] Tewi_07 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_07, 0, 0, 96, 96).ToArray(); // 空中ダメージ・落下・ダウン・起き上がり
			public DDPicture[] Tewi_13 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_13, 0, 0, 96, 96).ToArray(); // 飛翔

			// 通常攻撃風動作_1

			// none

			// 通常攻撃風動作_2

			// none

			// 通常攻撃風動作_3

			public DDPicture[] Tewi_18 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_18, 0, 0, 120, 96).ToArray(); // 攻撃パターンC・杵を使った攻撃(立ち)_ファイル_1
			//public DDPicture[] Tewi_19 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_19, 0, 0, 104, 128).ToArray(); // 攻撃パターンC・杵を使った攻撃(立ち)_ファイル_2
			public DDPicture[] Tewi_20 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_20, 0, 0, 152, 128).ToArray(); // 攻撃パターンC・杵を使った攻撃(立ち)_ファイル_3
			public DDPicture[] Tewi_21 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_21, 0, 0, 168, 128).ToArray(); // 攻撃パターンC・杵を使った攻撃(立ち)_ファイル_4
			public DDPicture[] Tewi_22 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_22, 0, 0, 152, 128).ToArray(); // 攻撃パターンC・杵を使った攻撃(しゃがみ)_ファイル_1
			public DDPicture[] Tewi_23 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_23, 0, 0, 168, 128).ToArray(); // 攻撃パターンC・杵を使った攻撃(しゃがみ)_ファイル_2
			public DDPicture[] Tewi_24 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_24, 0, 0, 128, 128).ToArray(); // 攻撃パターンC・杵を使った攻撃(ジャンプ)_ファイル_1
			public DDPicture[] Tewi_25 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_25, 0, 0, 144, 144).ToArray(); // 攻撃パターンC・杵を使った攻撃(ジャンプ)_ファイル_2
			public DDPicture[] Tewi_26 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Tewi_26, 0, 0, 144, 144).ToArray(); // 攻撃パターンC・杵を使った攻撃(ジャンプ)_ファイル_3
		}

		private static D_Tewi _tewi = null;

		private static D_Tewi Tewi
		{
			get
			{
				if (_tewi == null)
					_tewi = new D_Tewi();

				return _tewi;
			}
		}

		public DDPicture[] Tewi_立ち = Tewi.Tewi_01.Skip(0).Take(12).ToArray();
		public DDPicture[] Tewi_振り向き = Tewi.Tewi_01.Skip(13).Take(2).ToArray();
		public DDPicture[] Tewi_しゃがみ = Tewi.Tewi_01.Skip(20).Take(5).ToArray();
		public DDPicture[] Tewi_しゃがみ解除 = Tewi.Tewi_01.Skip(26).Take(4).ToArray();
		public DDPicture[] Tewi_しゃがみ振り向き = Tewi.Tewi_01.Skip(16).Take(2).ToArray();
		//public DDPicture[] Tewi_ジャンプ_開始 = Tewi.Tewi_01.Skip(30).Take(2).ToArray();
		public DDPicture[] Tewi_ジャンプ_上昇 = Tewi.Tewi_01.Skip(32).Take(2).ToArray();
		public DDPicture[] Tewi_ジャンプ_下降 = Tewi.Tewi_01.Skip(34).Take(6).ToArray();
		//public DDPicture[] Tewi_ジャンプ_着地 = Tewi.Tewi_01.Skip(40).Take(3).ToArray();
		//public DDPicture[] Tewi_後ろジャンプ = Tewi.Tewi_01.Skip(44).Take(6).ToArray();
		public DDPicture[] Tewi_歩く = Tewi.Tewi_02.Skip(0).Take(10).ToArray();
		public DDPicture[] Tewi_走る = Tewi.Tewi_03.Skip(2).Take(6).ToArray();
		public DDPicture[] Tewi_小ダメージ = Tewi.Tewi_05.Skip(0).Take(3).ToArray();
		public DDPicture[] Tewi_大ダメージ = Tewi.Tewi_05.Skip(4).Take(3).ToArray();
		public DDPicture[] Tewi_しゃがみ小ダメージ = Tewi.Tewi_05.Skip(20).Take(3).ToArray();
		public DDPicture[] Tewi_しゃがみ大ダメージ = Tewi.Tewi_05.Skip(24).Take(3).ToArray();
		public DDPicture[] Tewi_飛翔_開始 = Tewi.Tewi_13.Skip(0).Take(2).ToArray();
		public DDPicture[] Tewi_飛翔_前進 = Tewi.Tewi_13.Skip(3).Take(3).ToArray();
		public DDPicture[] Tewi_弱攻撃 = Tewi.Tewi_18.Skip(0).Take(10).ToArray();
		public DDPicture[] Tewi_中攻撃 = Tewi.Tewi_20.Skip(0).Take(11).ToArray();
		//public DDPicture[] Tewi_強攻撃_開始_01 = Tewi.Tewi_21.Skip(0).Take(4).ToArray();
		//public DDPicture[] Tewi_強攻撃_開始_02 = Tewi.Tewi_21.Skip(5).Take(6).ToArray();
		public DDPicture[] Tewi_強攻撃 = Tewi.Tewi_21.Skip(15).Take(8).ToArray();
		public DDPicture[] Tewi_しゃがみ弱攻撃 = Tewi.Tewi_22.Skip(10).Take(8).ToArray();
		public DDPicture[] Tewi_しゃがみ中攻撃 = Tewi.Tewi_22.Skip(0).Take(9).ToArray();
		public DDPicture[] Tewi_しゃがみ強攻撃 = Tewi.Tewi_23.Skip(0).Take(14).ToArray();
		public DDPicture[] Tewi_ジャンプ弱攻撃 = Tewi.Tewi_26.Skip(0).Take(8).ToArray();
		public DDPicture[] Tewi_ジャンプ中攻撃 = Tewi.Tewi_24.Skip(0).Take(11).ToArray();
		public DDPicture[] Tewi_ジャンプ強攻撃 = Tewi.Tewi_25.Skip(0).Take(15).ToArray();
		//public DDPicture[] Tewi_ジャンプ強攻撃_開始 = Tewi.Tewi_25.Skip(0).Take(6).ToArray();
		//public DDPicture[] Tewi_ジャンプ強攻撃_回転 = Tewi.Tewi_25.Skip(6).Take(2).ToArray();
		//public DDPicture[] Tewi_ジャンプ強攻撃_終了 = Tewi.Tewi_25.Skip(8).Take(7).ToArray();

		// ---- チルノ ----

		private class D_Cirno
		{
			// http://zassoh.starfree.jp/

			// 基本動作

			public DDPicture[] Cirno_01 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_01, 0, 0, 80, 96).ToArray(); // 待機・ジャンプ・しゃがみ
			//public DDPicture[] Cirno_31 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_31, 0, 0, 80, 96).ToArray(); // 待機その2
			public DDPicture[] Cirno_02 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_02, 0, 0, 80, 96).ToArray(); // 前進・後退
			public DDPicture[] Cirno_03 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_03, 0, 0, 80, 96).ToArray(); // ダッシュ・バックステップ
			//public DDPicture[] Cirno_04 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_04, 0, 0, 80, 96).ToArray(); // ガード
			public DDPicture[] Cirno_05 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_05, 0, 0, 80, 96).ToArray(); // ダメージ
			public DDPicture[] Cirno_06 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_06, 0, 0, 80, 96).ToArray(); // 落下・転倒・起き上がり

			// 通常攻撃風動作

			// none

			// コマンド技&投げ動作

			public DDPicture[] Cirno_13 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_13, 0, 0, 80, 96).ToArray(); // コマンド技パターンA(ロケット頭突き？)
			//public DDPicture[] Cirno_08 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_08, 0, 0, 128, 96).ToArray(); // 攻撃パターンB(手技)ファイル1
			//public DDPicture[] Cirno_09 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_09, 0, 0, 96, 96).ToArray(); // 攻撃パターンB(手技)ファイル2
			public DDPicture[] Cirno_10 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_10, 0, 0, 112, 96).ToArray(); // 攻撃パターンC(羽根を使った攻撃)ファイル1
			public DDPicture[] Cirno_11 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_11, 0, 0, 112, 112).ToArray(); // 攻撃パターンC(羽根を使った攻撃)ファイル2
			public DDPicture[] Cirno_12 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_12, 0, 0, 112, 112).ToArray(); // 攻撃パターンC(羽根を使った攻撃)ファイル3
			//public DDPicture[] Cirno_17 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_17, 0, 0, 80, 96).ToArray(); // 攻撃パターンD(足技)ファイル1
			//public DDPicture[] Cirno_18 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_18, 0, 0, 112, 96).ToArray(); // 攻撃パターンD(足技)ファイル2
			//public DDPicture[] Cirno_19 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_19, 0, 0, 112, 112).ToArray(); // 攻撃パターンD(足技)ファイル3
			//public DDPicture[] Cirno_20 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_20, 0, 0, 80, 96).ToArray(); // 攻撃パターンE(その他雑多)ファイル1
			//public DDPicture[] Cirno_21 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Cirno_21, 0, 0, 96, 96).ToArray(); // 攻撃パターンE(その他雑多)ファイル2
		}

		private static D_Cirno _cirno = null;

		private static D_Cirno Cirno
		{
			get
			{
				if (_cirno == null)
					_cirno = new D_Cirno();

				return _cirno;
			}
		}

		public DDPicture[] Cirno_立ち = Cirno.Cirno_01.Skip(0).Take(8).ToArray();
		//public DDPicture[] Cirno_振り向き;
		public DDPicture[] Cirno_しゃがみ = Cirno.Cirno_01.Skip(24).Take(4).ToArray();
		public DDPicture[] Cirno_しゃがみ解除 = Cirno.Cirno_01.Skip(28).Take(2).ToArray();
		//public DDPicture[] Cirno_しゃがみ振り向き;
		//public DDPicture[] Cirno_ジャンプ_開始 = Cirno.Cirno_01.Skip(8).Take(1).ToArray();
		public DDPicture[] Cirno_ジャンプ_上昇 = Cirno.Cirno_01.Skip(20).Take(3).ToArray();
		public DDPicture[] Cirno_ジャンプ_下降 = Cirno.Cirno_01.Skip(13).Take(3).ToArray();
		//public DDPicture[] Cirno_ジャンプ_着地 = Cirno.Cirno_01.Skip(16).Take(3).ToArray();
		//public DDPicture[] Cirno_後ろジャンプ = Cirno.Cirno_01.Skip(9).Take(4).ToArray();
		public DDPicture[] Cirno_歩く =
			Cirno.Cirno_02.Skip(0).Take(7).Concat(
			Cirno.Cirno_02.Skip(9).Take(6)).ToArray();
		public DDPicture[] Cirno_走る = Cirno.Cirno_03.Skip(0).Take(6).ToArray();
		public DDPicture[] Cirno_ダメージ = Cirno.Cirno_05.Skip(0).Take(3).ToArray();
		//public DDPicture[] Cirno_小ダメージ;
		//public DDPicture[] Cirno_大ダメージ;
		public DDPicture[] Cirno_しゃがみダメージ = Cirno.Cirno_05.Skip(16).Take(3).ToArray();
		//public DDPicture[] Cirno_しゃがみ小ダメージ;
		//public DDPicture[] Cirno_しゃがみ大ダメージ;
		public DDPicture[] Cirno_飛翔 = Cirno.Cirno_13.Skip(0).Take(7).ToArray();
		public DDPicture[] Cirno_攻撃 = Cirno.Cirno_10.Skip(12).Take(11).ToArray();
		//public DDPicture[] Cirno_弱攻撃;
		//public DDPicture[] Cirno_中攻撃;
		//public DDPicture[] Cirno_強攻撃;
		public DDPicture[] Cirno_しゃがみ攻撃 = Cirno.Cirno_11.Skip(0).Take(11).ToArray();
		//public DDPicture[] Cirno_しゃがみ弱攻撃;
		//public DDPicture[] Cirno_しゃがみ中攻撃;
		//public DDPicture[] Cirno_しゃがみ強攻撃;
		public DDPicture[] Cirno_ジャンプ攻撃 = Cirno.Cirno_12.Skip(0).Take(7).ToArray();
		//public DDPicture[] Cirno_ジャンプ弱攻撃;
		//public DDPicture[] Cirno_ジャンプ中攻撃;
		//public DDPicture[] Cirno_ジャンプ強攻撃;

		// ----

		#region Players

		public const int Player_e_Length = 50; // Player_e の項目数と一致すること

		public static string[] Player_e_Names = new string[] // 並び方は Player_e と一致すること
		{
			"Alice",
			"高麗野あうん",
			"赤蛮奇_体",
			"Cirno",
			"戎珱花",
			"易者",
			"依神女苑",
			"今泉影狼",
			"今泉影狼_狼",
			"埴安神袿姫",
			"秦こころ",
			"秦こころ_面01",
			"秦こころ_面02",
			"秦こころ_面03",
			"秦こころ_面04",
			"秦こころ_面05",
			"秦こころ_面06",
			"秦こころ_面07",
			"秦こころ_面08",
			"秦こころ_面09",
			"秦こころ_面10",
			"庭渡久侘歌",
			"ラルバ",
			"丁礼田舞",
			"杖刀偶磨弓",
			"矢田寺成美",
			"矢田寺成美_地蔵",
			"矢田寺成美_NoHat",
			"坂田ネムノ",
			"摩多羅隠岐奈",
			"摩多羅隠岐奈_Chair",
			"面01",
			"面02",
			"面03",
			"面04",
			"面05",
			"面06",
			"面07",
			"面08",
			"面09",
			"面10",
			"驪駒早鬼",
			"爾子田里乃",
			"赤蛮奇_頭",
			"赤蛮奇",
			"依神紫苑_覚",
			"依神紫苑",
			"牛崎潤美",
			"わかさぎ姫",
			"吉弔八千慧",
		};

		public enum Player_e
		{
			Alice,
			高麗野あうん,
			赤蛮奇_体,
			Cirno,
			戎珱花,
			易者,
			依神女苑,
			今泉影狼,
			今泉影狼_狼,
			埴安神袿姫,
			秦こころ,
			秦こころ_面01,
			秦こころ_面02,
			秦こころ_面03,
			秦こころ_面04,
			秦こころ_面05,
			秦こころ_面06,
			秦こころ_面07,
			秦こころ_面08,
			秦こころ_面09,
			秦こころ_面10,
			庭渡久侘歌,
			ラルバ,
			丁礼田舞,
			杖刀偶磨弓,
			矢田寺成美,
			矢田寺成美_地蔵,
			矢田寺成美_NoHat,
			坂田ネムノ,
			摩多羅隠岐奈,
			摩多羅隠岐奈_Chair,
			面01,
			面02,
			面03,
			面04,
			面05,
			面06,
			面07,
			面08,
			面09,
			面10,
			驪駒早鬼,
			爾子田里乃,
			赤蛮奇_頭,
			赤蛮奇,
			依神紫苑_覚,
			依神紫苑,
			牛崎潤美,
			わかさぎ姫,
			吉弔八千慧,
		}

		private PlayerInfo[] Players = new PlayerInfo[] // 並び方は Player_e と一致すること
		{
			new PlayerInfo(Ground.I.Picture.Player_Alice),
			new PlayerInfo(Ground.I.Picture.Player_高麗野あうん),
			new PlayerInfo(Ground.I.Picture.Player_赤蛮奇_体),
			new PlayerInfo(Ground.I.Picture.Player_Cirno),
			new PlayerInfo(Ground.I.Picture.Player_戎珱花),
			new PlayerInfo(Ground.I.Picture.Player_易者),
			new PlayerInfo(Ground.I.Picture.Player_依神女苑),
			new PlayerInfo(Ground.I.Picture.Player_今泉影狼),
			new PlayerInfo(Ground.I.Picture.Player_今泉影狼_狼),
			new PlayerInfo(Ground.I.Picture.Player_埴安神袿姫),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ_面01),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ_面02),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ_面03),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ_面04),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ_面05),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ_面06),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ_面07),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ_面08),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ_面09),
			new PlayerInfo(Ground.I.Picture.Player_秦こころ_面10),
			new PlayerInfo(Ground.I.Picture.Player_庭渡久侘歌),
			new PlayerInfo(Ground.I.Picture.Player_ラルバ),
			new PlayerInfo(Ground.I.Picture.Player_丁礼田舞),
			new PlayerInfo(Ground.I.Picture.Player_杖刀偶磨弓),
			new PlayerInfo(Ground.I.Picture.Player_矢田寺成美),
			new PlayerInfo(Ground.I.Picture.Player_矢田寺成美_地蔵),
			new PlayerInfo(Ground.I.Picture.Player_矢田寺成美_NoHat),
			new PlayerInfo(Ground.I.Picture.Player_坂田ネムノ),
			new PlayerInfo(Ground.I.Picture.Player_摩多羅隠岐奈),
			new PlayerInfo(Ground.I.Picture.Player_摩多羅隠岐奈_Chair),
			new PlayerInfo(Ground.I.Picture.Player_面01),
			new PlayerInfo(Ground.I.Picture.Player_面02),
			new PlayerInfo(Ground.I.Picture.Player_面03),
			new PlayerInfo(Ground.I.Picture.Player_面04),
			new PlayerInfo(Ground.I.Picture.Player_面05),
			new PlayerInfo(Ground.I.Picture.Player_面06),
			new PlayerInfo(Ground.I.Picture.Player_面07),
			new PlayerInfo(Ground.I.Picture.Player_面08),
			new PlayerInfo(Ground.I.Picture.Player_面09),
			new PlayerInfo(Ground.I.Picture.Player_面10),
			new PlayerInfo(Ground.I.Picture.Player_驪駒早鬼),
			new PlayerInfo(Ground.I.Picture.Player_爾子田里乃),
			new PlayerInfo(Ground.I.Picture.Player_赤蛮奇_頭),
			new PlayerInfo(Ground.I.Picture.Player_赤蛮奇),
			new PlayerInfo(Ground.I.Picture.Player_依神紫苑_覚),
			new PlayerInfo(Ground.I.Picture.Player_依神紫苑),
			new PlayerInfo(Ground.I.Picture.Player_牛崎潤美),
			new PlayerInfo(Ground.I.Picture.Player_わかさぎ姫),
			new PlayerInfo(Ground.I.Picture.Player_吉弔八千慧),
		};

		public class PlayerInfo
		{
			private DDPicture Picture;
			private DDPicture[,] PictureTable;

			public PlayerInfo(DDPicture picture)
			{
				this.Picture = picture;
				this.PictureTable = DDDerivations.GetAnimation(picture, 0, 0, 24, 32);
			}

			public DDPicture GetPicture(int faceDirection, int koma)
			{
				int l;
				int t;

				switch (faceDirection)
				{
					case 2: l = 0; t = 0; break; // 下
					case 4: l = 0; t = 1; break; // 左
					case 6: l = 0; t = 2; break; // 右
					case 8: l = 0; t = 3; break; // 上

					case 1: l = 3; t = 0; break; // 左下
					case 3: l = 3; t = 1; break; // 右下
					case 7: l = 3; t = 2; break; // 左上
					case 9: l = 3; t = 3; break; // 右上

					default:
						throw null; // never
				}
				return this.PictureTable[l + koma, t];
			}
		}

		public PlayerInfo GetPlayer(Player_e index)
		{
			return this.Players[(int)index];
		}

		#endregion

		public DDPicture[,] Tile_A1 = DDDerivations.GetAnimation(Ground.I.Picture.Tile_A1, 0, 0, TopViewConsts.TILE_W, TopViewConsts.TILE_H);
		public DDPicture[,] Tile_A2 = DDDerivations.GetAnimation(Ground.I.Picture.Tile_A2, 0, 0, TopViewConsts.TILE_W, TopViewConsts.TILE_H);
		public DDPicture[,] Tile_A3 = DDDerivations.GetAnimation(Ground.I.Picture.Tile_A3, 0, 0, TopViewConsts.TILE_W, TopViewConsts.TILE_H);
		public DDPicture[,] Tile_A4 = DDDerivations.GetAnimation(Ground.I.Picture.Tile_A4, 0, 0, TopViewConsts.TILE_W, TopViewConsts.TILE_H);
		public DDPicture[,] Tile_A5 = DDDerivations.GetAnimation(Ground.I.Picture.Tile_A5, 0, 0, TopViewConsts.TILE_W, TopViewConsts.TILE_H);
		public DDPicture[,] Tile_B = DDDerivations.GetAnimation(Ground.I.Picture.Tile_B, 0, 0, TopViewConsts.TILE_W, TopViewConsts.TILE_H);
		public DDPicture[,] Tile_C = DDDerivations.GetAnimation(Ground.I.Picture.Tile_C, 0, 0, TopViewConsts.TILE_W, TopViewConsts.TILE_H);
		public DDPicture[,] Tile_D = DDDerivations.GetAnimation(Ground.I.Picture.Tile_D, 0, 0, TopViewConsts.TILE_W, TopViewConsts.TILE_H);
		public DDPicture[,] Tile_E = DDDerivations.GetAnimation(Ground.I.Picture.Tile_E, 0, 0, TopViewConsts.TILE_W, TopViewConsts.TILE_H);

		public DDPicture[,] MiniTile_A1 = DDDerivations.GetAnimation(Ground.I.Picture.Tile_A1, 0, 0, TopViewConsts.MINI_TILE_W, TopViewConsts.MINI_TILE_H);
		public DDPicture[,] MiniTile_A2 = DDDerivations.GetAnimation(Ground.I.Picture.Tile_A2, 0, 0, TopViewConsts.MINI_TILE_W, TopViewConsts.MINI_TILE_H);
		public DDPicture[,] MiniTile_A3 = DDDerivations.GetAnimation(Ground.I.Picture.Tile_A3, 0, 0, TopViewConsts.MINI_TILE_W, TopViewConsts.MINI_TILE_H);
		public DDPicture[,] MiniTile_A4 = DDDerivations.GetAnimation(Ground.I.Picture.Tile_A4, 0, 0, TopViewConsts.MINI_TILE_W, TopViewConsts.MINI_TILE_H);
		public DDPicture[,] MiniTile_A5 = DDDerivations.GetAnimation(Ground.I.Picture.Tile_A5, 0, 0, TopViewConsts.MINI_TILE_W, TopViewConsts.MINI_TILE_H);
		public DDPicture[,] MiniTile_B = DDDerivations.GetAnimation(Ground.I.Picture.Tile_B, 0, 0, TopViewConsts.MINI_TILE_W, TopViewConsts.MINI_TILE_H);
		public DDPicture[,] MiniTile_C = DDDerivations.GetAnimation(Ground.I.Picture.Tile_C, 0, 0, TopViewConsts.MINI_TILE_W, TopViewConsts.MINI_TILE_H);
		public DDPicture[,] MiniTile_D = DDDerivations.GetAnimation(Ground.I.Picture.Tile_D, 0, 0, TopViewConsts.MINI_TILE_W, TopViewConsts.MINI_TILE_H);
		public DDPicture[,] MiniTile_E = DDDerivations.GetAnimation(Ground.I.Picture.Tile_E, 0, 0, TopViewConsts.MINI_TILE_W, TopViewConsts.MINI_TILE_H);

		public DDPicture[] Enemy_神奈子 = DDDerivations.GetAnimation_YX(Ground.I.Picture.Enemy_神奈子, 0, 0, 250, 250).ToArray();

		public ResourcePicture2()
		{
			// none
		}
	}
}
