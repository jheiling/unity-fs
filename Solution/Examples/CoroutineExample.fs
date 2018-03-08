namespace UnityFs.Examples

#nowarn "1182"

open UnityFs
open UnityEngine
open UnityEngine.UI



[<AddComponentMenu "Fs/Examples/CoroutineExample">]
type CoroutineExample () =
    inherit MonoBehaviour ()

    let [<SerializeField>] wait = 1.f
    let [<SerializeField>] (ui : Text) = null

    let display text =
        match ui with
        | Exists -> ui.text <- text
        | Missing -> Debug.Log text

    let rec coroutine wait = 
        seq {
            yield WaitForSeconds wait
            "Time: " + Time.time.ToString () |> display
            yield! coroutine wait
        }

    member private this.Start () = coroutine wait |> Coroutine.start this |> ignore