


using System.Collections.Generic;

public class DialogText {
  public static Dictionary<DialogTriggerName, List<string>> Dialogs = new Dictionary<DialogTriggerName, List<string>> {
    [DialogTriggerName.FirstInteraction] = new List<string> {
      "Hey, there's granny's house!",
      "Right across that massive gap.",
      "If only I could just jump across! That would be so easy!",
    },

    [DialogTriggerName.SecondInteraction] = new List<string> {
      "OWW.",
      "That was a long way to fall!",
      "Dang it, granny. Why do you have such a huge pit right in front of your house? That seems like a safety hazard.",
    }
  };

  //   { DialogTriggerName.Bed,
  //   new List<string> {
  //     "Yo, I'm a bed.",
  //     "I'm not sure why you're talking to me.",
  //     "I'm just a bed.",
  //     "I'm not even a real bed.",
  //     "I'm just a sprite.",
  //     "I'm not even a sprite.",
  //     "I'm just a bunch of pixels.",
  //     "I'm not even a bunch of pixels.",
  //     "I'm just a bunch of numbers.",
  //     "I'm not even a bunch of numbers.",
  //     "I'm just a bunch of 1s and 0s.",
  //     "I'm not even a bunch of 1s and 0s.",
  //     "I'm just a bunch of electrons.",
  //     "I'm not even a bunch of electrons.",
  //     "I'm just a bunch of quarks.",
  //     "I'm not even a bunch of quarks.",
  //     "I'm just a bunch of strings.",
  //     "I'm not even a bunch of strings.",
  //     "I'm just a bunch of branes.",
  //     "I'm not even a bunch of branes.",
  //     "I'm just a bunch of dimensions.",
  //     "I'm not even a bunch of dimensions.",
  //     "I'm just a bunch of universes.",
  //     "I'm not even a bunch of universes.",
  //     "I'm just a bunch of multiverses.",
  //     "I'm not even a bunch of multiverses.",
  //     "I'm just a bunch of metaverses.",
  //     "I'm not even a bunch of metaverses.",
  //     "I'm just a bunch of megaverses.",
  //     "I'm not even a bunch of megaverses.",
  //     "I'm just a bunch of gigaverses.",
  //     "I'm not even a bunch of gigaverses.",
  //     "I'm just a bunch of teraverses.",
  // }
}