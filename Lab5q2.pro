%Найти сумму тех элементов списка, которые оканчиваются на заданную цифру

implement main
    open core, console

class predicates
    sum : (integer* L [in], integer N [in], integer R [out]).
    inList : (integer N [in], integer* L) procedure (i,o) (i,i).
    outList : (integer* L [in]).

clauses
    run() :-
        %L1 = [1, 2, 3, 4, 5, 6, 11],
        init(),
        write("Write quantity of numbers in list: "),
        Nstring1 = readLine(),
        N1 = toTerm(integer, Nstring1),
        nl,
        inList(N1, L2),
        nl,
        write("Your list:"),
        outList(L2),
        write("Write digit which would end the numbers of sum: "),
        Nstring2 = readLine(),
        N2 = toTerm(integer, Nstring2),
        nl,
        sum(L2, N2, R),
        writef("Result: %", R),
        nl,
        write("Tap Enter for quit..."),
        _ = readLine().

    sum(L, N, R) :-
        sum(L, N, 0, R),
        !.

    inList(0, []) :-
        !.

    inList(0, _) :-
        inList(0, []),
        !.

    inList(N, R) :-
        N < 0,
        inList(0, R),
        !.

    inList(N, [H | T]) :-
        write("Enter new number in list: "),
        Nstring1 = readLine(),
        H = toTerm(integer, Nstring1),
        !,
        New = N - 1,
        inList(New, T),
        !.

    inList(N, L) :-
        New = N - 1,
        inList(New, L),
        !.

    outList(L) :-
        outList(L, 0).

class predicates
    outList : (integer* L [in], integer M [in]).
clauses
    outList([], 1) :-
        write("]\n"),
        !.

    outList([N | T], 0) :-
        writef("[%", N),
        outList(T, 1),
        !.

    outList([N | T], 1) :-
        writef(", %", N),
        outList(T, 1),
        !.

    outList(_, _) :-
        !.

class predicates
    sum : (integer* L [in], integer N [in], integer Q [in], integer R) procedure (i,i,i,o) (i,i,i,i).
clauses
    sum([], _, Q, Q) :-
        !.

    sum([], N, Q, _) :-
        sum([], N, Q, Q),
        !.

    sum([H | L], N, Q, R) :-
        H < 10,
        NewH = -H,
        NewH mod 10 = N,
        New = Q + H,
        sum(L, N, New, R),
        !.

    sum([H | L], N, Q, R) :-
        H mod 10 = N,
        New = Q + H,
        sum(L, N, New, R),
        !.

    sum([_ | L], N, Q, R) :-
        sum(L, N, Q, R),
        !.

end implement main

goal
    console::runUtf8(main::run).
