/*
	GohoubiMain
*/

function* <generatorForTask> GohoubiMain()
{
	FreezeInput();

	for (; ; )
	{
		if (GetMouseDown() == -1)
		{
			break;
		}

		ClearScreen();

		SetColor("#ff00ff");
		SetFSize(60);
		SetPrint(100, 100, 100);

		PrintLine("GohoubiMain‰¼");
		PrintLine("‰æ–Ê‚ðƒ^ƒbƒv‚µ‚Ä‰º‚³‚¢...");

		yield 1;
	}
	FreezeInput();
}
