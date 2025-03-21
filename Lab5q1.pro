implement main
    open core, console

class predicates
    quantityOfDigits : (integer N, integer R [out]).
    printResult : (integer N1 [in], integer N2 [in]).

clauses
    run() :-
        init(),
        write("Write first integer number: "),
        Nstring1 = readLine(),
        N1 = toTerm(integer, Nstring1),
        nl,
        write("Write second integer number: "),
        Nstring2 = readLine(),
        N2 = toTerm(integer, Nstring2),
        nl,
        quantityOfDigits(N1, R1),
        quantityOfDigits(N2, R2),
        writef("Quntity of digits in first number: %\n", R1),
        writef("Quntity of digits in second number: %", R2),
        nl,
        printResult(R1, R2),
        write("Tap Enter for quit..."),
        _ = readLine().

    quantityOfDigits(N, R) :-
        quantityOfDigits(N, 0, R).

    printResult(R1, R2) :-
        R1 > R2,
        write("Quantity of digits in first number is bigger than in second\n"),
        !.

    printResult(R1, R2) :-
        R1 < R2,
        write("Quantity of digits in second number is bigger than in first\n"),
        !.

    printResult(_, _) :-
        write("Quantity of digits in first and second numbers are equal\n"),
        !.

class predicates
    quantityOfDigits : (integer N, integer Q, integer R) procedure (i,i,o) (i,i,i).
clauses
    quantityOfDigits(0, 0, R) :-
        quantityOfDigits(0, 1, R),
        !.
    quantityOfDigits(0, Q, Q) :-
        !.
    quantityOfDigits(0, Q, _) :-
        quantityOfDigits(0, Q, Q),
        !.

    quantityOfDigits(N, 0, R) :-
        N < 0,
        New = -N,
        quantityOfDigits(New, 0, R),
        !.

    quantityOfDigits(N, Q, R) :-
        New = N div 10,
        NQ = Q + 1,
        quantityOfDigits(New, NQ, R),
        !.

end implement main

goal
    console::runUtf8(main::run).
