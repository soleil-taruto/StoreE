using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.TopViews.TVTiles;

namespace Charlotte.TopViews.TVShots
{
	public class TVShot_Normal : TVShot
	{
		private int Direction; // この自弾の進行方向(8方向_テンキー方式)

		public TVShot_Normal(double x, double y, int direction)
			: base(x, y, 3, false)
		{
			this.Direction = direction;
		}

		protected override IEnumerable<bool> E_Draw()
		{
			D2Point speed = TopViewCommon.GetXYSpeed(this.Direction, 20.0);

			for (int frame = 0; ; frame++)
			{
				this.X += speed.X;
				this.Y += speed.Y;

				if (DDUtils.IsOutOfCamera(new D2Point(this.X, this.Y))) // カメラの外に出たら(画面から見えなくなったら)消滅する。
					break;

				if (TopView.I.Map.GetCell(TopViewCommon.ToTablePoint(this.X, this.Y)).Tile.GetKind() == TVTile.Kind_e.WALL) // 壁に当たったら自滅する。
				{
					this.Kill();
					break;
				}

				DDDraw.SetBright(0.0, 1.0, 0.5);
				DDDraw.DrawBegin(Ground.I.Picture.WhiteCircle, this.X - DDGround.Camera.X, this.Y - DDGround.Camera.Y);
				DDDraw.DrawSetSize(20.0, 20.0);
				DDDraw.DrawEnd();
				DDDraw.Reset();

				this.Crash = DDCrashUtils.Circle(new D2Point(this.X, this.Y), 10.0);

				yield return true;
			}
		}
	}
}
