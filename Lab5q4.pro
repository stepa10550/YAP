implement main
    open core, console

domains
    prib = string.

class facts
    itog : (prib).

class predicates
    check1 : (prib A [in], prib B [in], prib C [in], integer Q [out]) nondeterm.
    check2 : (prib A [in], prib B [in], prib C [in], integer Q [out]) nondeterm.
    check3 : (prib A [in], prib B [in], prib C [in], integer Q [out]) nondeterm.
    vyvRool : (integer A [in], integer B [in], integer C [in]) nondeterm.
    vyvRool1 : (integer N [in]) nondeterm.

clauses
    itog("Max").
    itog("Min").

    check1("Max", "Max", "Max", 1).

    check1("Min", B, C, 1) :-
        B <> C.

    check1("Min", "Min", "Min", 1).

    check1("Max", B, C, 0) :-
        B <> C.

    check1("Max", "Min", "Min", 0).

    check1("Min", "Max", "Max", 0).

    check2(A, _, A, 1).

    check2(A, _, C, 0) :-
        A <> C.

    check3(_, B, B, 1).

    check3(_, "Max", "Min", 1).

    check3(_, "Min", "Max", 0).

    vyvRool(1, 1, 0) :-
        write("Third fact is incorrect\n").

    vyvRool(1, 0, 1) :-
        write("Second fact is incorrect\n").

    vyvRool(0, 1, 1) :-
        write("First fact is incorrect\n").

    vyvRool(A, B, C) :-
        A <> 0,
        B <> 1,
        C <> 1
        or
        A <> 1,
        B <> 0,
        C <> 1
        or
        A <> 1,
        B <> 1,
        C <> 0,
        !.

    vyvRool1(1) :-
        write("is True").

    vyvRool1(N) :-
        N <> 1,
        write("is False").

    run() :-
        itog(A),
        itog(B),
        itog(C),
        write("If companies have these profit: A - ", A, ", B - ", B, ", C - ", C, "\n"),
        check1(A, B, C, R1),
        check2(A, B, C, R2),
        check3(A, B, C, R3),
        write("Then first fact "),
        vyvRool1(R1),
        write(", second fact "),
        vyvRool1(R2),
        write(", third fact "),
        vyvRool1(R3),
        nl,
        R1 + R2 + R3 = R4,
        writef("Number of true facts is %", R4),
        nl,
        nl,
        R1 + R2 + R3 = 2,
        vyvRool(R1, R2, R3),
        write("A - ", A, ", B - ", B, ", C - ", C),
        nl,
        fail
        or
        succeed,
        nl,
        write("Tap eny key to close program...\n"),
        _ = readLine().

end implement main

goal
    console::runUtf8(main::run).
