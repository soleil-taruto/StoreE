using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;

namespace Charlotte.TopViews.TVEnemies.Tests
{
	public class TVEnemy_Bハック0001 : TVEnemy
	{
		public TVEnemy_Bハック0001(double x, double y)
			: base(x, y, 0, 0, false)
		{ }

		protected override IEnumerable<bool> E_Draw()
		{
			for (; ; )
			{
				if (DDUtils.GetDistanceLessThan(new D2Point(TopView.I.Player.X, TopView.I.Player.Y), new D2Point(this.X, this.Y), 30.0))
				{
					foreach (var relay in this.E_ハック実行())
						yield return relay;

					break;
				}

				if (!DDUtils.IsOutOfCamera(new D2Point(this.X, this.Y), 50.0))
				{
					DDDraw.DrawBegin(Ground.I.Picture.Dummy, this.X - DDGround.Camera.X, this.Y - DDGround.Camera.Y);
					DDDraw.DrawRotate(DDEngine.ProcFrame / 100.0);
					DDDraw.DrawEnd();

					DDPrint.SetDebug((int)this.X - DDGround.Camera.X, (int)this.Y - DDGround.Camera.Y);
					DDPrint.SetBorder(new I3Color(0, 0, 0));
					DDPrint.PrintLine("ハック0001");
					DDPrint.Reset();

					// 当たり判定無し
				}
				yield return true;
			}
		}

		private IEnumerable<bool> E_ハック実行()
		{
			TopView.I.UserInputDisabled = true;

			for (int c = 0; c < 30; c++)
				yield return true;

			TopView.I.PlayerHacker.Fast = true;
			TopView.I.PlayerHacker.DIR_2 = true;

			for (int c = 0; c < 50; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_6 = true;

			for (int c = 0; c < 30; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_2 = false;

			for (int c = 0; c < 65; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_8 = true;

			for (int c = 0; c < 25; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_6 = false;

			for (int c = 0; c < 45; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_8 = false;
			TopView.I.PlayerHacker.Fast = false;
			TopView.I.PlayerHacker.DIR_4 = true;

			for (int c = 0; c < 110; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_4 = false;
			TopView.I.PlayerHacker.DIR_8 = true;

			for (int c = 0; c < 110; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_8 = false;
			TopView.I.PlayerHacker.DIR_6 = true;

			for (int c = 0; c < 50; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_6 = false;
			TopView.I.PlayerHacker.DIR_2 = true;

			for (int c = 0; c < 60; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_2 = false;
			TopView.I.PlayerHacker.DIR_6 = true;

			for (int c = 0; c < 55; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_6 = false;
			TopView.I.PlayerHacker.Fast = true;
			TopView.I.PlayerHacker.DIR_8 = true;

			for (int c = 0; c < 25; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_6 = true;

			for (int c = 0; c < 30; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_6 = false;

			for (int c = 0; c < 80; c++)
				yield return true;

			TopView.I.PlayerHacker.DIR_8 = false;
			TopView.I.PlayerHacker.Fast = false;

			for (int c = 0; c < 30; c++)
				yield return true;

			TopView.I.UserInputDisabled = false;
		}
	}
}
