module RPS.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types

let simpleButton txt action dispatch =
  div
    [ ClassName "column is-narrow" ]
    [ a
        [ ClassName "button"
          OnClick (fun _ -> action |> dispatch) ]
        [ str txt ] ]

let root model dispatch =
  div
    [ ClassName "content" ]
    [ h1
        [ ]
        [ str "Rock Paper Scissor Game" ]
      p
        [ ]
        [ str "Pick your selection!" ]
      br []
      simpleButton "Rock" Rock dispatch
      simpleButton "Paper" Paper dispatch
      simpleButton "Scissor" Scissor dispatch
      p
        []
        [ str (sprintf "Result: %s" model.Result)]
      p
        []
        [ str (sprintf "Game Stats: %i Wins, %i Lost" model.Win model.Lost) ] ]