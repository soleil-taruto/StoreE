/*
	ゲーム・ヘルパー
*/

/*
	「チー」可能であるか判定する。

	ret: できない場合 null
		できる場合、対応するデッキのカードのインデックス配列を返す。長さ=2
*/
function <int[]> GetChowIndexes(<Deck_t> deck, <Actor_t> lastWastedCard)
{
	return null; // TODO
}

/*
	「ポン」可能であるか判定する。

	ret:
		できない場合 null
		できる場合、対応するデッキのカードのインデックス配列を返す。長さ=2
*/
function <int[]> GetPongIndexes(<Deck_t> deck, <Actor_t> lastWastedCard)
{
	return null; // TODO
}

/*
	「ロン」可能であるか判定する。

	ret: ロン可能であるか
*/
function <boolean> IsCanRon(<Deck_t> deck, <Actor_t> lastWastedCard)
{
	return false; // TODO
}



// - - -
// - - -
// - - -

/*
	ツモ上がり可能であるか判定する。

	ret: ツモ上がり可能であるか
*/
function <boolean> IsCanAgari(<Deck_t> deck)
{
	return false; // TODO
}

/*
	「カン」可能であるか判定する。

	ret:
		できない場合 null
		できる場合、対応するデッキのカードのインデックス配列を返す。長さ=4
*/
function <int[]> GetKongIndexes(<Deck_t> deck)
{
	return null; // TODO
}
