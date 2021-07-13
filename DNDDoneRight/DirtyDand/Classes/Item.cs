namespace DirtyDand.Classes
{
    public class Item
    {
        public int value { get; set; }
        public string name { get; set; }
        public string discription { get; set; }

        public Item(string name, string discription, int value = 0)
        {
            this.name = name;
            this.discription = discription;
            this.value = value;
        }
    }
}
