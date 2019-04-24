"""A representation of a coffee pot."""
from container import LiquidContainer

class CoffeePot(LiquidContainer):
    """A representation of a pot, designed for brewing coffee."""

    def __init__(self):
        super().__init__(max_volume=500)

    def pour(self, amount=False):
        """Pours contents of pot."""
        if not amount:
            amount = self.max_volume
        self.volume -= amount
        return amount

    def make(self, amount=False):
        """Makes an amount of Coffee in the pot."""
        if not amount:
            amount = self.max_volume - self.volume
        self.volume += amount
        return amount
