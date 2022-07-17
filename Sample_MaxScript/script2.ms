
mybox = box length:20 width:20 height:20 /* 声明变量 */
mybox.name = "mybox"	/* 修改变量的属性 */
mybox.wirecolor = red
mybox.pos = [0,0,10]
mybox.scale = [1.5,1.5,1.5]
addModifier mybox (Twist angle:30)	/* 给变量增加修改器 */

function func1 arg1:100 = 
(
    do (	/* do-while结构可使用代码片段生成 */
        mybox.pos.z += 10
        arg1 -= 10
    ) while ( arg1 > 0 )

)

rollout rollout1 "我的标题1" width:162 height:300
(
	button 'btn2' "按钮1号" pos:[46,63] width:81 height:91 align:#left
	on btn2 pressed  do
		func1()
)

CreateDialog rollout1