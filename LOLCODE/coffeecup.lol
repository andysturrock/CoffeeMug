HAI 1.2

CAN HAS STDIO?
CAN HAS UNISTD?
CAN HAS STDLIB?

HOW IZ I drink_coffee YR current_cup_size AN YR sip_size
    VISIBLE "Drinking coffee..."
    I IZ UNISTD'Z SLEPE YR 1 MKAY
    VISIBLE "Finished drinking coffee."
    FOUND YR DIFF OF current_cup_size AN sip_size
IF U SAY SO

HOW IZ I coffeeCup_Drink
    VISIBLE "Drinking coffee..."
    I IZ UNISTD'Z SLEPE YR 1 MKAY
    VISIBLE "Finished drinking coffee."
    FOUND YR WIN
IF U SAY SO

HOW IZ I workTask_Execute YR task_count
    VISIBLE "Doing work..."
    I IZ UNISTD'Z SLEPE YR 1 MKAY
    task_count R DIFF OF task_count AN 1
    VISIBLE SMOOSH "Finished doing work with " task_count " bits of work left." MKAY
    FOUND YR task_count
IF U SAY SO

HOW IZ I coffeePot_Make
    VISIBLE "Making coffee..."
    I IZ UNISTD'Z SLEPE YR 1 MKAY
    VISIBLE "Finished making coffee."
    FOUND YR max_pot_size
IF U SAY SO

HOW IZ I coffeeCup_Refill
    VISIBLE "Refilling cup..."
    I IZ UNISTD'Z SLEPE YR 1 MKAY
    VISIBLE "Finished refilling cup."
    FOUND YR FAIL
IF U SAY SO


BTW the number of cups in a pot
I HAS A max_pot_size ITZ A NUMBR
max_pot_size R 3

I HAS A current_pot_size ITZ A NUMBR
current_pot_size R max_pot_size

I HAS A task_count ITZ A NUMBR
task_count R 5

I HAS A coffeeCup_Empty ITZ A TROOF
coffeeCup_Empty R WIN

I HAS A coffeePot_Empty ITZ A TROOF
coffeePot_Empty R WIN

I HAS A workTask_Done ITZ A TROOF
coffeePot_Empty R FAIL

IM IN YR loop
    coffeeCup_Empty R I IZ coffeeCup_Drink MKAY

    task_count R I IZ workTask_Execute YR task_count MKAY

    coffeeCup_Empty, O RLY?
        YA RLY
            coffeePot_Empty R BOTH SAEM current_pot_size AN 0
            coffeePot_Empty, O RLY?
                YA RLY
                    current_pot_size R I IZ coffeePot_Make MKAY
            OIC
            coffeeCup_Empty R I IZ coffeeCup_Refill MKAY
            current_pot_size R DIFF OF current_pot_size AN 1
    OIC
    workTask_Done R BOTH SAEM task_count AN 0
    workTask_Done, O RLY?
        YA RLY
           GTFO
    OIC
IM OUTTA YR loop

KTHXBYE
