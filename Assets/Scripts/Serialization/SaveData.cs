// The SaveData class contains all the information that will be stored in a file.
[System.Serializable]
public class SaveData {
    // Variables (public for use in other scripts; could make getters for them)
    // Player Stats
    public PlayerProfile profile; // contains player name, gold, and experience
    public int health;
    public int mana;
    public int maxHealth;
    public int maxMana;
    public int attackDMG;
    public int magicDMG;
    public int defense;
    public int agility;
    public int strength;
    public int intelligence;
    public int constitution;
    public int wisdom;
    public int celerity;
    // Other
    public string currentGameState;

    // I tried to use a List/Dictionary for all of the stats, however I couldn't find a way to
    // make it work and actually save and load. Will revist later.

    public SaveData (Player player, GameState gameState) {
        // This makes it so that when we create a SaveData 'object', it auto loads all the current
        // info into the variables so we don't have to do it later.
        profile = player.profile;
        maxHealth = player.stats.maxHealth;
        maxMana = player.stats.maxMana;
        health = player.stats.health;
        mana = player.stats.mana;
        // this hurts to look at, need to figure out why the list from before did not work
        attackDMG = player.stats.ReturnStat("attackDMG");
        magicDMG = player.stats.ReturnStat("magicDMG");
        defense = player.stats.ReturnStat("defense");
        agility = player.stats.ReturnStat("agility");
        strength = player.stats.ReturnStat("strength");
        intelligence = player.stats.ReturnStat("intelligence");
        constitution = player.stats.ReturnStat("constitution");
        wisdom = player.stats.ReturnStat("wisdom");
        celerity = player.stats.ReturnStat("celerity");

        currentGameState = gameState.GetCurrentState();
    }
}
