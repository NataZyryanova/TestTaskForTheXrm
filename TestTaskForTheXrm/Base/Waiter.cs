using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;

namespace TestTaskForTheXrm.Base
{
    public class Waiter
    {
        public static void Wait(Action action, string errorMessage=null, int timeout = 5000)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var isItFailure = true;
            string lastException = null;

            while (sw.Elapsed < TimeSpan.FromMilliseconds(timeout) && isItFailure)
            {
               try
                {
                    Thread.Sleep(100);
                    action();
                    isItFailure = false;
                }
                catch (Exception e)
                {
                    lastException = e.Message;
                }
            }
            sw.Stop();

            if (isItFailure)
            {
                var exceptionMessage = !string.IsNullOrEmpty(lastException) ? lastException : string.Empty;
                var defaultMessage = $"Pending action did not happen in {timeout} milliseconds";
                var message = !string.IsNullOrEmpty(errorMessage) ? errorMessage : defaultMessage;
                throw new AssertionException($"{message}\n exceptionMessage:\n{exceptionMessage}");
            }
        }
    }
}
