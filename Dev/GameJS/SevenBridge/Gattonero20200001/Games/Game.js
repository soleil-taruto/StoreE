/*
	ゲーム・メイン
*/

// カメラ位置(整数)
var<D2Point_t> Camera = CreateD2Point(0.0, 0.0);

// ゲーム用タスク
var<TaskManager_t> GameTasks = CreateTaskManager();

var<int> @@_Credit = 1000;
var<int> @@_Bet = 0;

function <void> AddGameCredit(<int> value)
{
	@@_Credit += value;
}

function* <generatorForTask> GameMain()
{
	FreezeInput();
	ClearAllActor();
	ClearAllTask(GameTasks);

	for (; ; )
	{
		@@_Bet = 0;
		@@_BattleNow = false;

		yield* @@_BetMain();

		@@_BattleNow = true;

		for (; ; )
		{
			yield* @@_BattleMain();

			if (@@_DealerDamage < 0)
			{
				break;
			}
			else if (@@_DEALER_DAMAGE_MAX <= @@_DealerDamage)
			{
				yield* @@_GohoubiMain();

				break;
			}
		}
	}
	FreezeInput();
	ClearAllActor();
	ClearAllTask(GameTasks);
}

var<boolean> @@_BattleNow = false;

function* <generatorForTask> @@_E_DrawBackground()
{
	var<double> zoom = 2020.0 / 1080.0; // 表示サイズ / 画像の高さ＆幅
	var<double> rot = 0.0;
	var<double> rotAdd = 0.0;
	var<D4Color_t> maskColor = CreateD4Color(0.0, 0.0, 0.0, 1.0);

	for (; ; )
	{
		if (@@_BattleNow)
		{
			rotAdd = Approach(rotAdd, 0.0003, 0.991);
			maskColor.A = Approach(maskColor.A, 0.7, 0.95);
		}
		else
		{
			rotAdd = Approach(rotAdd, 0.0, 0.993);
			maskColor.A = Approach(maskColor.A, 0.9, 0.95);
		}
		rot += rotAdd;

		Draw(P_Background, Screen_W / 2.0, Screen_H / 2.0, 1.0, rot, zoom);

		SetColor(I4ColorToString(D4ColorToI4Color(maskColor)));
		PrintRect(0, 0, Screen_W, Screen_H);

		yield 1;
	}
}

var<generatorForTask> @@_Task_DrawBackground = null

function <void> @@_DrawBackground()
{
	if (@@_Task_DrawBackground == null)
	{
		@@_Task_DrawBackground = @@_E_DrawBackground();
	}
	NextRun(@@_Task_DrawBackground);
}

function* <generatorForTask> @@_BetMain()
{
	FreezeInput();

	for (; ; )
	{
		if (GetMouseDown() == -1)
		{
			var<int> INC_SPAN = 10;

			if (HoveredPicture == P_ButtonBetUp)
			{
				var<int> inc = Math.min(INC_SPAN, @@_Credit);

				@@_Credit -= INC_SPAN;
				@@_Bet += INC_SPAN;
			}
			if (HoveredPicture == P_ButtonBetDown)
			{
				var<int> inc = Math.min(INC_SPAN, @@_Bet);

				@@_Credit += inc;
				@@_Bet -= inc;
			}
			if (HoveredPicture == P_ButtonStart)
			{
				if (1 <= @@_Bet)
				{
					break;
				}
			}
		}

		// 描画ここから

		@@_DrawBackground();

		SetColor("#ffffff");
		SetFSize(120);
		SetPrint(100, 500, 300);
		PrintLine("CREDIT: " + @@_Credit);
		PrintLine("BET: " + @@_Bet);

		Draw(P_ButtonBetUp, 200, 1500, 1.0, 0.0, 1.0);
		Draw(P_ButtonBetDown, 600, 1500, 1.0, 0.0, 1.0);
		Draw(P_ButtonStart, 1000, 1500, 1.0, 0.0, 1.0);

		ExecuteAllActor();
		ExecuteAllTask(GameTasks);
		yield 1;
	}
	FreezeInput();
}

var<int> @@_DEALER_DAMAGE_MAX = 7;

/*
	ディーラーのダメージ
	初期値：0
	値域：-1 ～ @@_DEALER_DAMAGE_MAX
*/
var<int> @@_DealerDamage = 0;

var<Deck_t> DealerDeck;
var<Deck_t> PlayerDeck;

var<Actor_t[]> RCards; // 取り出す方のカードの山
var<Actor_t[]> WCards; // 捨てる方のカードの山

var<double> RCards_X = Screen_W - 150;
var<double> RCards_Y = 790;

var<double> WCards_X = Screen_W - 150;
var<double> WCards_Y = 1210;

function* <generatorForTask> @@_BattleMain()
{
	DealerDeck = CreateDeck( 170,  650);
	PlayerDeck = CreateDeck(1430, 1000);

	RCards = [];
	WCards = [];

	for (var<Suit_e> suit = 1; suit <= 4; suit++)
	for (var<int> number = 1; number <= 13; number++)
	{
		RCards.push(CreateActor_Trump(RCards_X, RCards_Y, suit, number, true));
	}
	Shuffle(RCards);

WCards.push(RCards.pop()); // test test test test test

	for (var<int> c = 0; c < 7; c++)
	{
		GetDeckCards(DealerDeck).push(RCards.pop());
		GetDeckCards(PlayerDeck).push(RCards.pop());

		AddDelay(GameTasks, c * 3, () => SetTrumpReversed(GetDeckCards(PlayerDeck)[c], false));

		AddActor(GetDeckCards(DealerDeck)[c]);
		AddActor(GetDeckCards(PlayerDeck)[c]);
	}

	SetDeckCardsAutoPos(DealerDeck, false);
	SetDeckCardsAutoPos(PlayerDeck, false);

	FreezeInput();

	for (var<Scene_t> scene of CreateScene(50))
	{
		/*
		if (GetMouseDown() == -1)
		{
			break;
		}
		*/

		@@_DrawBackground();
		@@_DrawBattleWall();

		ExecuteAllActor();
		ExecuteAllTask(GameTasks);
		yield 1;
	}



	SortDeck(DealerDeck);
	SortDeck(PlayerDeck);
	SetDeckCardsAutoPos(PlayerDeck, true);
	AddDelay(GameTasks, 30, () => SetDeckCardsAutoPos(DealerDeck, true));

	FreezeInput();

	// test test test test test
	for (; ; )
	{
		if (GetMouseDown() == -1)
		{
			break;
		}

		@@_DrawBackground();
		@@_DrawBattleWall();

		ExecuteAllActor();
		ExecuteAllTask(GameTasks);
		yield 1;
	}



	FreezeInput();

	DealerDeck = null;
	PlayerDeck = null;

	RCards = null;
	WCards = null;

	for (var<Actor_t> actor of GetAllActor())
	{
		if (actor.Kind == ActorKind_Trump)
		{
			KillActor(actor); // test
		}
	}
}

function <void> @@_DrawBattleWall()
{
	SetColor("#00000080");
	PrintRect_LTRB(10, 10, Screen_W - 10, 160);

	SetColor("#ffffff");
	SetFSize(50);
	SetPrint(30, 70, 70);
	PrintLine("CREDIT: " + 10);
	PrintLine("HP: " + "■□□□□□□");

	var<int> remSec = ToFix(GetAddGameCreditRemFrame() / 60.0) + 1;

	var<string> mm = ZPad(ToFix(remSec / 60), 2, "0");
	var<string> ss = ZPad(      remSec % 60,  2, "0");

	SetPrint(700, 70, 70);
	PrintLine("CREDIT 付与まで");
	PrintLine(mm + " : " + ss);

	SetColor("#00ffff60");
	PrintRect_XYWH(RCards_X, RCards_Y, GetPicture_W(P_TrumpFrame) + 20, GetPicture_H(P_TrumpFrame) + 20);

	SetColor("#ff800060");
	PrintRect_XYWH(WCards_X, WCards_Y, GetPicture_W(P_TrumpFrame) + 20, GetPicture_H(P_TrumpFrame) + 20);

	if (1 <= RCards.length)
	{
		Draw(P_TrumpFrame, RCards_X, RCards_Y, 1.0, 0.0, 1.0);
		Draw(P_TrumpBack,  RCards_X, RCards_Y, 1.0, 0.0, 1.0);
	}
	if (1 <= WCards.length)
	{
		var<Actor_t> card = WCards[WCards.length - 1];
		var<Picture_t> surface = P_Trump[card.Suit][card.Number];

		Draw(P_TrumpFrame, WCards_X, WCards_Y, 1.0, 0.0, 1.0);
		Draw(surface,      WCards_X, WCards_Y, 1.0, 0.0, 1.0);
	}
}
