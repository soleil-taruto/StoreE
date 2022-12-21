using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;

namespace Charlotte.Shootings.SHWalls.Tests
{
	public class SHWall_Test0004 : SHWall
	{
		public override IEnumerable<bool> E_Draw()
		{
			double a = 0.0;

			for (int frame = 0; ; frame++)
			{
				DDDraw.SetAlpha(a);

				{
					int slide = (int)((frame * 3L) % 108L);

					for (int dx = -slide; dx < DDConsts.Screen_W; dx += 108)
					{
						for (int dy = 0; dy < DDConsts.Screen_H; dy += 108)
						{
							DDDraw.DrawSimple(Ground.I.Picture.SHWall0002, dx, dy);
						}
					}
				}

				{
					int slide = (int)((frame * 13L) % 90L);

					for (int dx = -slide; dx < DDConsts.Screen_W; dx += 90)
					{
						for (int dy = 0; dy < DDConsts.Screen_H; dy += 90)
						{
							DDDraw.DrawSimple(Ground.I.Picture.SHWall0003, dx, dy);
						}
					}
				}

				DDDraw.Reset();
				DDUtils.Approach(ref a, 1.0, 0.997);
				this.FilledFlag = 1.0 - SCommon.MICRO < a;
				yield return true;
			}
		}
	}
}
