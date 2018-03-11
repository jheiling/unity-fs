namespace UnityFs.Examples

#nowarn "1182"

open UnityEngine
open UnityEngine.UI
open UnityFs



[<AddComponentMenu "Fs/Examples/CoroutineExample">]
type CoroutineExample () =
    inherit MonoBehaviour ()

    let [<SerializeField>] mutable wait = 1.f
    let [<SerializeField>] mutable (ui : Text) = null

    let rec run () = seq {
        yield WaitForSeconds wait
        let text = "Time: " + Time.time.ToString ()
        if exists ui then ui.text <- text else Debug.Log text
        yield! run ()
    }

    member private this.Awake () = run () |> Coroutine.start this |> ignore