namespace UnityFs



module Object =
    let inline exists obj = not (obj = null) && not (obj.Equals null)



[<AutoOpen>]
module ObjectOperators =
    let (|Exists|Missing|) obj = if Object.exists obj then Exists else Missing