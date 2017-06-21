module RPS.Types

type Model = { Win : int; Lost : int; Result: string }

type Msg =
  | Rock
  | Paper
  | Scissor