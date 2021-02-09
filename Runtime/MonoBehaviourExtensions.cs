using System;
using System.Collections;
using UnityEngine;

namespace Skibitsky.Asuka
{
    public static class MonoBehaviourExtensions
    {
        public static Coroutine Invoke(this MonoBehaviour source, Action method, float delay)
        {
            IEnumerator Delay()
            {
                yield return new WaitForSeconds(delay);
                method.Invoke();
            }

            return source.StartCoroutine(Delay());
        }

    }
}