namespace Aquariums
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Fish fish = new Fish("test");
            Aquarium aquarium = new Aquarium("Test",10);
            aquarium.Add(fish);
            aquarium.SellFish("test");
            aquarium.SellFish("test");
        }
    }
}
