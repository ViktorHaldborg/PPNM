using System;
using System.IO;
using static System.Math;
using static System.Console;
using System.Diagnostics;
using static RNG;
using static JacobiDiagonalizationCyclic;
class main{public static void Main(){		
		
		// Operation time cyclic
		using(StreamWriter Write=new StreamWriter("TimeCyclic.txt")){
			
		for(int k=10; k<300; k=k+70){
		var time=new Stopwatch();
		int n=k;
		matrix V = new matrix(n,n); vector e=new vector(n);
		matrix A = new matrix(n,n); int c=A.size1;
		for(int i=0; i<n; i=i+1){for(int j=i; j<n; j=j+1){if(i==j){A[i,j]=j;} else{A[i,j]=-j; A[j,i]=A[i,j];}}}
		// Diagonalization
		time.Start();
		int sweeps=JacobiDiag(A,e,V);
		time.Stop();
		Write.WriteLine($"{n} {time.ElapsedMilliseconds} {sweeps} {(Pow(n,2))/10}");}}


	
}}
