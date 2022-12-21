using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;

namespace Charlotte.TopViews.TVEnemies.Tests
{
	public class TVEnemy_Bセーブ地点 : TVEnemy
	{
		public TVEnemy_Bセーブ地点(double x, double y)
			: base(x, y, 0, 0, false)
		{ }

		protected override IEnumerable<bool> E_Draw()
		{
			for (; ; )
			{
				if (DDUtils.GetDistanceLessThan(new D2Point(TopView.I.Player.X, TopView.I.Player.Y), new D2Point(this.X, this.Y), 30.0))
				{
					TopViewCommon.SaveGame();
					break;
				}

				if (!DDUtils.IsOutOfCamera(new D2Point(this.X, this.Y), 50.0))
				{
					DDDraw.DrawBegin(Ground.I.Picture.Dummy, this.X - DDGround.Camera.X, this.Y - DDGround.Camera.Y);
					DDDraw.DrawRotate(DDEngine.ProcFrame / 30.0);
					DDDraw.DrawEnd();

					DDPrint.SetDebug((int)this.X - DDGround.Camera.X, (int)this.Y - DDGround.Camera.Y);
					DDPrint.SetBorder(new I3Color(0, 0, 0));
					DDPrint.PrintLine("セーブ地点");
					DDPrint.Reset();

					// 当たり判定無し
				}
				yield return true;
			}
		}
	}
}
