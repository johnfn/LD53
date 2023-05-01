


using System.Collections.Generic;

public class DialogText {
  public static Dictionary<DialogTriggerName, List<string>> Dialogs = new Dictionary<DialogTriggerName, List<string>> {
    [DialogTriggerName.FirstInteraction] = new List<string> {
    },

    [DialogTriggerName.SecondInteraction] = new List<string> {
      "I am Robo-Delivery-Unit 3000.",
      "A machine designed to deliver packages.",
      "As far as I know, I am the last of my kind.",
    },

    [DialogTriggerName.SaveStation] = new List<string> {
      "I just activated a Save Station.",
      "If I am to perish, another Robo-Delivery-3000 unit will be constructed here, with all of my memories intact.",
    },

    [DialogTriggerName.OhShootSpikes] = new List<string> {
      "Lava is instanteously fatal.",
    },

    [DialogTriggerName.OhShootCannon] = new List<string> {
      "Most machines were destroyed after the war.",
      "However.",
      "Some machines still receive power.",
      "They remain active.",
      "And hostile.",
    },
  };
}