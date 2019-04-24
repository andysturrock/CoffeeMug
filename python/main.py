import logging
import sys

from coffee_cup import CoffeeCup
from coffee_pot import CoffeePot
from work_task import WorkTask

_LOGGER = logging.getLogger()
_LOGGER.setLevel(logging.INFO)
_LOGGER.addHandler(logging.StreamHandler(sys.stdout))


def log_msg(level, obj, msg):
    """Poor mans log formatter. Logs messages in specific format."""
    if isinstance(obj, CoffeeCup):
        prefix = f"Coffee Cup (vol={obj.volume}mls): %s"
    if isinstance(obj, CoffeePot):
        prefix = f"Coffee Pot (vol={obj.volume}mls): %s"
    if isinstance(obj, WorkTask):
        prefix = f"Task (effort={obj.effort}): %s"
    if level == "info":
        _LOGGER.info(prefix, msg)
    if level == "debug":
        _LOGGER.debug(prefix, msg)
    if level == "error":
        _LOGGER.error(prefix, msg)


def main():
    """Runs main program loop."""
    todo_list = [WorkTask() for i in range(1, 5)]
    coffee_cup = CoffeeCup()
    coffee_pot = CoffeePot()
    coffee_cup_vol = coffee_cup.max_volume
    for idx, task in enumerate(todo_list):
        log_msg("info", task, f"starting task {idx}")
        while not task.done:
            log_msg("info", task, f"working on task {idx}")
            try:
                log_msg("info", coffee_cup, "drinking")
                coffee_cup.drink()
            except ValueError as err:
                log_msg("debug", coffee_cup, err)
                log_msg("info", coffee_cup, "Empty! - refilling")
                try:
                    log_msg("info", coffee_pot, "pouring")
                    coffee_cup.refill(coffee_pot.pour(amount=coffee_cup_vol))
                except ValueError as err:
                    log_msg("debug", coffee_pot, err)
                    log_msg("info", coffee_pot, "Empty! - making more coffee")
                    coffee_pot.make()
                    coffee_cup.refill(coffee_pot.pour(amount=coffee_cup_vol))
            task.execute()


if __name__ == "__main__":
    main()
