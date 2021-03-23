using System;
using System.Diagnostics;

namespace Skibitsky.Asuka
{
    /// <summary>
    /// Disposable stopwatch to be used with `using` statement
    /// </summary>
    /// <example>
    /// using(new DisposableStopwatch("First Stopwatch")
    /// {
    ///     // computation
    ///     using(new DisposableStopwatch("Second Stopwatch")
    ///     {
    ///         // computation
    ///     }
    /// }
    /// </example>
    public class DisposableStopwatch : IDisposable
    {
        private readonly string _name;
        private readonly Stopwatch _stopwatch;
        private readonly Action<string> _logger;
        
        public DisposableStopwatch(string name, Action<string> logger = null)
        {
            _name = name;
            _logger = logger ?? UnityEngine.Debug.Log;
            _stopwatch = Stopwatch.StartNew();
        }
        
        public void Dispose()
        {
            _stopwatch.Stop();
            _logger?.Invoke($"[DisposableStopwatch]: {_name} took {_stopwatch.Elapsed.Milliseconds} milliseconds");
        }
    }
}