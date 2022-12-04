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

	// 手持ちのカードの描画位置(左上座標)
	<double> CardsDraw_L
	<double> CardsDraw_T

	// メルドしたカードの描画位置(左上座標)
	<double> MeldsDraw_L
	<double> MeldsDraw_T
}

@(ASTR)/

/*
	cardsDrawTop: 手持ちのカードの描画位置(上辺のY-座標)
	meldsDrawTop: メルドしたカードの描画位置(上辺のY-座標)
*/
function <Deck_t> CreateDeck(<double> cardsDrawTop, <double> meldsDrawTop)
{
	var<Deck_t> ret =
	{
		Cards: [],
		Melds: [],

		CardsDraw_L: 0,
		CardsDraw_T: cardsDrawTop,

		MeldsDraw_L: 0,
		MeldsDraw_T: meldsDrawTop,
	};

	return ret;
}

function <Actor_t[]> GetDeckCards(<Deck_t> deck)
{
	return deck.Cards;
}

function <Meld_t[]> GetDeckMelds(<Deck_t> deck)
{
	return deck.Melds;
}

function <void> SetDeckCardsAutoPos(<Deck_t> deck)
{
	{
		var<double> l = deck.CardsDraw_L + GetPicture_W(P_TrumpFrame) / 2 + 10;
		var<double> t = deck.CardsDraw_T + GetPicture_H(P_TrumpFrame) / 2;
		var<double> w = Screen_W - GetPicture_W(P_TrumpFrame) - 20;

		for (var<int> c = 0; c < deck.Cards.length; c++)
		{
			var<Actor_t> card = deck.Cards[c];

			var<double> x = l + (c / (deck.Cards.length - 1)) * w;
			var<double> y = t;

			SetTrumpPos(card, x, y);
		}
	}

	// TODO: Meld
}
