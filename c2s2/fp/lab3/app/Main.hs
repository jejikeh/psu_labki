module Main where

main :: IO ()
main = print (sign 0)


sign :: Int -> Int
sign x
  | x == 0 = 0
  | x > 0 = 1
  | otherwise = -1
