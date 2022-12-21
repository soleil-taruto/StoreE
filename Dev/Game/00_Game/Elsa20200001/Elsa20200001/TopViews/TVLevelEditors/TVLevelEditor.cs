using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.TopViews;
using Charlotte.TopViews.TVEnemies;
using Charlotte.TopViews.TVTiles;

namespace Charlotte.TopViews.TVLevelEditors
{
	/// <summary>
	/// 編集モードに関する機能
	/// </summary>
	public static class TVLevelEditor
	{
		public enum Mode_e
		{
			TILE,
			ENEMY,
		}

		public static TVLevelEditorDlg Dlg = null;

		public static void ShowDialog()
		{
			if (Dlg != null)
				throw null; // never

			Dlg = new TVLevelEditorDlg();
			Dlg.Show();
		}

		public static void CloseDialog()
		{
			Dlg.Close();
			Dlg.Dispose();
			Dlg = null;
		}

		public static void DrawEnemy()
		{
			int cam_l = DDGround.Camera.X;
			int cam_t = DDGround.Camera.Y;
			int cam_r = cam_l + DDConsts.Screen_W;
			int cam_b = cam_t + DDConsts.Screen_H;

			I2Point lt = TopViewCommon.ToTablePoint(cam_l, cam_t);
			I2Point rb = TopViewCommon.ToTablePoint(cam_r, cam_b);

			for (int x = lt.X; x <= rb.X; x++)
			{
				for (int y = lt.Y; y <= rb.Y; y++)
				{
					TVMapCell cell = TopView.I.Map.GetCell(x, y);

					if (cell.EnemyName != TopViewConsts.ENEMY_NONE)
					{
						int tileL = x * TopViewConsts.TILE_W;
						int tileT = y * TopViewConsts.TILE_H;

						DDDraw.SetAlpha(0.3);
						DDDraw.SetBright(new I3Color(0, 128, 255));
						DDDraw.DrawRect(
							Ground.I.Picture.WhiteBox,
							tileL - cam_l,
							tileT - cam_t,
							TopViewConsts.TILE_W,
							TopViewConsts.TILE_H
							);
						DDDraw.Reset();

						DDPrint.SetBorder(new I3Color(0, 128, 255));
						DDPrint.SetDebug(tileL - cam_l, tileT - cam_t);
						DDPrint.Print(cell.EnemyName);
						DDPrint.Reset();
					}
				}
			}
		}

		public class GroupInfo
		{
			public string Name;
			public List<MemberInfo> Members = new List<MemberInfo>();

			public class MemberInfo
			{
				public string Name;
				public int Index;
			}
		}

		#region EnemyGroups

		private static List<GroupInfo> _enemyGroups = null;

		public static List<GroupInfo> EnemyGroups
		{
			get
			{
				if (_enemyGroups == null)
					_enemyGroups = CreateEnemyGroups();

				return _enemyGroups;
			}
		}

		private static List<GroupInfo> CreateEnemyGroups()
		{
			List<GroupInfo> groups = new List<GroupInfo>();

			string[] groupNames = TVEnemyCatalog.GetGroupNames();
			string[] memberNames = TVEnemyCatalog.GetMemberNames();
			int count = groupNames.Length;

			for (int index = 0; index < count; index++)
			{
				string groupName = groupNames[index];
				string memberName = memberNames[index];

				GroupInfo group;

				{
					int p = SCommon.IndexOf(groups, v => v.Name == groupName);

					if (p != -1)
					{
						group = groups[p];
					}
					else
					{
						group = new GroupInfo()
						{
							Name = groupName,
						};

						groups.Add(group);
					}
				}

				group.Members.Add(new GroupInfo.MemberInfo()
				{
					Name = memberName,
					Index = index,
				});
			}
			return groups;
		}

		#endregion

		#region TileGroups

		private static List<GroupInfo> _tileGroups = null;

		public static List<GroupInfo> TileGroups
		{
			get
			{
				if (_tileGroups == null)
					_tileGroups = CreateTileGroups();

				return _tileGroups;
			}
		}

		private static List<GroupInfo> CreateTileGroups()
		{
			List<GroupInfo> groups = new List<GroupInfo>();

			string[] groupNames = TVTileCatalog.GetGroupNames();
			string[] memberNames = TVTileCatalog.GetMemberNames();
			int count = groupNames.Length;

			for (int index = 0; index < count; index++)
			{
				string groupName = groupNames[index];
				string memberName = memberNames[index];

				GroupInfo group;

				{
					int p = SCommon.IndexOf(groups, v => v.Name == groupName);

					if (p != -1)
					{
						group = groups[p];
					}
					else
					{
						group = new GroupInfo()
						{
							Name = groupName,
						};

						groups.Add(group);
					}
				}

				group.Members.Add(new GroupInfo.MemberInfo()
				{
					Name = memberName,
					Index = index,
				});
			}
			return groups;
		}

		#endregion
	}
}
