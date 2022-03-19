# TBDTimer

To-Be-Determined Timer

開始後に終了時間を設定することができるタイマークラス

## Usage

```cs
using TBDTimer;

var timer = new Timer();

// ここから
var task = timer.Start();
// ~~~~~
timer.Submit(1000); // 途中で終了時間を設定して
// ~~~~~
task.Wait();
// ここまでが1000ms
// (間の処理が1000ms以内で終了することは保証されません)
```

## References

- [CCTimer](https://twitter.com/_3z8/status/1246732775501099010?s=20&t=46-yuKgygzZr3l5Y90QaIw)
- [WindowsFormsでタイマーを作ろう2](https://scrapbox.io/yatsuna827827-12010999/WindowsForms%E3%81%A7%E3%82%BF%E3%82%A4%E3%83%9E%E3%83%BC%E3%82%92%E4%BD%9C%E3%82%8D%E3%81%862)
