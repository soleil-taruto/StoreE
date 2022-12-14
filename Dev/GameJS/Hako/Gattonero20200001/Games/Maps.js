/*
	マップデータ
*/

/*
	サンプル

"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　始　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　終　■",
"■　　　　　　　　　　　　　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",

*/

var<string[][]> MAPS =
[
	// テスト用
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　始　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　終　■",
"■　　　　　　　　　　　　　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 01
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　■■　■　■　■■■■■■■■　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　始　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　■■■　　■",
"■　　　　　　　　　　　　　■■■　　■",
"■　　　　　　　　　　■■■■■■　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　■■■■　　　　　　　　　　■",
"■■■■■■■■■　　　■■　　　　　■",
"■■■■■■■■■　　　■■　　　終　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 02
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　B2　　　　　　　　　　　■",
"■　　終　　　　B2　　　　　　　　　　■",
"■　　　　　　　　B2　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■■■■■■■■■■■■　　　　B6　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　■■　　　　■",
"■　　　　　　　　　　　　■■　　　　■",
"■　　　　　　■■　　　　　　　　　　■",
"■　　　　　　■■　　　　B4　　■■■■",
"■　始　　■■■■　　　　B4　　　　　■",
"■　　　　■■■■　　　　　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 03
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　■　　　　　　■　　■",
"■　　　　　　　　■　　　　　　■　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　■■　　　　■■　　　　■■",
"■■　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　■　　　　　　　　R4　■　　■",
"■　　　　■　　　　　　　　　　■　　■",
"■■　　　■　　　　　　　　　　■　　■",
"■　　　　■　　　　　■■■■■■　　■",
"■　　■■■■■■■■■■■■■■　　■",
"■　　　　■　　　　　　　　　　　　　■",
"■　　　始■終　　　　　　　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 04
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　■　　　　　　　　　　　　　■",
"■始　　　■　　■　　　　　　　　　終■",
"■■■■　■　　■　　　　　　　■■■■",
"■　　　　■　　■　　　　　　　　　　■",
"■　　　　　　　G9　■　■■　　　　　■",
"■　　　　　　　　　　　　C1　　　　　■",
"■　　■■■　　　　　　　■■　　　　■",
"■　　　　　　　　　　　　　■　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　G9　　　　　　　　　　C4■　■",
"■　■　　■　　　　　　　　　　■　　■",
"■　　■　■　　　　　　　　　　■　　■",
"■　　　　■　　　■■■■　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 05
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　始　■",
"■　　　　　　　　　　　R4　R4　　■　■",
"■　　　　　　　　　　　　　　　　　　■",
"■■■■　　　　　■　　　　　　　■　■",
"■　　■　　　　　■　　　　　　　　　■",
"■　　■　■■■■■　■■■■■■■■■",
"■　　■　■　　　■　■　　　　　　　■",
"■　　■　■　　　■■■　　　B2　終　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　G9　　　■■■■■　　　　　　■",
"■　R6　　　　　　　　　　　　■■■　■",
"■　　　　　　　　　　　　　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 06
	[
"■■■■■■■■■■■■■■■■■■■■",
"■■■■■■■■　　　　　　　　　　　■",
"■■■■■■■■G6　　　　　　　　始　■",
"■■■■■■■■　　　　■■■■■■■■",
"■■■■■■■■G9　　　■■■■■■■■",
"■■■■■■■■　　　　■■■■■■■■",
"■■■■■■■■G8　　　■■■■■■■■",
"■■■■■■■■　　　　■■■■■■■■",
"■■■■■■■■G7　　　■■■■■■■■",
"■■■■■■■■　　　　■■■■■■■■",
"■■■■■■■■G4　　　■■■■■■■■",
"■■■■■■■■　　　　■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　終　　　　　　　　　　　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 07
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　■■B2■　■　■■■■■■■■B2　■",
"■　　　　　　　　　　　　　　　　　B2■",
"■　終　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　■■■　　■",
"■　　　　　　　　　　　　　■■■　　■",
"■　　　　　　　　　　G3■■■■■　　■",
"■　　　　　　　　　B7　　　　　　　　■",
"■　　　　　　　　B7　　　　　　　　　■",
"■　　　　■■■C3　　　　　　　　　　■",
"■■■■■■■■■　　　■■　　　　　■",
"■■■■■■■■■　　　■■　　　始　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 08
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　始　　　　　　　　　　　　　　　　■",
"■■■■　　■■　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　R6　　　　　　　　　　R4　　　■",
"■　　　　　　R6　　　　R4　　　　　　■",
"■　　　　　　　　R4R6　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　終　■",
"■　　　　　　　　　　　　　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 09
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　始　　　■■■　　　　　　　　終　■",
"■　　　　　　　　　　　B4■　　　　　■",
"■　　　　■■■　B8　　　■　　　　　■",
"■　　　　　　　　　　　B4■■　　　■■",
"■　　　■■■　　　　　■　　　　　　■",
"■　　　　　　　　　■　■　　　　　　■",
"■　R6　　　　　■　■　G9■■　　　　■",
"■　　　　　　　■　G8　　　　　　　　■",
"■　　　　　　　G7　　B2　　　　　　　■",
"■　　　　　　■　　　　　　　　■■■■",
"■　　　　　　■　　■　　　　　　R4　■",
"■　　　　　　　　　　　　　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 10
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　終　■",
"■　　　　　　　　　　　　　　　　　　■",
"■　　　　　　　　G7　G8　G9　　　　　■",
"■　　　　　　　　　　　　　　■■　　■",
"■　　　　　　　　G4　■　G6　　　　　■",
"■　　　■■　　　　　　　　　　　　　■",
"■　　　　　　　　G1　G2　G3　　　　　■",
"■　　■　　　　　　　　　　　　　　　■",
"■　　G4■■　　　　　　　　　　　　　■",
"■　■■G6　　　　　　　　　　　　　　■",
"■　　　■　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　始　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 11
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　B4　　　■　　　■",
"■　　　　　　　　　　B4　　　■　始　■",
"■　　　　　　　　　　B4　　　■　　　■",
"■　　　　　　　　　　　　■■■■　■■",
"■　　　　　　　　　　　　　　■　　　■",
"■　　　C8■　■C8　　■　　　　　　　■",
"■　　　■　　　■　　　　　　■　　　■",
"■　　　■　　　■　　　　■■■■■■■",
"■　　　■　　　■　　　　　　■　　　■",
"■　C8■■■　■■■C8　　　　　　　　■",
"■　　　■　　　■　　　　　　　　R4　■",
"■　　　■　終　■　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 12
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　■　　　　　　　　　　　　　　■",
"■　始　■　B3　　■■　　■　R6　　　■",
"■　■　■　　　　　　　■■　　　　　■",
"■　　　■　　　　　　　■■　　　　　■",
"■　　　■■■　　B7　　　■　　　　　■",
"■　　　B6　■　　　　　■■　C2　C2　■",
"■　　B6　　■　　　　■　　　　　　　■",
"■　B6　　　■■■　　　■■　　　　　■",
"■B6　　　　■　　　　　■　　　　　　■",
"■　　　■■■　　　■■　　　　　　　■",
"■　　　■　　　　　■　　　　　　　　■",
"■　　　■　B9　■■　　　　　G4　G4　■",
"■　　　　　　　■終　　　　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 13
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　B4　　　　　　　　　　　　　　　■",
"■　　B4　　　　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　　B6　　■",
"■　　■■G3■G2■G1■G4■■■■■■　■",
"■　　　　　　　　　　　　　　　　■　■",
"■■　　　　　　　　　　　　　始　■　■",
"■　　　　　　　　　　　　　　　　■　■",
"■　　■■C9■C8■C7■C4■■■■■■　■",
"■　　■　　　　　　　　　　　終　　　■",
"■　　■　　　　　　　　　　　　　　　■",
"■　　■　　■　　R6　　■　　　　　　■",
"■　　■　　■　　　　　■　　　　　　■",
"■　　　　　■　　　　　■　　　　　　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 14
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　B2　　　　　■",
"■　　　　　　　　始　　　　　　　　　■",
"■　　C7　　　　　　　　　　　■　　　■",
"■　　　■■　　　　　　　■■　■　　■",
"■　　　　　■　　　　　■　　　　G7　■",
"■　　　　R4■　　　　　■　　　　　　■",
"■　　　　　　■　　　■　　　　　　　■",
"■　　　　　■■■■■　　■R6　　　　■",
"■　　　　　　■　　　■　　　　　　　■",
"■■■■■　■■　終　■　■■■■■■■",
"■　　　　　　　　　　　　　　　　B4　■",
"■　　　　B8　　　　　　B8　　　　B4　■",
"■　　　　　　　　　　　　　　　　B4　■",
"■■■■■■■■■■■■■■■■■■■■",
	],

	// 15
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　■　　　　　　　　　■",
"■　始　　　B2　　■　　　　　　　　　■",
"■　　　　　　　　■　　　B1　　　B9　■",
"■　　　　　　　　■　　　　　　　　　■",
"■　　　　B8　B8　C4　■■G2■■■■　■",
"■　　　　　　　　　　■　　　　　　　■",
"■■■■■■■■■■■■　G2■■■■■■",
"■　　　　　　　　　　　　　　B2　　　■",
"■　終　■　■　　　　　　　　B2　B1　■",
"■　　　　　　　　　　　　　　　B1　　■",
"■　■　■　B6B6　　　　　　　B1　　　■",
"■　　　　　　　　　　　　　B1　　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■■■■■■G9■■■■■■C7■■■■■■",
	],

	// 16
	[
"■■■■■■■■■■■■■■■■■■■■",
"■　　　　　　　　　　　　　　　　　　■",
"■　B2B2B2B2B2　　　　　　　　　　　　■",
"■　　　　　　　　　　　　　　終　　　■",
"■　　　　　　　B8B8B8B8B8■■■■■　■",
"■　　　　　　　　　　　　　■■■　　■",
"■　　　　　　　　　　　　　　■　　　■",
"■　　　　　　　■■G8■■　　■　始　■",
"■　　　　　　　　■■■　　　■　　　■",
"■　■■G8■■　　　■　　　　■　　　■",
"■　　■■■　　　　■　　　　■　　　■",
"■■　　■R6　　　　■　　■　■　■　■",
"■　　　■　　　B8　■　B8　　■　　　■",
"■　　　　　　　　　　　　　　　　　　■",
"■G4■■■■■■■■■■■■■■■■■■",
	],
];
