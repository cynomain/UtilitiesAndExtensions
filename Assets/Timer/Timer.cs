using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CynoMain
{
    public class Timer
    {
        MonoBehaviour handle { get; set; } 

        public float functionDelay { get; set; }
        public float loopInterval { get; set; }

        public bool doLoop { get; set; }
        public int cyclesLeft { get; set; }
        public bool IsRealtime { get; set; }

        public bool IsExecutingDelay { get; private set; }
        public bool IsExecutingLoop { get; private set; }
        //public bool IsExecutingLoopInfinite { get; private set; }
       // public bool IsExecutingLoopFinite { get; private set; }

        public Timer(MonoBehaviour handle)
        {
            this.handle = handle;
        }

        public Timer(MonoBehaviour handle, bool isrealtime) : this(handle)
        {
            this.IsRealtime = isrealtime;
        }

        /// <summary>
        /// Executes a function within a delay
        /// </summary>
        /// <param name="action">The function to execute</param>
        /// <param name="delay">The delay of execution</param>
        public void ExecuteDelayed(Action action, float delay)
        {
            if (IsExecutingDelay)
            {
                throw GetException(ErrorMode.AlreadyExecutingDelayed);
            }
            this.functionDelay = delay;
            handle.StartCoroutine(Coroutine_Delay(() => action.Invoke()));
            IsExecutingDelay = true;
        }

        /// <summary>
        /// Executes a function infinitely with an interval
        /// </summary>
        /// <param name="action">The function to be executed</param>
        /// <param name="interval">The inverval between executions</param>
        public void ExecuteLooped(Action action, float interval) //Infinite
        {
            if (IsExecutingLoop)
            {
                throw GetException(ErrorMode.AlreadyExecutingLoopAny);
            }
            this.functionDelay = interval;
            this.doLoop = true;
            handle.StartCoroutine(Coroutine_Loop_Infinite(() => action.Invoke()));
            IsExecutingLoop = true;
        }

        /// <summary>
        /// Executes a function a number of times with an interval
        /// </summary>
        /// <param name="action">The function to be executed</param>
        /// <param name="interval">The interval between executions</param>
        /// <param name="cycles">The amount of times the function is going to be executed</param>
        public void ExecuteLooped(Action action, float interval, int cycles) //Finite
        {
            if (IsExecutingLoop)
            {
                throw GetException(ErrorMode.AlreadyExecutingLoopAny);
            }
            this.functionDelay = interval;
            this.doLoop = true;
            this.cyclesLeft = cycles;
            handle.StartCoroutine(Coroutine_Loop_Finite(() => action.Invoke()));
            IsExecutingLoop = true;
        }

        /// <summary>
        /// Pauses the loop being executed
        /// </summary>
        public void PauseLoop()
        {
            if (!IsExecutingLoop)
            {
                return;
            }
            doLoop = false;
        }

        /// <summary>
        /// Resumes the loop being executed
        /// </summary>
        public void ResumeLoop()
        {
            if (!IsExecutingLoop)
            {
                return;
            }
            doLoop = true;
        }

        /// <summary>
        /// Stops a loop being executed
        /// </summary>
        public void StopLoop()
        {
            if (!IsExecutingLoop)
            {
                return;
            }
            doLoop = false;
            IsExecutingLoop = false;
        }

        /// <summary>
        /// Cancels a delayed execution
        /// </summary>
        public void CancelDelay()
        {
            if (!IsExecutingDelay)
            {
                return;
            }
            handle.StopCoroutine(Coroutine_Delay(currentActLoop));
        }

        Action currentActLoop; //Interal uses
        IEnumerator Coroutine_Delay(Action act)
        {
            currentActLoop = act;
            if (IsRealtime)
            {
                yield return new WaitForSecondsRealtime(functionDelay);
            }
            else
            {
                yield return new WaitForSeconds(functionDelay);
            }
            act.Invoke();
            IsExecutingDelay = false;
        }

        IEnumerator Coroutine_Loop_Infinite(Action act)
        {
            currentActLoop = act;
            while (doLoop)
            {
                if (IsRealtime)
                {
                    yield return new WaitForSecondsRealtime(loopInterval);
                }
                else
                {
                    yield return new WaitForSeconds(loopInterval);
                }
                act.Invoke();
            }
        }

        IEnumerator Coroutine_Loop_Finite(Action act)
        {
            while (cyclesLeft > 0 && doLoop)
            {
                if (IsRealtime)
                {
                    yield return new WaitForSecondsRealtime(loopInterval);
                }
                else
                {
                    yield return new WaitForSeconds(loopInterval);
                }
                act.Invoke();
                cyclesLeft--;  
            }
            doLoop = false;
        }

        private Exception GetException(ErrorMode mode)
        {
            switch (mode)
            {
                case ErrorMode.AlreadyExecutingDelayed:
                    return new Exception("This Timer is already executing a delayed function. Please create another class.");
                /*
            case ErrorMode.AlreadyExecutingLoopInfinite:
                return new Exception("This Timer is already executing an infinite loop. Please create another class.");

            case ErrorMode.AlreadyExecutingLoopFinite:
                return new Exception("This Timer is already executing a finite loop. Please create another class.");
                */
                case ErrorMode.AlreadyExecutingLoopAny:
                    return new Exception("This TImer is already executing a loop. Please create another class.");

                default:
                    return new Exception("Invalid ErrorMode is about to be thrown");
            }
        }

        private enum ErrorMode
        {
            AlreadyExecutingDelayed,
            AlreadyExecutingLoopAny,
        }

        #region NotWorking
        /*
/// <summary>
/// Executes a function within a delay then eventually outs the return value
/// </summary>
/// <typeparam name="T">Type of return value</typeparam>
/// <param name="func">The function to execute, with a return value</param>
/// <param name="delay">The delay of execution</param>
public void ExecuteDelayed<T>(Func<T> func, float delay, out T returnvalue)
{
    if (IsExecutingDelay)
    {
        throw GetException(ErrorMode.AlreadyExecutingDelayed);
    }
    this.delay = delay;
    ReturnValue = null;
    handle.StartCoroutine(Coroutine_Delay_Func(() => func.Invoke()));
    IsExecutingDelay = true;

} 

        IEnumerator Coroutine_Delay_Func<T>(Func<T> func)
{
    if (IsRealtime)
    {
        yield return new WaitForSecondsRealtime(delay);
    }
    else
    {
        yield return new WaitForSeconds(delay);
    }
    ReturnValue = func.Invoke();
    IsExecutingDelay = false;
}

        public object ReturnValue { get; private set; }
*/
        #endregion
    }

    public static class TimerExtensions
    {
        public static Timer NewTimer(this MonoBehaviour mb)
        {
            return new Timer(mb);
        }
    }
}