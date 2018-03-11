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

    let rec coroutine yieldInstruction = 
        seq {
            yield yieldInstruction
            let text = "Time: " + Time.time.ToString ()
            if exists ui then ui.text <- text else Debug.Log text
            yield! coroutine yieldInstruction
        }

    member private this.Awake () = WaitForSeconds wait |> coroutine |> Coroutine.start this |> ignore