mybox = box length:20 width:20 height:20
mybox.name = "mybox"
mybox.wirecolor = red
mybox.pos = [0,0,10]
mybox.scale = [1.5,1.5,1.5]
addModifier mybox (Twist angle:30)

mybox2 = box()
mybox.name = "mybox2"
mybox.wirecolor = green
mybox.pos = [0,0,30]
addModifier mybox2 (Twist angle:10)

/* 
循环结构 ，构造出20个圆锥
*/ 
for i = 1 to 20 do 
(
    myboxTemp = Cone()
    dis = i * 50
    myboxTemp.pos = [dis,0,0]
)

temp2 = 200
while (temp2 < 1000) do 
(
    if (temp2 == 400) then 
    (
        temp2 += 50
        continue   
    )

    mysphere = Sphere()
    mysphere.pos = [0,temp2,0]
    temp2 += 50
)


/* 
定义方法，以及方法调用。
这里的形参类似C#的可选参数
*/ 
function func1 arg1:100 = 
(
    do (
        mybox.pos.z += 10
        arg1 -= 10
    ) while ( arg1 > 0 )
)
func1 arg1:200  /* 调用方法func1 */