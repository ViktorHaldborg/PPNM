using System;
using System.IO;
using static System.Math;
using static System.Console;
using System.Diagnostics;
using static RNG;
using static JacobiDiagonalization1;
class main{public static void Main(){	
		
		// Operation time full sweeps
		using(StreamWriter Write=new StreamWriter("Time.txt")){
		// Quite time heavy so code is suppressed after first run:
		for(int k=10; k<300; k=k+50){
		var time=new Stopwatch();
		int n=k;
		matrix V = new matrix(n,n); vector e=new vector(n);
		matrix A = new matrix(n,n);
		for(int i=0; i<n; i=i+1){for(int j=i; j<n; j=j+1){if(i==j){A[i,j]=RandomDouble(-50,50);} else{A[i,j]=RandomDouble(-50,50); A[j,i]=A[i,j];}}}
		// Diagonalization
		time.Start();
		int sweeps=JacobiDiag(A,e,V);
		time.Stop();
		Write.WriteLine($"{n} {time.ElapsedMilliseconds} {sweeps} {Pow(n,3)/10000}");}

}}}
