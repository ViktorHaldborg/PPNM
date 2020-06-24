using System;
class hello{
	static int Main() {
		Console.WriteLine("Hello {0}", Environment.UserName);
		System.Threading.Thread.Sleep(1000);
 		Console.Write(".");
		System.Threading.Thread.Sleep(500);
		Console.Write(".");
		System.Threading.Thread.Sleep(500);
		Console.WriteLine(".");
		System.Threading.Thread.Sleep(1000);
		Console.Write("and welcome!\n");
	
	return 0;}	
}
