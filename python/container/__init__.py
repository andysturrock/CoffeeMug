"""A representation of various containers."""


class LiquidContainer(object):
    """A representation of a container that contains liquid."""

    def __init__(self):
        self._volume = 0

    @property
    def empty(self):
        """Returns container empty status."""
        return self._volume == 0

    @property
    def volume(self):
        """Returns current volume of liquid in the container."""
        return self._volume

    @property
    def full(self):
        """Returns container full status."""
        return self._volume == 100

    @volume.setter
    def volume(self, value=100):
        if value < 0:
            raise ValueError("A volume of less than 0% is not possible")
        if value > 100:
            value = 100
            raise ValueError("Container has overflowed!")
        self._volume = value
