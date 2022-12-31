using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte
{
	/// <summary>
	/// 差分情報
	/// </summary>
	public class DifferenceData
	{
		/// <summary>
		/// カタログ情報から差分情報を生成する。
		/// </summary>
		/// <param name="rCatalog">入力側カタログ情報</param>
		/// <param name="wCatalog">出力側カタログ情報</param>
		/// <param name="inputDir">入力ディレクトリ</param>
		/// <returns>差分情報</returns>
		public static DifferenceData Create(CatalogData rCatalog, CatalogData wCatalog, string inputDir)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 差分情報を指定ディレクトリに保存する。
		/// </summary>
		/// <param name="differenceDir">指定ディレクトリ</param>
		public void SaveToDiffDir(string differenceDir)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 差分情報を指定ディレクトリから読み込む。
		/// </summary>
		/// <param name="differenceDir">指定ディレクトリ</param>
		/// <returns>差分情報</returns>
		public static DifferenceData LoadFromDiffDir(string differenceDir)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 差分を適用する。
		/// </summary>
		/// <param name="outputDir">出力ディレクトリ</param>
		public void Patching(string outputDir)
		{
			throw new NotImplementedException();
		}
	}
}
