let rec tribonacci n =
    match n with
    | 0 -> 0
    | 1 -> 0
    | 2 -> 1
    | _ -> tribonacci (n - 1) + tribonacci (n - 2) + tribonacci (n - 3)

let tribonacciMemo n =
    let memo = Array.zeroCreate (n + 1)
    let rec trib n =
        match n with
        | 0 -> 0
        | 1 -> 0
        | 2 -> 1
        | _ ->
            if memo.[n] = 0 then
                memo.[n] <- trib (n - 1) + trib (n - 2) + trib (n - 3)
            memo.[n]
    trib n

let n = 30

let timeWithoutMemo = 
    let stopwatch = System.Diagnostics.Stopwatch.StartNew()
    let result = tribonacci n
    stopwatch.Stop()
    result, stopwatch.ElapsedMilliseconds

let timeWithMemo = 
    let stopwatch = System.Diagnostics.Stopwatch.StartNew()
    let result = tribonacciMemo n
    stopwatch.Stop()
    result, stopwatch.ElapsedMilliseconds

printfn "Without memoization: result=%d, time=%dms" (fst timeWithoutMemo) (snd timeWithoutMemo)
printfn "With memoization: result=%d, time=%dms" (fst timeWithMemo) (snd timeWithMemo)