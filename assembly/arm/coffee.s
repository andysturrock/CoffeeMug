/* -- coffeemug.s */
.data

cup_size: .word 3 
sip_size: .word 1 
task_count: .word 4 
pot_size: .word 6 
 
.text

drink_coffee:
    push {r4, lr}
    ldr r4, address_of_sip_size /* r4 = address_of_sip_size */
    ldr r1, [r4]                /* r0 = *address_of_sip_count */
    ldr r4, address_of_cup_size /* r4 = address_of_cup_size */
    ldr r0, [r4]                /* r0 = *address_of_cup_size */
    sub r0, r0, r1              /* r0 = r0 - r1 */
    str r0, [r4]                /* *address_of_cup_size = r0 */
    b end

execute_task:
    push {r4, lr}
    ldr r4, addr_task_count     /* r4 = address_of_task_count */
    ldr r0, [r4]                /* r0 = *address_of_task_count */
    sub r0, r0, #1              /* r0 = r0 - 1 */
    str r0, [r4]                /* *address_of_task_count = r0 */
    b end

task_done:
    push {r4, lr}
    ldr r4, addr_task_count     /* r4 = address_of_task_count */
    ldr r0, [r4]                /* r0 = *address_of_task_count */
    cmp r0, #0
    b end

coffee_cup_empty:
    push {r4, lr}
    ldr r4, address_of_cup_size /* r4 = address_of_cup_size */
    ldr r0, [r4]                /* r0 = *address_of_task_count */
    cmp r0, #0                  /* r0 == 0 */
    b end

coffee_pot_empty:
    push {r4, lr}
    ldr r4, address_of_pot_size /* r4 = address_of_cup_size */
    ldr r0, [r4]                /* r0 = *address_of_task_count */
    cmp r0, #0                  /* r0 == 0 */
    b end

refill_coffee_cup:
    push {r4, lr}
    ldr r4, address_of_cup_size /* r4 = address_of_cup_size */
    mov r0, #3
    str r0, [r4]
    b end

make_coffee_pot:
    push {r4, lr}
    ldr r4, address_of_pot_size /* r4 = address_of_cup_size */
    mov r0, #6
    str r0, [r4]
    b end

end:
    pop {r4, lr}
    bx lr                       /* Leave  */


.global main
main:
    push {r4, lr}
    task_loop:

        bl drink_coffee
        bl execute_task
        cmp r0, #0              
        beq task_completed              

        bl coffee_cup_empty
        cmp r0, #0
        bne task_loop

        bl coffee_pot_empty
        cmp r0, #0
        beq make_coffee_pot

        bl refill_coffee_cup
        
    b task_loop
    
    task_completed:
        mov r0, #2
        pop {r4, lr}
        bx lr        
        
address_of_cup_size: .word cup_size
address_of_sip_size: .word sip_size
addr_task_count: .word task_count
address_of_pot_size: .word pot_size
