%Определим множество как список без повторяющихся элементов. Найти объединение множеств.

implement main
    open core, console

class predicates
    inList : (integer N [in], integer* L) procedure (i,o) (i,i).
    outList : (integer* L [in]).

clauses
    run() :-
        init(),
        write("Write quantity of numbers in first list: "),
        Nstring1 = readLine(),
        N1 = toTerm(integer, Nstring1),
        nl,
        inList(N1, L1),
        toSet(L1, S1),
        nl,
        write("Your first set: "),
        outList(S1),
        write("Write quantity of numbers in second list: "),
        Nstring2 = readLine(),
        N2 = toTerm(integer, Nstring2),
        nl,
        inList(N2, L2),
        toSet(L2, S2),
        nl,
        write("Your second set: "),
        outList(S2),
        union(S1, S2, R),
        write("Your union set: "),
        outList(R),
        nl,
        write("Tap Enter for quit..."),
        _ = readLine().

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
    isMember : (integer X [in], integer* L [in], integer R [out]).
clauses
    isMember(_, [], 0) :-
        !.

    isMember(H, [H | _], 1) :-
        !.

    isMember(H, [_ | T], R) :-
        isMember(H, T, R).

class predicates
    union : (integer* L1 [in], integer* L2 [in], integer* L3 [out]).
clauses
    union([], L, L) :-
        !.

    union([H | T1], L2, [H | T2]) :-
        isMember(H, L2, R),
        R = 0,
        !,
        union(T1, L2, T2),
        !.

    union([_ | T1], L2, T2) :-
        union(T1, L2, T2),
        !.

class predicates
    toSet : (integer* L [in], integer* S [out]).
clauses
    toSet([], []).

    toSet([H | T1], [H | T2]) :-
        isMember(H, T1, R),
        R = 0,
        !,
        toSet(T1, T2),
        !.

    toSet([_ | T1], T) :-
        toSet(T1, T),
        !.

end implement main

goal
    console::runUtf8(main::run).
