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

		SetColor("#ffffff");
		SetFSize(60);
		SetPrint(100, 100, 0);

		PrintLine("GohoubiMain‰¼_‰æ–Ê‚ðƒ^ƒbƒv‚µ‚Ä‰º‚³‚¢...");
	}
	FreezeInput();
}
