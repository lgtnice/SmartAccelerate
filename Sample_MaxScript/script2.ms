
mybox = box length:20 width:20 height:20 /* �������� */
mybox.name = "mybox"	/* �޸ı��������� */
mybox.wirecolor = red
mybox.pos = [0,0,10]
mybox.scale = [1.5,1.5,1.5]
addModifier mybox (Twist angle:30)	/* �����������޸��� */

function func1 arg1:100 = 
(
    do (	/* do-while�ṹ��ʹ�ô���Ƭ������ */
        mybox.pos.z += 10
        arg1 -= 10
    ) while ( arg1 > 0 )

)

rollout rollout1 "�ҵı���1" width:162 height:300
(
	button 'btn2' "��ť1��" pos:[46,63] width:81 height:91 align:#left
	on btn2 pressed  do
		func1()
)

CreateDialog rollout1