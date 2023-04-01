open System.IO
open System.Text.Json

let writeData data filePath =
    File.WriteAllText(filePath, JsonSerializer.Serialize(data))

let readData filePath =
    JsonSerializer.Deserialize(File.ReadAllText(filePath))

let countNonEmptyLines filePath =
    use streamReader = new StreamReader $"{filePath}"
    let mutable count = 0
    while not streamReader.EndOfStream do
        let line = streamReader.ReadLine()
        if not (System.String.IsNullOrWhiteSpace(line)) then
            count <- count + 1
    count

type Person = {
    Name: string
    LastName: string
}

let john = { Name = "Danila"; LastName = "Uprivanov" }

writeData john "person.json"

let readedPerson = readData "person.json" 
printfn "Readed person: %s %s" readedPerson.Name readedPerson.LastName


let filePath = "testCount.txt"
File.WriteAllText(filePath, "first line\nsecond line\nthird line")

let count = countNonEmptyLines filePath
printfn "Number of non-empty lines: %d" count // Выведет 3