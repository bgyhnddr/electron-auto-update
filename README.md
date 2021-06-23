# 智厨屏显客户端辅助更新工具

## 此工具需要vs2019编译

## 通过electron内部通过childprocess调用该程序，通过此程序中的更新配置，对比次程序与服务器上的版本差异来进行更新。


https://pub-catering.utcook.com/kitchen-client.xml 中包含最新版本
version传入当前版本。就能自动对比版本，理论来说能更新任何electron程序，用于逻辑包不大的electron

```js
var update_process = require('child_process').spawn(
  'kitchen-client-update.exe',
  ['更新', 'https://pub-catering.utcook.com/kitchen-client.xml', version],
)

update_process.stdout.on('data', function (data) {
  if (data == 'exit') {
    app.exit()
  }
})
```
