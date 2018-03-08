module UnityFs.Coroutine

open UnityEngine
open System.Collections



let inline start (behaviour : MonoBehaviour) (coroutine : seq<'a> when 'a :> YieldInstruction) = coroutine :?> IEnumerator |> behaviour.StartCoroutine