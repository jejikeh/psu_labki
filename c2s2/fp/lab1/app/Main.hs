module Main where

import qualified SumSquares (sumsquares)

main :: IO ()
main = do
  print(SumSquares.sumsquares 5 6)
