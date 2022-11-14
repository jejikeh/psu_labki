proc Print_Map;prints the map of the game
Left_Column:	
	push 1     ;colour
	push 3	   ;columns
	push 86    ;rows
	push 0     ;y
	push 0     ;x
	call Print_Map_Anything
	push 1
	push 3
	push 76
	push 10
	push 8
	call Print_Map_Anything
	push 1
	push 3
	push 80
	push 112
	push 8
	call Print_Map_Anything
	push 1
	push 3
	push 85
	push 112
	push 0
	call Print_Map_Anything
	push 1
	push 8
	push 3
	push 83
	push 0
	call Print_Map_Anything
	push 1
	push 8
	push 3
	push 112
	push 0
	call Print_Map_Anything
Floor_Walls:
	push 1
	push 320
	push 3
	push 197
	push 0
	call Print_Map_Anything
	push 1
	push 301
	push 2
	push 190
	push 11
	call Print_Map_Anything
Right_Walls:
	push 1
	push 3
	push 86
	push 0
	push 317
	call Print_Map_Anything
	push 1
	push 3
	push 78
	push 8
	push 309
	call Print_Map_Anything
	push 1
	push 3
	push 80
	push 112
	push 309
	call Print_Map_Anything
	push 1
	push 3
	push 86
	push 112
	push 317
	call Print_Map_Anything
	push 1
	push 8
	push 3
	push 83
	push 309
	call Print_Map_Anything
	push 1
	push 8
	push 3
	push 112
	push 309
	call Print_Map_Anything
Top_Wall:
	push 1
	push 320
	push 3
	push 0
	push 0
	call Print_Map_Anything
	push 1
	push 303
	push 2
	push 8
	push 8
	call Print_Map_Anything
Inner_Top_LeftSide:
	push 1
	push 43
	push 3
	push 25
	push 27
	call Print_Map_Anything
	push 1
	push 2
	push 7
	push 28
	push 68
	call Print_Map_Anything
	push 1
	push 32
	push 3
	push 35
	push 38
	call Print_Map_Anything
	push 1
	push 3
	push 60
	push 26
	push 27
	call Print_Map_Anything
	push 1
	push 3
	push 51
	push 35
	push 38
	call Print_Map_Anything
	push 1
	push 13
	push 3
	push 83
	push 27
	call Print_Map_Anything
Inner_Bottom_leftSide:
	push 1
	push 43
	push 3
	push 172
	push 27
	call Print_Map_Anything
	push 1
	push 2
	push 7
	push 165
	push 68
	call Print_Map_Anything
	push 1
	push 32
	push 3
	push 162
	push 38
	call Print_Map_Anything
	push 1
	push 3
	push 60
	push 114
	push 27
	call Print_Map_Anything
	push 1
	push 3
	push 50
	push 112
	push 38
	call Print_Map_Anything
	push 1
	push 13
	push 3
	push 112
	push 27
	call Print_Map_Anything
top_wallExtension:
	push 1
	push 3
	push 28
	push 10
	push 85
	call Print_Map_Anything
	push 0
	push 7
	push 2
	push 8
	push 88
	call Print_Map_Anything
	push 1
	push 3
	push 28
	push 10
	push 95
	call Print_Map_Anything
	push 1
	push 10
	push 3
	push 35
	push 85
	call Print_Map_Anything
bottom_wallExtension:
	push 1
	push 3
	push 28
	push 162
	push 85
	call Print_Map_Anything
	push 0
	push 7
	push 2
	push 190
	push 88
	call Print_Map_Anything
	push 1
	push 3
	push 28
	push 162
	push 95
	call Print_Map_Anything
	push 1
	push 10
	push 3
	push 162
	push 85
	call Print_Map_Anything
inner_Top_Stripe:
	push 1
	push 41
	push 3
	push 55
	push 57
	call Print_Map_Anything
	push 1
	push 3
	push 31
	push 55
	push 57
	call Print_Map_Anything
	push 1
	push 41
	push 3
	push 83
	push 57
	call Print_Map_Anything
	push 1
	push 3
	push 31
	push 55
	push 95
	call Print_Map_Anything
Inner_Bottom_Stripe:
	push 1
	push 41
	push 3
	push 112
	push 57
	call Print_Map_Anything
	push 1
	push 3
	push 31
	push 112
	push 57
	call Print_Map_Anything
	push 1
	push 41
	push 3
	push 140
	push 57
	call Print_Map_Anything
	push 1
	push 3
	push 31
	push 112
	push 95
	call Print_Map_Anything
Inner_Top_RightSide:
	push 1
	push 43
	push 3
	push 25
	push 250
	call Print_Map_Anything
	push 1
	push 2
	push 7
	push 28
	push 250
	call Print_Map_Anything
	push 1
	push 3
	push 60
	push 25
	push 290
	call Print_Map_Anything
	push 1
	push 32
	push 3
	push 35
	push 250
	call Print_Map_Anything
	push 1
	push 3
	push 51
	push 35
	push 279
	call Print_Map_Anything
	push 1
	push 14
	push 3
	push 83
	push 279
	call Print_Map_Anything
TopRight_WallExtension:
	push 1
	push 3
	push 28
	push 10
	push 232
	call Print_Map_Anything
	push 0
	push 7
	push 2
	push 8
	push 225
	call Print_Map_Anything
	push 1
	push 3
	push 28
	push 10
	push 222
	call Print_Map_Anything
	push 1
	push 10
	push 3
	push 35
	push 222
	call Print_Map_Anything
Inner_Top_RightStripe:	
	push 1
	push 41
	push 3
	push 55
	push 222
	call Print_Map_Anything
	push 1
	push 3
	push 31
	push 55
	push 222
	call Print_Map_Anything
	push 1
	push 41
	push 3
	push 83
	push 222
	call Print_Map_Anything
	push 1
	push 3
	push 31
	push 55
	push 260
	call Print_Map_Anything
BottomRight_WallExtension:
	push 1
	push 3
	push 28
	push 162
	push 232
	call Print_Map_Anything
	push 0
	push 7
	push 2
	push 190
	push 225
	call Print_Map_Anything
	push 1
	push 3
	push 28
	push 162
	push 222
	call Print_Map_Anything
	push 1
	push 10
	push 3
	push 162
	push 222
	call Print_Map_Anything
Inner_BottomRight:
	push 1
	push 43
	push 3
	push 172
	push 250
	call Print_Map_Anything
	push 1
	push 2
	push 7
	push 165
	push 250
	call Print_Map_Anything
	push 1
	push 3
	push 60
	push 112
	push 290
	call Print_Map_Anything
	push 1
	push 32
	push 3
	push 162
	push 250
	call Print_Map_Anything
	push 1
	push 3
	push 51
	push 112
	push 279
	call Print_Map_Anything
	push 1
	push 14
	push 3
	push 112
	push 279
	call Print_Map_Anything
BottomRight_Stripe:
	push 1
	push 41
	push 3
	push 112
	push 222
	call Print_Map_Anything
	push 1
	push 3
	push 31
	push 112
	push 222
	call Print_Map_Anything
	push 1
	push 3
	push 31
	push 112
	push 260
	call Print_Map_Anything
	push 1
	push 41
	push 3
	push 140
	push 222
	call Print_Map_Anything
Middle_TopStripe:;y-25, x-113
	push 1
	push 91
	push 3
	push 25
	push 114
	call Print_Map_Anything
	push 1
	push 2
	push 13
	push 25
	push 114
	call Print_Map_Anything
	push 1
	push 2
	push 13
	push 25
	push 203
	call Print_Map_Anything
	push 1
	push 91
	push 3
	push 35
	push 114
	call Print_Map_Anything
Middle_BottomStripe:
	push 1
	push 91
	push 3
	push 162
	push 114
	call Print_Map_Anything
	push 1
	push 2
	push 13
	push 162
	push 114
	call Print_Map_Anything
	push 1
	push 2
	push 13
	push 162
	push 203
	call Print_Map_Anything
	push 1
	push 91
	push 3
	push 172
	push 114
	call Print_Map_Anything
Middle_HigherStripe:
	push 1
	push 91
	push 3
	push 55
	push 114
	call Print_Map_Anything
	push 1
	push 2
	push 31
	push 55
	push 114
	call Print_Map_Anything
	push 1
	push 91
	push 3
	push 83
	push 114
	call Print_Map_Anything
	push 1
	push 2
	push 31
	push 55
	push 203
	call Print_Map_Anything
Middle_LowerStripe:
	push 1
	push 91
	push 3
	push 112
	push 114
	call Print_Map_Anything
	push 1
	push 2
	push 31
	push 112
	push 114
	call Print_Map_Anything
	push 1
	push 91
	push 3
	push 140
	push 114
	call Print_Map_Anything
	push 1
	push 2
	push 31
	push 112
	push 203
	call Print_Map_Anything
	ret
	endp Print_Map