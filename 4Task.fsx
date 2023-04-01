let delay f = 
    fun () -> f

let force d = 
    d ()

let rec myIf cond tExpr fExpr =
    match cond with
    | true -> delay tExpr |> force
    | false -> delay fExpr |> force

let x = 10
let y = 20
let result = myIf (x > y) "x is greater than y" "x is not greater than y"

printfn "%s" result