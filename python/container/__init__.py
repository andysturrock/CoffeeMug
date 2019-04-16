"""A representation of various containers."""


class LiquidContainer(object):
    """A representation of a container that contains liquid."""

    def __init__(self, max_volume=100):
        self._max_volume = max_volume
        self._volume = 0

    @property
    def max_volume(self):
        """Returns container maximum volume in mls."""
        return self._max_volume

    @max_volume.setter
    def max_volume(self, value):
        """Sets container maximum volume in mls."""
        self._max_volume = value

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
        return self._volume == self.max_volume

    @volume.setter
    def volume(self, value=100):
        if value < 0:
            value = 0
            raise ValueError("A volume of less than 0 is not possible")
        if value > self._max_volume:
            value = self._max_volume
            raise ValueError("Container has overflowed!")
        self._volume = value
