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

		PrintLine("GohoubiMain仮_画面をタップして下さい...");
	}
	FreezeInput();
}
