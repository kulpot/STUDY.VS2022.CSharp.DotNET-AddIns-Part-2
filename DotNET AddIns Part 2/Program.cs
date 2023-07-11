using System;
using System.Reflection;
using System.Linq;

//ref link:https://www.youtube.com/watch?v=NSt1yCPVtr8&list=PLRwVmtr-pp05brRDYXh-OTAIi-9kYcw3r&index=15
//  Host Assembly
// IChessGame reference .dll

class MainClass
{
    static void Main()
    {
        Assembly player1Assembly = Assembly.Load("MyChessAlgorithm");
        Assembly player2Assembly = Assembly.Load("YourChessAlgorithm");
        /*Type playerAlgorithmType =
            player1.GetTypes()
            .Single(t => t.GetInterfaces()
            .Any(i => i.GetType()
            .Equals(typeof(IChessGame))));
        IChessGame player1Impl = Activator.CreateInstance(playerAlgorithmType);
        */
        IChessGame player1 = CreatePlayerAlgorithmInstance(player1);
        IChessGame player2 = CreatePlayerAlgorithmInstance(player2);
    }

    private static IChessGame CreatePlayerAlgorithmInstance(Assembly player1)
    {
        Type playerAlgorithmType =
            player1.GetTypes()
            .Single(t => t.GetInterfaces()
                        .Any(i => i.GetType()
                            .Equals(typeof(IChessGame))));
        return Activator.CreateInstance(playerAlgorithmType);
    }
}