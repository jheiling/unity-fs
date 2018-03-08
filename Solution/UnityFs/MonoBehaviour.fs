module UnityFs.MonoBehaviour

open System.Collections



let inline startCoroutine (routine : seq<_>) = routine :?> IEnumerator