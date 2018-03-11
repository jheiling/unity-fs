module UnityFs.Coroutine

open System.Collections
open UnityEngine



/// <summary>
/// Starts a Coroutine.
/// </summary>
/// <param name="behaviour">The MonoBehaviour executing the Coroutine.</param>
/// <param name="instructions">Sequence of YieldInstructions.</param>
/// <returns>A Coroutine object</returns>
let inline start (behaviour : MonoBehaviour) (instructions : seq<#YieldInstruction>) = instructions :?> IEnumerator |> behaviour.StartCoroutine