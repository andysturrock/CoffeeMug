"""A representation of a task to be worked on."""
from random import randint


class WorkTask(object):
    """A representation of a task to be worked on."""

    def __init__(self):
        self._completed = False
        self._total_effort = randint(2, 5)
        self._effort = self._total_effort

    @property
    def done(self):
        """Returns completed status of task."""
        return self._completed

    @done.setter
    def done(self, value):
        """Returns completed status of task."""
        if value and self.effort != 0:
            raise ValueError(
                "Task can not be completed when effort is remaining")
        self._completed = value

    @property
    def effort(self):
        """Returns the amount of effort remaining on the task."""
        return self._effort

    @effort.setter
    def effort(self, value):
        """Sets the amount of effort remaining on the task."""
        self._effort = value
        if self._effort > self._total_effort:
            raise ValueError("Effort can't be more than total effort")
        if self._effort <= 0:
            self.done = True

    def execute(self, effort=1):
        """Expends effort towards completing a task."""
        self.effort -= effort
