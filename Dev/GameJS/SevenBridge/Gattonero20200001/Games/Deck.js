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
