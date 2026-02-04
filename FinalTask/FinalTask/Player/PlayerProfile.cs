namespace FinalTask.Player
{
    internal class PlayerProfile
    {
        public string Name { get; }
        public int Bank { get; set; }

        public PlayerProfile(string name, int bank) 
        {
            if(name ==  null) 
                throw new ArgumentNullException("Name should not be empty");
            if (bank == 0) 
                throw new ArgumentOutOfRangeException("Bank must be greater than 0");
            Name = name;
            Bank = bank;
        }
    }
}
