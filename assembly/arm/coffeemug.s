/* -- coffeemug.s */
.data

cup_size: .word 3 
sip_size: .word 1 
task_count: .word 4 
pot_size: .word 6 
 
.text

drink_coffee:
    str lr, [sp,#-4]!           /* Push lr onto the top of the stack */
    str r4, [sp,#-4]!           /* Push r4 onto the top of the stack */
                                /* The stack is now 8 byte aligned */
    ldr r4, address_of_sip_size /* r4 = address_of_sip_size */
    mov r1, [r4]                /* r0 = *address_of_sip_count */
    ldr r4, address_of_cup_size /* r4 = address_of_cup_size */
    ldr r0, [r4]                /* r0 = *address_of_cup_size */
    sub r0, r0, r1              /* r0 = r0 - r1 */
    str r0, [r4]                /* *address_of_cup_size = r0 */
    b end

execute_task:
    str lr, [sp,#-4]!           /* Push lr onto the top of the stack */
    str r4, [sp,#-4]!           /* Push r4 onto the top of the stack */
                                /* The stack is now 8 byte aligned */
    ldr r4, address_task_count     /* r4 = address_of_task_count */
    ldr r0, [r4]                /* r0 = *address_of_task_count */
    sub r0, r0, #1              /* r0 = r0 - 1 */
    str r0, [r4]                /* *address_of_task_count = r0 */
    b end

task_done:
    str lr, [sp,#-4]!           /* Push lr onto the top of the stack */
    str r4, [sp,#-4]!           /* Push r4 onto the top of the stack */
                                /* The stack is now 8 byte aligned */

    ldr r4, address_task_count     /* r4 = address_of_task_count */
    ldr r0, [r4]                /* r0 = *address_of_task_count */
    cmp r0, #0
    b end

coffee_cup_empty:
    str lr, [sp,#-4]!           /* Push lr onto the top of the stack */
    str r4, [sp,#-4]!           /* Push r4 onto the top of the stack */
                                /* The stack is now 8 byte aligned */
    ldr r4, address_of_cup_size /* r4 = address_of_cup_size */
    ldr r0, [r4]                /* r0 = *address_of_task_count */
    cmp r0, #0                  /* r0 == 0 */
    b end

coffee_pot_empty:
    str lr, [sp,#-4]!           /* Push lr onto the top of the stack */
    str r4, [sp,#-4]!           /* Push r4 onto the top of the stack */
                                /* The stack is now 8 byte aligned */
    ldr r4, address_of_pot_size /* r4 = address_of_cup_size */
    ldr r0, [r4]                /* r0 = *address_of_task_count */
    cmp r0, #0                  /* r0 == 0 */
    b end

refill_coffee_cup:
    str lr, [sp,#-4]!           /* Push lr onto the top of the stack */
    str r4, [sp,#-4]!           /* Push r4 onto the top of the stack */
    ldr r4, address_of_cup_size /* r4 = address_of_cup_size */
    mov r0, #3
    str r0, [r4]
    b end

make_coffee_pot:
    str lr, [sp,#-4]!           /* Push lr onto the top of the stack */
    str r4, [sp,#-4]!           /* Push r4 onto the top of the stack */
    ldr r4, address_of_pot_size /* r4 = address_of_cup_size */
    mov r0, #6
    str r0, [r4]
    b end

end:
    ldr r4, [sp], #+4           /* Pop the top of the stack and put it in r4 */
    ldr lr, [sp], #+4           /* Pop the top of the stack and put it in lr */
    bx lr                       /* Leave  */


.global main
main:
        str lr, [sp,#-4]!       /* Push lr onto the top of the stack */
        sub sp, sp, #4          /* Make room for one 4 byte integer in the stack */

    task_loop:

        b drink_coffee
        b execute_task
        cmp r0, #0              
        beq task_completed              

        b coffee_cup_empty
        cmp r0, #0
        bne task_loop

        b coffee_pot_empty
        cmp r0, #0
        beq make_coffee_pot

        b refill_coffee_cup
        
    b task_loop
    
    task_completed:
        mov r0, #2                   /* return value $? of the program */
        add sp, sp, #+4              /* Discard the integer read by scanf */
        ldr lr, [sp], #+4            /* Pop the top of the stack and put it in lr */
        bx lr                        /* Leave main */
    
address_of_cup_size: .word cup_size
address_of_sip_size: .word sip_size
address_task_count: .word task_count
address_of_pot_size: .word pot_size