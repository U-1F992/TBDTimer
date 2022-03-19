namespace TBDTimer
{
    public class Timer
    {
        private Task? _task;
        private long _elapsedMilliseconds = 0;
        private long _submittedMilliseconds = long.MaxValue;
        
        /// <summary>
        /// 開始後に終了時間を設定することができるタイマークラス<br/>
        /// To-Be-Determined Timer
        /// </summary>
        public Timer()
        {
            // 初回のみ遅延があるため、コンストラクタで捨てておく
            // メモリに展開する際の何らかな気がする
            Start();
            Stop();
        }

        /// <summary>
        /// タイマーを開始する
        /// </summary>
        /// <returns></returns>
        public Task Start()
        {
            _elapsedMilliseconds = 0;

            _task = Task.Run(() =>
            {
                var interval = 10000000 / 1000;
                var next = DateTime.Now.Ticks + interval;

                while (_elapsedMilliseconds < _submittedMilliseconds)
                {
                    if (next <= DateTime.Now.Ticks)
                    {
                        _elapsedMilliseconds++;
                        next += interval;
                    }
                }
            });

            return _task;
        }

        /// <summary>
        /// タイマーの終了時間を設定する
        /// </summary>
        /// <param name="milliseconds"></param>
        public void Submit(long milliseconds)
        {
            _submittedMilliseconds = milliseconds;
        }

        /// <summary>
        /// タイマーを強制停止しリセットする
        /// </summary>
        public void Stop()
        {
            _elapsedMilliseconds = long.MaxValue;
            _task?.Wait();

            _task = null;
            _elapsedMilliseconds = 0;
            _submittedMilliseconds = long.MaxValue;
        }
    }
}