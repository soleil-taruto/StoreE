/*
	共通
*/

function <D2Point_t> ToFieldPoint_XY(<int> x, <int> y)
{
	return ToFieldPoint(CreateI2Point(x, y));
}

function <I2Point_t> ToTablePoint_XY(<double> x, <double> y)
{
	return ToTablePoint(CreateD2Point(x, y));
}

/*
	テーブル位置(テーブル・インデックス)からフィールド上の座標(ドット単位)を取得する。
	戻り値は、タイルの中心座標である。
*/
function <D2Point_t> ToFieldPoint(<I2Point_t> pt)
{
	var<double> dx = FIELD_L + pt.X * TILE_W + TIEL_W / 2.0;
	var<double> dy = FIELD_T + pt.Y * TILE_H + TIEL_H / 2.0;

	var ret = CreateD2Point(dx, dy);

	return ret;
}

/*
	フィールド上の座標(ドット単位)からテーブル位置(テーブル・インデックス)を取得する。
*/
function <I2Point_t> ToTablePoint(<D2Point_t> pt)
{
	var<int> ix = ToFloor((pt.X - FIELD_L) / TILE_W);
	var<int> iy = ToFloor((pt.Y - FIELD_T) / TILE_H);

	var ret = CreateI2Point(ix, iy);

	return ret;
}

function <double> ToTileCenterX(<double> x)
{
	return ToTileCenter(CreateD2Point(x, 0.0)).X;
}

function <double> ToTileCenterY(<double> y)
{
	return ToTileCenter(CreateD2Point(0.0, y)).Y;
}

/*
	フィールド上の座標(ドット単位)からタイルの中心座標を取得する。
*/
function <D2Point_t> ToTileCenter(<D2Point_t> pt)
{
	var<int> ix = ToFloor((pt.X - FIELD_L) / TILE_W);
	var<int> iy = ToFloor((pt.Y - FIELD_T) / TILE_H);

	var<double> dx = FIELD_L + ix * TILE_W + TILE_W / 2.0;
	var<double> dy = FIELD_T + iy * TILE_H + TILE_H / 2.0;

	var ret = CreateD2Point(dx, dy);

	return ret;
}
