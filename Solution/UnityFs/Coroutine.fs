module UnityFs.Coroutine

open System.Collections
open UnityEngine



[<Struct>]
type Running = {
    coroutine : Coroutine
    behaviour : MonoBehaviour
}

let inline start (behaviour : MonoBehaviour) (coroutine : seq<'a> when 'a :> YieldInstruction) = { 
    coroutine = coroutine :?> IEnumerator |> behaviour.StartCoroutine
    behaviour = behaviour
}

let inline stop running = running.behaviour.StopCoroutine running.coroutine