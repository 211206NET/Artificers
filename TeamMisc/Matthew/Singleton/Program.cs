using singleNS;

Singleton fromTeachaer = Singleton.GetInstance;
fromTeachaer.PrintDetails("From Teacher");
Singleton fromStudent = Singleton.GetInstance;
fromStudent.PrintDetails("From Student");
Console.ReadLine();
// Singleton s2 = Singleton.GetInstance();

// if (s1 == s2)
// {
//     Console.WriteLine("Singleton works, both variables contain the same instance.");
// }
// else
// {
//     Console.WriteLine("Singleton failed, variables contain different instances.");
// }