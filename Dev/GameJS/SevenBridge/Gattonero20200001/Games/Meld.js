/*
	メルド
*/

/@(ASTR)

/// Meld_t
{
	// メルドしたカード・リスト
	<Actor_t[]> Cards
}

@(ASTR)/

function <Meld_t> CreateMeld(<Actor_t[]> cards)
{
	var<Meld_t> ret =
	{
		Cards: cards,
	};

	return ret;
}

function <Actor_t[]> GetMeldCards(<Meld_t> meld)
{
	return meld.Cards;
}

function <MeldType_e> GetMeldType(<Meld_t> meld)
{
	if (meld.Cards[0].Number == meld.Cards[1].Number)
	{
		return MeldType_e_PONG;
	}
	else
	{
		return MeldType_e_CHOW;
	}
}
