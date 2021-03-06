module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map About (s "about")
    map Counter (s "counter")
    map Home (s "home")
    map RockPaperScissor (s "rpsgame")
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url")
    model,Navigation.modifyUrl (toHash model.currentPage)
  | Some page ->
      { model with currentPage = page }, []

let init result =
  let (counter, counterCmd) = Counter.State.init()
  let (home, homeCmd) = Home.State.init()
  let (game, gameCmd) = RPS.State.init()
  let (model, cmd) =
    urlUpdate result
      { currentPage = Home
        counter = counter
        game = game        
        home = home }
  model, Cmd.batch [ cmd
                     Cmd.map CounterMsg counterCmd
                     Cmd.map GameMsg gameCmd
                     Cmd.map HomeMsg homeCmd ]

let update msg model =
  match msg with
  | CounterMsg msg ->
      let (counter, counterCmd) = Counter.State.update msg model.counter
      { model with counter = counter }, Cmd.map CounterMsg counterCmd
  | GameMsg msg ->
      let (game, gameCmd) = RPS.State.update msg model.game
      { model with game = game }, Cmd.map GameMsg gameCmd
  | HomeMsg msg ->
      let (home, homeCmd) = Home.State.update msg model.home
      { model with home = home }, Cmd.map HomeMsg homeCmd
