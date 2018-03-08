namespace UnityFs.Examples

#nowarn "1182"

open UnityFs
open UnityEngine
open UnityEngine.UI



[<AddComponentMenu "Fs/Examples/CoroutineExample">]
type CoroutineExample () =
    inherit MonoBehaviour ()

    let [<SerializeField>] waitTime = 1.f
    let [<SerializeField>] (ui : Text) = null

    let display text =
        match ui with
        | Exists -> ui.text <- text
        | Missing -> Debug.Log text

    let rec routine waitTime = 
        seq {
            yield WaitForSeconds waitTime
            "Time: " + Time.time.ToString () |> display
            yield! routine waitTime
        }

    member private __.Start () = routine waitTime |> MonoBehaviour.startCoroutine