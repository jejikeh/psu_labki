module Main where

main :: IO ()
main = print(lenVec3 2 3 6)


lenVec3 :: Float -> Float -> Float -> Float
lenVec3 x y z = sqrt(x^2 + y^2 + z^2) 
