module UnityFs.Coroutine

open UnityEngine
open System.Collections



let inline start (behaviour : MonoBehaviour) (coroutine : seq<_>) = coroutine :?> IEnumerator |> behaviour.StartCoroutine