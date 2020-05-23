#r "Composer/packages/FsCheck.2.0.7/lib/net45/FsCheck.dll"
open FsCheck

let appendedListLength l1 l2 = 
    (l1 @ l2).Length = l1.Length + 1
    
Check.Quick appendedListLength 
