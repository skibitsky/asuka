using UnityEngine;

namespace Skibitsky.Asuka
{
    /// <summary>
    /// A scriptable object shell to hold data objects. Inherit from this class.
    /// </summary>
    /// <remarks>
    /// Allows to write more unity-agnostic code that doesn't depend on ScriptableObject directly,
    /// but at the same time allows to store instances of data objects as unity assets.
    /// Very handy when data object is generated in code in some cases (unit tests, network code, etc). 
    /// </remarks>
    public class ScriptableObjectShell<T> : ScriptableObject where T : new()
    {
        [SerializeReference] public T Value = new T();

        public static implicit operator T(ScriptableObjectShell<T> asset) => asset.Value;
    }
}