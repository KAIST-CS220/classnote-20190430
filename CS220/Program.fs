type BankAccount = {
  GetBalance: unit -> int
  Deposit: int -> unit
}
module BankAccount =
  let create () =
    let mutable balance = 0
    { GetBalance = fun () -> balance
      Deposit = fun m -> balance <- balance + m }

type BankAccount2 () =
  let mutable balance = 0
  member __.GetBalance () = balance
  member __.Deposit amount =
    balance <- balance + amount

[<EntryPoint>]
let main argv =
  let acc1 = BankAccount.create ()
  let acc2 = BankAccount.create ()
  let acc3 = BankAccount2 ()
  // let getBalance ba = ba.Balance
  acc1.Deposit 100
  acc2.Deposit 1000
  acc1.Deposit 100
  acc3.Deposit 100
  printfn "Acc1: %d, Acc2: %d" (acc1.GetBalance ())
                               (acc2.GetBalance ())
  printfn "Acc3: %d" (acc3.GetBalance ())

  /// MyObjectInstance.MyProperty <- 42

  0 // return an integer exit code
