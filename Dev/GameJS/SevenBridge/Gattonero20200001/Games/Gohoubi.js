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

		PrintLine("�N���A���");
		PrintLine("(����łɂ�������)");
		PrintLine("��ʂ��^�b�v���ĉ�����...");

		yield 1;
	}
	FreezeInput();
}
