"""A representation of a cup, designed for coffee."""
from container import LiquidContainer

class CoffeeCup(LiquidContainer):
    """A representation of a cup, designed for coffee."""

    def __init__(self):
        super().__init__(max_volume=250)

    def drink(self, amount=50):
        """Drinks contents of cup."""
        self.volume -= amount

    def refill(self, amount=False):
        """Fills contents of cup."""
        if not amount:
            amount = self.max_volume - self.volume
        self.volume += amount
