using Xunit;

using System.Diagnostics;
using TBDTimer;

public class UnitTest1
{
    [Fact(DisplayName = "100ms待機して、経過時間が±2ms以内に収まる")]
    public void Wait_100ms_settle_within_2ms()
    {
        var timer = new Timer();
        var sw = new Stopwatch();

        timer.Submit(100);

        sw.Start();
        timer.Start().Wait();
        sw.Stop();

        Assert.InRange(sw.ElapsedMilliseconds, 100 - 2, 100 + 2);
    }

    [Fact(DisplayName = "終了時間はStartより後から設定することができる")]
    public void End_time_can_be_set_later_than_Start()
    {
        var timer = new Timer();
        var sw = new Stopwatch();

        sw.Start();
        var task = timer.Start();
        timer.Submit(100);
        task.Wait();
        sw.Stop();

        Assert.InRange(sw.ElapsedMilliseconds, 100 - 2, 100 + 2);
    }

    [Fact(DisplayName = "あるインスタンスは複数回Startすることができる")]
    public void An_instance_should_be_started_multiple_times()
    {
        var timer = new Timer();

        timer.Submit(1);
        timer.Start().Wait();

        timer.Submit(1);
        timer.Start().Wait();
    }

    [Fact(DisplayName = "あるTimerのTaskはStopすることができる")]
    public void A_Task_of_Timer_should_be_stopped()
    {
        var timer = new Timer();
        
        timer.Start();
        timer.Stop();
    }
}