# 智厨屏显客户端辅助更新工具

## 此工具需要vs2019编译

## 通过electron内部通过childprocess调用该程序，通过此程序中的更新配置，对比次程序与服务器上的版本差异来进行更新。可以通过修改AssemblyInfo.cs中的AssemblyVersion来达到升级的目的，生成后需要拷贝到屏显主项目中使用