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

var<Trump_t[]> RCards; // 取り出す方のカードの山
var<Trump_t[]> WCards; // 捨てる方のカードの山

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

//WCards.push(RCards.pop()); // test

	for (var<int> c = 0; c < 7; c++)
	{
		GetDeckCards(DealerDeck).push(RCards.pop());
		GetDeckCards(PlayerDeck).push(RCards.pop());

		AddDelay(GameTasks, c * 3, () => SetTrumpReversed(GetDeckCards(PlayerDeck)[c], false));

		AddActor(GetDeckCards(DealerDeck)[c]);
		AddActor(GetDeckCards(PlayerDeck)[c]);
	}

	SetDeckCardsAutoPos(DealerDeck, false, true);
	SetDeckCardsAutoPos(PlayerDeck, false, true);

//	FreezeInput();

	for (var<Scene_t> scene of CreateScene(50))
	{
		@@_DrawBackground();
		@@_DrawBattleWall();

		ExecuteAllActor();
		ExecuteAllTask(GameTasks);
		yield 1;
	}

	SortDeck(DealerDeck);
	SortDeck(PlayerDeck);
	SetDeckCardsAutoPos(PlayerDeck, true, false);
	AddDelay(GameTasks, 30, () => SetDeckCardsAutoPos(DealerDeck, true, false));

	var<int[]> idxsChow  = WCards.length == 0 ? null  : GetChowIndexes( PlayerDeck, WCards[WCards.length - 1]);
	var<int[]> idxsPong  = WCards.length == 0 ? null  : GetPongIndexes( PlayerDeck, WCards[WCards.length - 1]);
	var<boolean> ronFlag = WCards.length == 0 ? false : IsCanRon(       PlayerDeck, WCards[WCards.length - 1]);

	{
		var<string> items = [];

		var<string> ITEM_CHOW = "チー";
		var<string> ITEM_PONG = "ポン";
		var<string> ITEM_RON  = "ロン";
		var<string> ITEM_NOOP = "しない";

		if (idxsChow != null)
		{
			items.push(ITEM_CHOW);
		}
		if (idxsPong != null)
		{
			items.push(ITEM_PONG);
		}
		if (ronFlag)
		{
			items.push(ITEM_RON);
		}

		if (1 <= items.length)
		{
			items.push(ITEM_NOOP);

			var<string> selItem;
			yield* @@_Menu(items, item => selItem = item);



			// TODO
			// TODO
			// TODO



		}
		else
		{
			yield* @@_WaitToTouch();
		}
	}

	{
		var<Trump_t> card = RCards.pop();

		PlayerDeck.Cards.push(card);
		AddActor(card);

		SetTrumpReversed(card, false);
		SetTrumpAutoStRot(card);
		SetDeckCardsAutoPos(PlayerDeck, true, false);
	}

	var<int[]> idxsKong    = GetKongIndexes( PlayerDeck);
	var<boolean> agariFlag = IsCanAgari(     PlayerDeck);

	{
		var<string> items = [];

		var<string> ITEM_KONG  = "カン";
		var<string> ITEM_AGARI = "ツモ";
		var<string> ITEM_NOOP  = "しない";

		if (idxsKong != null)
		{
			items.push(ITEM_KONG);
		}
		if (agariFlag)
		{
			items.push(ITEM_AGARI);
		}

		if (1 <= items.length)
		{
			items.push(ITEM_NOOP);

			var<string> selItem;
			yield* @@_Menu(items, item => selItem = item);



			// TODO
			// TODO
			// TODO



		}
	}

	for (; ; ) // test
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
			KillActor(actor);
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
		var<Trump_t> card = WCards[WCards.length - 1];
		var<Picture_t> surface = P_Trump[card.Suit][card.Number];

		Draw(P_TrumpFrame, WCards_X, WCards_Y, 1.0, 0.0, 1.0);
		Draw(surface,      WCards_X, WCards_Y, 1.0, 0.0, 1.0);
	}
}

function* <generatorForTask> @@_WaitToTouch()
{
	FreezeInput();

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
}

var<boolean> @@_MenuBackOn = false;

function* <generatorForTask> @@_E_MenuBack()
{
	var<string> BACK_COLOR = "#000040c0";
	var<double> w = 0.0;

	while (@@_MenuBackOn)
	{
		w = Approach(w, 900, 0.87);

		SetColor(BACK_COLOR);
		PrintRect_LTRB(0.0, 0.0, w, Screen_H);

		yield 1;
	}
	while (1.0 < w)
	{
		w = Approach(w, 0.0, 0.93);

		SetColor(BACK_COLOR);
		PrintRect_LTRB(0.0, 0.0, w, Screen_H);

		yield 1;
	}
}

function* <generatorForTask> @@_Menu(<string[]> items, <Action string> setReturn)
{
	var<double> ITEMS_L = 100;
	var<double> ITEMS_T = 300;
	var<double> ITEMS_Y_STEP = 350;
	var<double> ITEM_W = 700;
	var<double> ITEM_H = 200;

	FreezeInput();

	@@_MenuBackOn = true;
	AddTask(GameTasks, @@_E_MenuBack());

	var<int> selIndex = -1;

mainLoop:
	for (; ; )
	{
		if (GetMouseDown() == -1)
		{
			for (var<int> i = 0; i < items.length; i++)
			{
				if (!IsOut(
					CreateD2Point(GetMouseX(), GetMouseY()),
					CreateD4Rect(ITEMS_L, ITEMS_T + i * ITEMS_Y_STEP - ITEM_H, ITEM_W, ITEM_H),
					0.0
					))
				{
					selIndex = i;
					break mainLoop;
				}
			}
		}

		@@_DrawBackground();
		@@_DrawBattleWall();

		ExecuteAllActor();
		ExecuteAllTask(GameTasks);

		SetPrint(ITEMS_L, ITEMS_T, ITEMS_Y_STEP);
		SetFSize(200);
		SetColor("#ffffff");

		for (var<int> i = 0; i < items.length; i++)
		{
			PrintLine(items[i]);
		}

		yield 1;
	}
	FreezeInput();

	@@_MenuBackOn = false;

	setReturn(items[selIndex]);
}
