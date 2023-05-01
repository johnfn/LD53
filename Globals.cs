using System.Collections.Generic;

public enum LayerMask {
  Wall,
  Spikes,
  Cannonball,
  Portal,
  Ladder
}

public static class Globals {
  public static Dictionary<uint, LayerMask> LayerMasks = new() {
    [1 << 0] = LayerMask.Wall,
    [1 << 1] = LayerMask.Spikes,
    [1 << 2] = LayerMask.Cannonball,
    [1 << 3] = LayerMask.Portal,
    [1 << 4] = LayerMask.Ladder
  };

  public static Dictionary<LayerMask, int> LayerNumbers = new() {
    [LayerMask.Wall] = 1 << 0,
    [LayerMask.Spikes] = 1 << 1,
    [LayerMask.Cannonball] = 1 << 2,
    [LayerMask.Portal] = 1 << 3,
    [LayerMask.Ladder] = 1 << 4,
  };
}