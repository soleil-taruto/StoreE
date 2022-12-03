/*
	デッキ
*/

/@(ASTR)

/// Deck_t
{
	// 手持ちのカード・リスト
	<Actor_t[]> Cards

	// メルド・リスト
	<Meld_t[]> Melds
}

@(ASTR)/

function <Deck_t> CreateDeck()
{
	var<Reck_t> ret =
	{
		Cards: [],
		Melds: [],
	};

	return ret;
}
