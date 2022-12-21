using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;

namespace Charlotte.TopViews.TVAttacks.Tests
{
	public class TVAttack_B0001 : TVAttack
	{
		protected override IEnumerable<bool> E_Draw()
		{
			for (; ; )
			{
				if (
					DDInput.A.GetInput() == 1 ||
					DDInput.B.GetInput() == 1
					)
					break;

				TVAttackCommon.ProcPlayer_移動();
				TVAttackCommon.ProcPlayer_壁キャラ処理();
				TVAttackCommon.ProcPlayer_Status();

				double plA = 1.0;

				if (1 <= TopView.I.Player.InvincibleFrame)
				{
					plA = 0.5;
				}
				else
				{
					TVAttackCommon.ProcPlayer_当たり判定();
				}

				DDGround.EL.Add(() =>
				{
					DDPrint.SetDebug(
						(int)TopView.I.Player.X - DDGround.Camera.X - 80,
						(int)TopView.I.Player.Y - DDGround.Camera.Y - 60
						);
					DDPrint.SetBorder(new I3Color(0, 0, 192));
					DDPrint.Print("Attack_B0001 テスト");
					DDPrint.Reset();

					return false;
				});

				DDPicture picture = Ground.I.Picture2.GetPlayer(TopView.I.Status.TVChara).GetPicture(TopView.I.Player.FaceDirection, 0);

				DDDraw.SetTaskList(TopView.I.Player.Draw_EL);
				DDDraw.SetMosaic();
				DDDraw.SetAlpha(plA);
				DDDraw.DrawBegin(
					picture,
					TopView.I.Player.X - DDGround.Camera.X,
					TopView.I.Player.Y - DDGround.Camera.Y - 12.0
					);
				DDDraw.DrawZoom(2.0);
				DDDraw.DrawEnd();
				DDDraw.Reset();

				yield return true;
			}
		}
	}
}
