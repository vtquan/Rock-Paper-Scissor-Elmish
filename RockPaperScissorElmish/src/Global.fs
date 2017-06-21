module Global

type Page =
  | Home
  | Counter
  | About
  | RockPaperScissor

let toHash page =
  match page with
  | About -> "#about"
  | Counter -> "#counter"
  | Home -> "#home"
  | RockPaperScissor -> "#rpsgame"
