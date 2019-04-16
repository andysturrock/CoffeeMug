"""A representation of a cup, designed for coffee."""
from container import LiquidContainer

class CoffeeCup(LiquidContainer):
    """A representation of a cup, designed for coffee."""

    def __init__(self):
        super().__init__(self)

    def drink(self, amount=20):
        """Drinks contents of cup."""
        self.volume -= amount

    def refill(self, amount=100):
        """Fills contents of cup."""
        self.volume += amount
