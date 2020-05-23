try
    failwith "An error occured"
with
    | Failure msg -> printfn "Failed with %s" msg
