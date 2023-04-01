module AssertionFramework =
    open System
    let useAssertions (foo: _ -> _) =
        try
            (foo())
        with 
            | ex -> printfn($"{ex.Message}")

    let asserT ((condition: bool, description: string)) =
        if not condition then
            raise (new Exception($"FAILED: {description}"))
            Environment.Exit(1)
    
    let isNot (x: int, a: int) =
        let description = $"{x} is not {a}"
        if(x <> a) then
            (true, description)
        else (false, description)

    let is (x: int, a: int) =
        let description = $"{x} is {a}"
        if(x = a) then 
            (true, description)
        else (false, description)
        
    let isGreaterOrEqual (x: int, a: int) =
        let description = $"{x} is greater than or equal to {a}"
        if(x >= a) then
            (true, description)
        else
            (false, description)

    let isGreater (x: int, a: int) =
        let description = $"{x} is greater than {a}"
        if(x > a) then
            (true, description)
        else
            (false, description)
    
    let isLessOrEqual (x: int, a: int) =
        let description = $"{x} is less than or equal to {a}"
        if(x <= a) then
            (true, description)
        else
            (false, description)

    let isLess (x: int, a: int) =
        let description = $"{x} is less than {a}"
        if(x < a) then
            (true, description)
        else
            (false, description)


open AssertionFramework

let foo () = 
    asserT((is(2, 2)))
    asserT(isNot(3, 4))
    asserT(isGreaterOrEqual(3, 2))
    asserT(isLessOrEqual(4, 4))
    asserT(isLess(2, 3))
    asserT(isGreater(3, 4))

useAssertions(foo)
