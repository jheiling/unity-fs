module UnityFs.Coroutine

open System.Collections
open UnityEngine



let inline start (behaviour : MonoBehaviour) (coroutine : seq<'a> when 'a :> YieldInstruction) = coroutine :?> IEnumerator |> behaviour.StartCoroutine