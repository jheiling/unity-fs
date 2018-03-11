namespace UnityFs



[<AutoOpen>]
module Object =
    /// <summary>
    /// Checks if an object exists.
    /// </summary>
    /// <param name="obj">The object.</param>
    let inline exists obj = not (obj = null) && not (obj.Equals null)

    /// <summary>
    /// Checks if an object exists.
    /// Warning: allocates memory on the heap.
    /// </summary>
    /// <param name="obj">The object.</param>
    let (|Exists|Missing|) obj = if exists obj then Exists else Missing