


using System.Collections.Generic;

public class DialogText {
  public static Dictionary<DialogTriggerName, List<string>> Dialogs = new Dictionary<DialogTriggerName, List<string>> {
    [DialogTriggerName.FirstInteraction] = new List<string> {
    },
    [DialogTriggerName.SecondInteraction] = new List<string> {
      "Robo-Delivery-Unit 3000's log.",
      "Entry: Day 184,821.",
      "I continue to carry out my routine deliveries.",
      "It has been 182,102 days since the last time I've seen another Robo-Delivery-Unit.",
    },

    [DialogTriggerName.SaveStation] = new List<string> {
      "Log continuation: I found an interesting device today.",
      "It's labelled as a 'Save Station'.",
      "My memory banks claim that, if I am to perish, it will construct another Robo-Delivery-3000 unit here, with all of my memories intact.",
      "I wonder if I can trust it.",
    },

    [DialogTriggerName.OhShootSpikes] = new List<string> {
      "Log continuation: For reasons I cannot explain, I diverted from my usual route today.",
      "While exploring, I came across some lava.",
      "I was careful to avoid it.",
    },

    [DialogTriggerName.OhShootCannon] = new List<string> {
      "Log continuation: My diversion took me near an active cannon.",
      "I was unaware that active cannons were still in the area.",
      "Most were destroyed, or deactivated, after the war.",
    },

    [DialogTriggerName.FirstPortal] = new List<string> {
      "Log continuation: I've found what appears to be a spatial anomaly.",
      "I have never seen anything like it before.",
      "It appears that a square section of the world has been cloned elsewhere.",
      "I can travel between these cloned worlds by pressing 'E'.",
      "How this is possible, I do not know."
    },

    [DialogTriggerName.SecondPortal] = new List<string> {
      "Log continuation: I have found another spatial anomaly, similar to the previous one.",
      "This one has a notable unique characteristic.",
      "It appears that obstacles have been copied over from the other side of the anomaly.",
      "If one side of the Rift is impassable, perhaps the other side offers a way through.",
    },

    [DialogTriggerName.CantMakeIt] = new List<string> {
      "Log continuation: That looks too far for me to safely jump across.",
      "Maybe there's some other way.",
    },

    [DialogTriggerName.GetVortexGun] = new List<string> {
      "Log continuation: I have made a major discovery today.",
      "This appears to be a device that can create a Dimensional Rift.",
      "First, I need to link it to a Mailbox.",
      "I can do that by pressing E when I've found one."
    },

    [DialogTriggerName.LinkMailbox] = new List<string> {
      "I have linked the Rift Gun to this Mailbox.",
      "Now, I can copy the area around the Mailbox to a new location by clicking the mouse.",
      "Once I've done that, I can warp between the two locations by pressing E.",
    },

    [DialogTriggerName.LostLink] = new List<string> {
      "According to my sensors, the red area will cause any link from my Rift Gun to a Mailbox to be lost.",
      "I should be careful.",
      "But I am hopeful that if I proceed, I will find more mailboxes to link with."
    },

    [DialogTriggerName.NowWhatDoIDo] = new List<string> {
      "Hmm. There is no clear path forward.",
      "My sensors indicate that there may be paths beneath the ground.",
      "But how do I get to them?"
    },

    [DialogTriggerName.PhewFinallyOut] = new List<string> {
      "Phew, finally I made it out of there.",
      "I was starting to feel a little claustrophobic.",
      "I wonder what's next?",
      "JOHNFN: LITERALLY NOTHING, THE GAME IS OVER. GOODBYE.",
      "JOHNFN: ...",
      "JOHNFN: ...",
      "JOHNFN: ...",
      "JOHNFN: That's it. That's the end of the game.",
      "JOHNFN: Thanks for playing!",
    },
  };
}