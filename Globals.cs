using System.Collections.Generic;

public enum LayerMask {
  Wall,
  Spikes,
  Cannonball
}

public static class Globals {
  public static Dictionary<uint, LayerMask> LayerMasks = new() {
    [0 << 1] = LayerMask.Wall,
    [1 << 1] = LayerMask.Spikes,
    [2 << 1] = LayerMask.Cannonball
  };

  public static Dictionary<LayerMask, int> LayerNumbers = new() {
    [LayerMask.Wall] = 0 << 1,
    [LayerMask.Spikes] = 1 << 1,
    [LayerMask.Cannonball] = 2 << 1
  };
}