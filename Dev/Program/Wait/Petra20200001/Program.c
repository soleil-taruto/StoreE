#include <stdio.h>
#include <conio.h>
#include <windows.h>

#define error() \
	{ printf("ERROR %d\n", __LINE__); exit(2); }

#define errorCase(status) \
	{ if ((status)) error(); }

#define GetMin(a, b) ((a) < (b) ? (a) : (b))
#define GetMax(a, b) ((a) < (b) ? (b) : (a))

#define WAIT_SEC_MAX 999999

main()
{
	int waitSec;
	int millis;
	int lastPrintRemSec = -1;

	errorCase(__argc != 2);
	waitSec = atoi(__argv[1]);
	errorCase(waitSec < 0 || WAIT_SEC_MAX < waitSec);
	millis = waitSec * 1000;

	for (; ; )
	{
		if (lastPrintRemSec != millis / 1000)
		{
			lastPrintRemSec = millis / 1000;
			printf("\r%d �b�҂��Ă��܂��B���~����ɂ� ESC ���s����ɂ� ENTER �������ĉ����� ... ", lastPrintRemSec);
		}

		while (_kbhit())
		{
			int key = _getch();

			if (key == 0x1b) // ? ESC
			{
				printf("\n���~���܂��B\n");
				exit(1);
			}
			if (key == 0x0d) // ? ENTER
			{
				printf("\n���s���܂��B\n");
				exit(0);
			}

			if (key == '+') // �v���X 1 ��
			{
				millis += 60000;
			}
			else if (key == '-') // �}�C�i�X 1 ��
			{
				millis -= 60000;
			}
			else if (key == '*') // �v���X 1 ����
			{
				millis += 3600000;
			}
			else if (key == '/') // �c�莞�ԃN���A
			{
				millis = 0;
			}

			millis = GetMin(millis, WAIT_SEC_MAX * 1000);
			millis = GetMax(millis, 3000);
		}

		if (millis <= 0)
		{
			printf("\n�^�C���A�E�g���܂����B\n");
			exit(0);
		}

		Sleep(250);
		millis -= 250;
	}
}
