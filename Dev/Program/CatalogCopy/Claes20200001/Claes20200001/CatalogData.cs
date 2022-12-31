using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte
{
	/// <summary>
	/// カタログ情報
	/// </summary>
	public class CatalogData
	{
		/// <summary>
		/// 指定ディレクトリのカタログ情報を生成する。
		/// </summary>
		/// <param name="rootDir">指定ディレクトリ</param>
		/// <returns>カタログ情報</returns>
		public static CatalogData CreateByDir(string rootDir)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 指定ファイルにカタログ情報を書き出す。
		/// </summary>
		/// <param name="catalogFile">出力先カタログ情報ファイル</param>
		public void SaveToFile(string catalogFile)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 指定ファイルからカタログ情報を読み込む。
		/// </summary>
		/// <param name="catalogFile">入力元カタログ情報ファイル</param>
		/// <returns>カタログ情報</returns>
		public static CatalogData LoadFromFile(string catalogFile)
		{
			throw new NotImplementedException();
		}
	}
}
