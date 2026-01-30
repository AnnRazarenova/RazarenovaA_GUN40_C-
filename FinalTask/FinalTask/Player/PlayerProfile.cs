namespace FinalTask.Player
{
    internal class PlayerProfile
    {
        public string Name { get; }
        public int Bank { get; set; }

        public PlayerProfile(string name, int bank) 
        {
            Name = name;
            Bank = bank;
        }
    }
}
