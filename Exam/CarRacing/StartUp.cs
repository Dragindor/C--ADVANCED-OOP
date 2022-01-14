namespace CarRacing
{
    using Core;
    using Core.Contracts;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
