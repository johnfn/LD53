


using System.Collections.Generic;

public class DialogText {
  public static Dictionary<DialogTriggerName, List<string>> Dialogs = new Dictionary<DialogTriggerName, List<string>> {
    [DialogTriggerName.FirstInteraction] = new List<string> {
    },

    [DialogTriggerName.SecondInteraction] = new List<string> {
      "You are a Robo-Delivery-Unit 3000.",
      "You are the last of your kind.",
    },

    [DialogTriggerName.SaveStation] = new List<string> {
      "You have just activated a Save Station.",
      "If you are to perish, another Robo-Delivery-3000 unit will be constructed here, with all of your memories.",
    },

    [DialogTriggerName.OhShootSpikes] = new List<string> {
      "Lava is instanteously fatal to Robo-Delivery-Units.",
      "",
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