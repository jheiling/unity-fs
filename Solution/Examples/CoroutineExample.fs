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

    member private this.Awake () = WaitForSeconds wait |> coroutine |> Coroutine.start this |> ignore