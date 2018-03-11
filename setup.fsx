open System.IO



let rec copyDirectory sourcePath destinationPath =
    let sourceDirectory = DirectoryInfo sourcePath
    Directory.CreateDirectory destinationPath |> ignore
    for sourceFile in sourceDirectory.GetFiles () do sourceFile.CopyTo ((Path.Combine (destinationPath, sourceFile.Name)), true) |> ignore
    for subDirectory in sourceDirectory.GetDirectories () do copyDirectory subDirectory.FullName <| Path.Combine (destinationPath, subDirectory.Name)

let assetPath = Path.Combine ("..", "Assets", "Packages", "Fs")
copyDirectory "Assets" assetPath

let copyDll name subDirectory =
    let fileName = name + ".dll"
    let sourcePath = Path.Combine (name, "bin", "Release", "netstandard2.0", fileName)
    let destinationPath = match subDirectory with Some d -> Path.Combine (assetPath, d, fileName) | None -> Path.Combine (assetPath, fileName)
    File.Copy (sourcePath, destinationPath, true)

copyDll "UnityFs" None
copyDll "UnityFs.Examples" <| Some "Examples"