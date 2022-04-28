

# 3DSmax操作

## 软件简介

VRay渲染器是由chaosgroup和asgvis公司出品的一款高质量渲染软件。

3D Studio Max，常简称为3d Max或3ds MAX，是Discreet公司开发的（后被Autodesk公司合并）基于PC系统的三维动画渲染和制作软件。

## 下载

https://www.autodesk.com.cn/ ，首先登陆。点击如下，进入产品选择页

![](Pictures/NoteForSmartAccelerate/3DSmax安装.png)

选择想要的版本

![](Pictures/NoteForSmartAccelerate/3DSmax安装2.png)

## 相关路径

|                                             |                                                              |
| ------------------------------------------- | ------------------------------------------------------------ |
| MAX SDK安装包                               | C:\Autodesk\WI\Autodesk 3ds Max 2019\x64\Tools\MAXSDK        |
| MAX SDK安装目录                             | C:\Program Files\Autodesk\3ds Max 2019 SDK\maxsdk            |
| VS2017的vcprojects文件夹                    | D:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\VC\vcprojects |
| 3DMAX安装目录                               | C:\Program Files\Autodesk\3ds Max 2019                       |
| MAX SDK项目链接器的附加库目录               | C:\Program Files\Autodesk\3ds Max 2019 SDK\maxsdk\lib\x64\Release |
| 3dsmax.general.project.settings.props的路径 | C:\Program Files\Autodesk\3ds Max 2019 SDK\maxsdk\ProjectSettings\propertySheets |
| 3dsMAX Network License Manager              | C:\Autodesk\WI\Autodesk 3ds Max 2019\x64\Tools\NLM           |
| Vray分布式渲染配置文件                      | C:\Users\LGT\AppData\Local\Autodesk\3dsMax\2019 - 64bit\CHS\zh-CN\plugcfg |

## 渲染步骤

设置摄像机  --->  设置材质 --->  设置灯光 --->  ps后期处理

1. 设置摄像机

![](Pictures/NoteForSmartAccelerate/渲染步骤1.png)

一般选择：命令面板---创建面板---摄像机---标准。

目标相机、物理相机的创建方法：顶视图，左键拖拉。

物理相机类似于现实的单反相机，可设置胶片、镜头、镜头聚焦、快门、曝光、白平衡等。

目标相机则参数较少，较为常用。

自由相机与其他相机的区别：没有目标点。



选中相机，命令面板---修改面板 ，下面介绍这个面板的几个栏的参数。

备用镜头：镜头远近

手动剪切：只会看到 近距~远距 之间范围的物体。



2. 设置材质

选在渲染设置里将渲染器选为 v-ray渲染器。M键打开材质编辑器，切换模式为精简，



## 中文版

在windows开始菜单选择打开中文版3dsmax即可

## 快捷键、常用功能

调整观察 所绘制对象 的方式：

<img src="Pictures/NoteForACC/3dsmax操作1.png"  />

- Z----选中物体再按z，可以让物体在当前视图最大化
- C----进入相机视角
- 滚轮----放大缩小
- Ctrl+alt+滚轮-----细节调整放大缩小
- G----隐藏、显示 栅格
- alt+w-----最大化选中视图、还原当前视图
- 鼠标中键------移动视图
- Alt+鼠标中键-----先选中物体，旋转视图
- Q、W、E、R-----更改选择方式、选择并移动、选择并旋转、选择并缩放。这四种处理方式均支持对X-Y-Z轴的自由操作，通过在操作时选择某个轴 / 某个面 。
-  -和= ------ 在w移动模式下，坐标轴放大和缩小
- A------角度捕捉是否打开。
- S------栅格捕捉是否打开。

![](Pictures/NoteForACC/3dsmax操作2.png)

- 右键此区域可调整视口布局

## 软件设置

单位：自定义---单位设置---公制米，系统单位设置选厘米。

驱动：自定义---首选项---视口---选择驱动程序---旧版direct3D

场景撤销：自定义—首选项---常规，场景撤销500，含义是ctrl+z的撤回步数

## 常用功能

角度捕捉。一般在旋转时使用，使得可以按指定角度为单位进行旋转，深蓝色为功能激活状态。右键图标可设置角度度数，选项----角度---90 。

栅格捕捉。首先要清楚xyz坐标轴的原点是基本对象建立时底面的中心点。具体设置：右键栅格捕捉开关图标，捕捉---勾选顶点、栅格点。在移动对象时先坐标轴原点归零，然后以移动时发现能以栅格点为吸附点。

克隆对象。移动模式下，按住shift拖动某条轴

可编辑多边形。选中对象，右键转换为：-----可编辑多边形。**转换前**对象的修改器列表是Box，**转换后**对象的修改器列表是可编辑多边形，转换前可设置长宽高的**分段数。**结合右侧面板的修改选项卡，可以实现对顶点、边的单独设置。对点设计与分段数有关。

## 实践：画一个雨伞

修改器 - 网格编辑 - 挤出extrude





# 问题&办法

## 打开3dsmax闪退

可能是3dsmax病毒导致，安装杀毒卫士：
http://anti.3dmomo.com/home/anti_index.php 

## 3dsmax打开后出现script controller窗口，然后闪退

C:\Users\你的用户名\AppData\Local\Autodesk\3dsMax

C:\Users\你的用户名\AppData\Roaming\Autodesk\3dsMax 2019 

删除这两个目录下的所有文件

再到 控制面板\程序\程序和功能 右键3dsmax更改---修复。

## 3dMax的文字显示不全

<img src="Pictures/NoteForACC/3dsmax文字显示不全.png" style="zoom: 80%;" />

![](Pictures/NoteForACC/3dsmax文字显示不全2.png)

更改到一个合适的电脑缩放比例

以及更改屏幕分辨率

# 3DSmax MaxScript

## 主要用途、IDE

快速完成一些机械性的操作，以及一些 人来完成非常无聊乏味和低效的 事情。

安装vscode以及Language MaxScript插件。

## 基本语法、visual maxscriptEditor

语法见sample。

visual maxscriptEditor，可视化的脚本UI编辑器，与winform自动生成designer.cs代码 以及 winform设计视图 类似。在3DSmax的脚本菜单栏中打开。

![](Pictures/NoteForSmartAccelerate/visualMaxscriptEditor.png)

外层黑框类似于Form窗体，可拖动下方的各种控件到窗体内。

值得注意的是它支持 **计时器、ActiveX控件、自定义控件** 这三种控件。

事件标签内可以编辑 控件的事件处理程序。

# 3DSmax SDK

## demo步骤

1. 修改文件。

C:\Program Files\Autodesk\3ds Max 2019 SDK\maxsdk\howto\3dsmaxPluginWizard路径下的3dsmaxPluginWizard.vsz文件：

Wizard=VsWizard.VsWizardEngine.14.0  对应  vs2015

Wizard=VsWizard.VsWizardEngine.15.0  对应  vs2017

ABSOLUTE_PATH改成SDK安装路径

2. 复制文件。

到 C:\Program Files\Autodesk\3ds Max 2019 SDK\maxsdk\howto\3dsmaxPluginWizard 下，复制三个3dsmaxPluginWizard为文件名的文件到VS2017的vcprojects文件夹路径。

3. 新建一个3dmax插件项目

新建项目记得更改3个textbox框，这三个分别对应了max SDK根目录、本项目的项目文件存放路径、max的安装目录

4. 修改3dsmax.general.project.settings.props

文件在 C:\Program Files\Autodesk\3ds Max 2019 SDK\maxsdk\ProjectSettings\propertySheets ，修改WindowsTargetPlatformVersion元素节点的值，确保这个值和  **VS项目的目标平台版本**  的值一样。

5. 设置权限

C:\Program Files\Autodesk\3ds Max 2019 SDK\maxsdk\tools下的RunMUIRCT.exe文件， 对所有用户总是以管理员身份打开

6. 设置工具集

在vs的 安装面板---单个组件 中，选择安装 适用于桌面的VC++2015.3 v14.00（v140）工具集。再更改项目的平台工具集 为 V140。

7. 修改项目属性

根据项目链接器的附加库目录，修改 解决方案配置 为release ，以及 解决方案平台 为x64 。

# 渲染技术

## 原始的光栅化渲染

定义：如果我们要在二维显示器中看到三维空间的三角面单元，那么我们就需要把三角面从三维空间渲染到二维空间去。

为了完成渲染，只需要计算三角面到人眼这个方向的光线。这个方向也叫做人眼方向、摄像机方向、视角方向。

下图中左边的小方块是人眼，中间的长方形是屏幕，屏幕里面的小格子是像素，右边的是三角面。

![](Pictures/NoteForSmartAccelerate/光栅渲染.jpg)

通过这三条线与屏幕的交点就可以将下图展示到屏幕上

![](Pictures/NoteForSmartAccelerate/光栅渲染屏幕图.jpg)

可以得知，这种方法采用的光线是依据**三角面**的，可以看作是 光源发出光之后，光在三角面反射，**以三个顶点为射线起点经过屏幕到达人眼处**。

## ray casting光线投射法

这种方法采用的光线与第一种不同，他是依据人眼的。他的光线以人眼处为射线起点，一个像素格子对应一条光线，射线射出去再观察是否投射到物体上。

![](Pictures/NoteForSmartAccelerate/光线投射法.jpg)

## 两者优劣势

Ray casting更擅长解决远近遮挡问题，

光栅计算量更少，因为光线数量更少

光栅对模拟逼真的阴影、反射、折射问题，一直没有得到解决。

## 新渲染方法，ray tracing光线追踪

新方法是ray casting的升级版，不同的是，当射线射出之后碰到物体它会**画出反射线**，光线可以一直反射下去来 **确认它是否会经过光源**。

如果碰到透明的物体，就用折射代替反射。

可以看出，ray casting的进步空间就是 绘制和分析 更多的光线，所以需要更多的计算。

## rendering equation渲染方程

ray tracing算法演进的关键成果，这个方程基于Conservation of energy能量守恒和麦克斯韦方程，来模拟并计算出应该被感知的光线。

此后难点便转移到了渲染方程的计算、积分的最优解和最快解，如何计算得更准确更快速。经历了一些阶段，如从不同的方面呈现基本光线追踪图像的光能传递角度和求取他平均值、蒙特卡罗积分等。

# V-Ray

## 下载

进入官网 https://www.chaosgroup.com/cn ，登陆账户后下载安装包

## 本地注册

在目录 C:\ProgramData\Autodesk\ApplicationPlugins\VRay3dsMax2022\bin 下。

将v-ray GPU render server注册为一个服务，控制台执行

```
.\vraystdspawner.exe -service
```

将v-ray spawner 注册为一个服务

```
.\vrayspawner2022.exe -service
```

## 开启试用30天

注册一个新账户，并开启试用30天：

进入 https://www.chaosgroup.com/ ，点击试用，开启vray for 3ds max的试用

## 使用离线许可

1. 进入windows键，Chaos Group，Manage Chaos License Server
2. Sign in登录
3. 点击使用离线许可证

![](Pictures/NoteForSmartAccelerate/离线license.png)

出现灰色闪电代表离线license设置成功

![](Pictures/NoteForSmartAccelerate/离线license2.png)

## 技术支持回复摘要

1 universal license--------This allows you to use V-Ray UI (3ds Max in this case) on one machine。

1 render node license--------- render on one machine. 



we don't have a complete offline package but once you download the V-Ray installation file you can keep the installation file for future installations.     安装文件还需要从v-ray服务器下载数据。



Set up the nodes the following way:

1. Install 3Ds Max 20XX on the nodes - no need to activate/license is. Just installing is enough.   用作render server的节点机器不需要3dsmax的license
2. Install V-Ray as a Workstation (not as a render node or standalone)
3. When you launch the Spawner it will boot 3ds Max and load V-Ray in it.    用作render server的机器3dsmax和v-ray都需要安装。

# V-ray分布式渲染

## 什么是分布式渲染

把单帧划分成不同区域（buckets），给各个计算机单独计算，最后合并成图像。

![](Pictures/NoteForSmartAccelerate/分布式渲染定义.png)

## 限制条件

1. 客户端和服务端在同一个局域网
2. 客户端和服务端连接同一个路由器
3. 客户端和服务端处于同一个网段（A.B.C.D ，A.B.C前三个相同）
4. 所有的文件和路径 都为英文或数字
5. 3DMAX版本相同；VRay版本相同

## 设置步骤

1. 客户端。参考 vs远程调试 ，在进行关于共享的设置，并新建一个共享文件夹。

![](Pictures/NoteForSmartAccelerate/分布式渲染设置1.png)

如果共享按钮为灰色，就查看右侧文件夹选项是否勾选

2. 客户端与服务端。需要都加入同一个  组 或者 域。

对于 组：

组分为：家庭组、工作组、公共组。可以通过如下方式 ，进入网络配置文件更改。

![](Pictures/NoteForSmartAccelerate/修改所属组.png)

可以在如下界面看到当前网络的所属组：

![](Pictures/NoteForSmartAccelerate/查看所属组.png)

对于 域：

域分为 域和工作组， 域的设置如下：**网络ID** 按钮可以加入已有域或工作组， **更改** 可以创建并加入新的域。

![](Pictures/NoteForSmartAccelerate/设置域.png)

3. 客户端。将项目的max工程文件和关联的贴图文件等复制到共享文件夹。

![](Pictures/NoteForSmartAccelerate/分布式渲染设置3.png)

4. 客户端。重新打开共享文件夹里的max文件。通过如下路径打开 [\\LGTNO1\myname](file://LGTNO1/myname) ：

![](Pictures/NoteForSmartAccelerate/分布式渲染设置4.png)

LGTNO1是客户端的计算机全名。

一般来标识一个电脑的，经常想到的会有：设备名、设备描述、登陆账户名。

![](Pictures/NoteForSmartAccelerate/标识电脑1.png)

![](Pictures/NoteForSmartAccelerate/标识电脑2.png)

5. 客户端。shift + T 打开资源追踪器，把所有文件的路径改成网络路径

![](Pictures/NoteForSmartAccelerate/分布式渲染设置5.png)

6. 客户端。进入渲染设置。

选择渲染器，选择渲染的视角，选择输出的路径。

![](Pictures/NoteForSmartAccelerate/分布式渲染设置6.png)

7. 客户端。分布式渲染参数设置。

Host name填服务端设备名，记得加上客户端自己的设备名并打开客户端的spawner。填完resolve 解析服务端，出现正确的IP地址。

![](Pictures/NoteForSmartAccelerate/分布式渲染设置7.png)



## 参考

vray渲染技巧

http://www.pinsuodesign.com/design/x-4411.html

https://jingyan.baidu.com/article/20095761d7c564cb0721b421.html
