/*
	�Q�[���E���C��
*/

// �J�����ʒu(����)
var<D2Point_t> Camera = CreateD2Point(0.0, 0.0);

// �Q�[���p�^�X�N
var<TaskManager_t> GameTasks = CreateTaskManager();

var<int> @@_Credit = 1000;

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
		@@_BetMain();
		@@_RoateMain();
		@@_ResultMain();

		yield 1;
	}

	error(); // ���̊֐��͏I�����Ă͂Ȃ�Ȃ��B
}

function <void> @@_DrawWall()
{
}

function <void> @@_DrawFront()
{
}

function* <generatorForTask> @@_BetMain()
{
}

function* <generatorForTask> @@_BetMain()
{
}

function* <generatorForTask> @@_BetMain()
{
}
