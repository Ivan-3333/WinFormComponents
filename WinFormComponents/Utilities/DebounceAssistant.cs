using System;
using System.Threading;

namespace WinFormComponents.Utilities
{
    public class DebounceAssistant
    {
        public event EventHandler Idled = delegate { };
        public int WaitingMilliSeconds { get; set; }
        System.Threading.Timer waitingTimer;

        public DebounceAssistant(int waitingMilliSeconds = 600)
        {
            WaitingMilliSeconds = waitingMilliSeconds;
            waitingTimer = new Timer(p =>
            {
                Idled(this, EventArgs.Empty);
            });
        }

        public void TextChanged()
        {
            waitingTimer.Change(WaitingMilliSeconds, System.Threading.Timeout.Infinite);
        }
    }
}
