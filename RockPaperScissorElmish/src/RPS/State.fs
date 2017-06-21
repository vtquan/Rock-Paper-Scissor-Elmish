module RPS.State

open Elmish
open Types

let init () : Model * Cmd<Msg> =
  { Win = 0; Lost = 0; Result = "" }, []

let update msg model : Model * Cmd<Msg> =
  let rnd = System.Random()

  let convertIntToChoice num =
    match num with
    | 1 -> Rock
    | 2 -> Paper
    | _ -> Scissor

  let cpuChoice = rnd.Next(1, 4) |> convertIntToChoice

  match msg, cpuChoice with
  | Rock, Scissor 
  | Paper, Rock
  | Scissor, Paper
    -> { model with Win = model.Win + 1; Result = "You win!" }, [] // You win
  | Rock, Paper
  | Paper, Scissor
  | Scissor, Rock
    -> { model with Lost = model.Lost + 1; Result = "You lose!" }, [] // You lose
  | _ 
    -> { model with Result = "Draw!" }, [] // You draw