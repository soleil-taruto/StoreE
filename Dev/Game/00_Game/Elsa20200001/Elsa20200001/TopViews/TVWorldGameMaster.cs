using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Games;

namespace Charlotte.TopViews
{
	public class TVWorldGameMaster : IDisposable
	{
		public TVWorld World;
		public GameStatus Status;

		// <---- prm

		public static TVWorldGameMaster I;

		public TVWorldGameMaster()
		{
			I = this;
		}

		public void Dispose()
		{
			I = null;
		}

		public void Perform()
		{
			for (; ; )
			{
				using (new TopView())
				{
					TopView.I.World = this.World;
					TopView.I.Status = this.Status;
					TopView.I.Perform();

					switch (this.Status.TVExitDirection)
					{
						case 901:
						case 5:
							return;

						case 4:
							this.World.Move(-1, 0);
							this.Status.TVStartPointDirection = 6;
							break;

						case 6:
							this.World.Move(1, 0);
							this.Status.TVStartPointDirection = 4;
							break;

						case 8:
							this.World.Move(0, -1);
							this.Status.TVStartPointDirection = 2;
							break;

						case 2:
							this.World.Move(0, 1);
							this.Status.TVStartPointDirection = 8;
							break;

						default:
							throw null; // never
					}
				}
			}
		}
	}
}
