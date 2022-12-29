/*
	ゲーム・メイン
*/

// カメラ位置(整数)
var<D2Point_t> Camera = CreateD2Point(0.0, 0.0);

// ゲーム用タスク
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

	error(); // この関数は終了してはならない。
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
