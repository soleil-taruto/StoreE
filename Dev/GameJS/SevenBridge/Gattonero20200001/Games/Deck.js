/*
	�f�b�L
*/

/@(ASTR)

/// Deck_t
{
	// �莝���̃J�[�h�E���X�g
	<Actor_t[]> Cards

	// �����h�E���X�g
	<Meld_t[]> Melds

	// �莝���̃J�[�h�̕`��ʒu(������W)
	<double> CardsDraw_L
	<double> CardsDraw_T

	// �����h�����J�[�h�̕`��ʒu(������W)
	<double> MeldsDraw_L
	<double> MeldsDraw_T
}

@(ASTR)/

/*
	cardsDrawTop: �莝���̃J�[�h�̕`��ʒu(��ӂ�Y-���W)
	meldsDrawTop: �����h�����J�[�h�̕`��ʒu(��ӂ�Y-���W)
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
