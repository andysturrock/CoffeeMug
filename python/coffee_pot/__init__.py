"""A representation of a coffee pot."""
from container import LiquidContainer

class CoffeePot(LiquidContainer):
    """A representation of a pot, designed for brewing coffee."""

    def __init__(self):
        super().__init__(self)

    def pour(self, amount=100):
        """Pours contents of pot."""
        self.volume -= amount

    def make(self, amount=100):
        """Makes an amount of Coffee in the pot."""
        self.volume += amount
