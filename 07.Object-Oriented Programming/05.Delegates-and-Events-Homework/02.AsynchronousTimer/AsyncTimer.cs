namespace AsynchronousTimer
{
    using System;
    using System.Threading;

    public class AsyncTimer
    {
        private Action method;
        private int ticks;
        private int interval;

        public AsyncTimer(Action method, int ticks, int interval)
        {
            this.method = method;
            this.Ticks = ticks;
            this.Interval = interval;
        }

        public int Ticks
        {
            get
            {
                return this.ticks;
            }

            set
            {
                this.ticks = value;
            }
        }

        public int Interval
        {
            get
            {
                return this.interval;
            }

            set
            {
                this.interval = value;
            }
        }

        public void StartTimer()
        {
            Thread thread = new Thread(this.DoMethod);
            thread.Start();
        }

        private void DoMethod()
        {
            while (this.ticks > 0)
            {
                Thread.Sleep(this.interval);

                if (this.method != null)
                {
                    this.method();
                }

                this.ticks--;
            }
        }
    }
}
