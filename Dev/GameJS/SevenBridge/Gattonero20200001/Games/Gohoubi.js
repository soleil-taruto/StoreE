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

		PrintLine("GohoubiMain仮");
		PrintLine("画面をタップして下さい...");

		yield 1;
	}
	FreezeInput();
}
