#r "fsharp.data/lib/net40/FSharp.Data.dll"
open FSharp.Data

let landings = CsvProvider<"Meteorite_Landings.csv",Schema = ",,,,,,date?">.GetSample()

let landingsWithYears = 
    landings.Rows
    |> Seq.filter (fun r -> 
                    r.Year.HasValue 
                    && not (System.Double.IsNaN(r.``Mass (g)``))
                    && r.Year.Value.Year > 1770)

landingsWithYears  
  |> Seq.sortByDescending (fun r -> r.``Mass (g)``)
  |> Seq.map (fun r -> (r.Year,r.Name, r.``Mass (g)``)) 
  |> List.ofSeq
  |> printfn "%A"

#load "fsharp.charting/FSharp.Charting.fsx"
open FSharp.Charting
landingsWithYears
  |> Seq.sortBy (fun r -> r.Year.Value)
  |> Seq.groupBy (fun r -> r.Year.Value.Year)
  |> Seq.map (fun (year,group) ->
                let largestByYear = group |> Seq.maxBy (fun r -> r.``Mass (g)``)
                (year, largestByYear.``Mass (g)``/1000.))
  |> Chart.Line
   