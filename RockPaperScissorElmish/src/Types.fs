module App.Types

open Global

type Msg =
  | CounterMsg of Counter.Types.Msg
  | HomeMsg of Home.Types.Msg
  | GameMsg of RPS.Types.Msg

type Model = {
    currentPage: Page
    counter: Counter.Types.Model
    home: Home.Types.Model
    game: RPS.Types.Model
  }
