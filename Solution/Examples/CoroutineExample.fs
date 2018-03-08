namespace UnityFs.Examples

#nowarn "1182"

open UnityFs
open UnityEngine
open UnityEngine.UI



[<AddComponentMenu "Fs/Examples/CoroutineExample">]
type CoroutineExample () =
    inherit MonoBehaviour ()

    let [<SerializeField>] mutable wait = 1.f
    let [<SerializeField>] mutable (ui : Text) = null
    let mutable running = None

    let display text =
        match ui with
        | Exists -> ui.text <- text
        | Missing -> Debug.Log text

    let rec coroutine yieldInstruction = 
        seq {
            yield yieldInstruction
            "Time: " + Time.time.ToString () |> display
            yield! coroutine yieldInstruction
        }

    member private this.OnEnable () = running <- WaitForSeconds wait |> coroutine |> Coroutine.start this |> Some

    member private __.OnDisable () = Option.iter Coroutine.stop running