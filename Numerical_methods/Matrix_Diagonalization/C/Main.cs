using System;
using System.IO;
using static System.Math;
using static System.Console;
using System.Diagnostics;
using static JacobiDiagonalizationClassic;
using static RNG;
class main{public static void Main(){
 		// Classical jacobi algorithm
		for(int l=0; l<1; l=l+10){
		int n=RandomInt(4,5);
		matrix A = new matrix(n,n);
		for(int i=0; i<n; i=i+1){for(int j=i; j<n; j=j+1){if(i==j){A[i,j]=RandomDouble(5,20);} else{A[i,j]=RandomDouble(5,20); A[j,i]=A[i,j];}}}
		A.print("Randomly generated symmetric square matrix A=\n");
		matrix A_2=A.copy(); matrix V = new matrix(n,n); vector e=new vector(n);
		// Diagonalization
		int rots=JacobiDiag(A,e,V);
		A.print("\nD=\n");
		matrix A1=V.T*A_2*V;
		V.print("\nV=\n");
		A1.print("\nV(^T)AV=\n");
		e.print("\nObtained eigenvalues of A:\n\n");
		double sum=0;
		for(int i=0; i<n; i=i+1){if(Round(A1[i,i])==Round(e[i])){sum=sum+1;}}
		if(sum==n){Out.WriteLine($"\nDiagonalization using classical Jacobi succesfull: Completed in {rots} iterations");} 
		else{Out.WriteLine("\nDiagonalization failed");}}
		
		WriteLine("\n\nThe comparisons between the sweep and classical Jacobi shows approximately same computation time even though the search was refined to an O(n) operation. The rotation times show clearly that the matrix is diagonalized in significantly less iterations of the full sweeps compared to diagonalization through elimination of the largest off diagonal element in each row.");


		// Operation time full sweeps
		using(StreamWriter Write=new StreamWriter("Time.txt")){
		// Quite time heavy so code is suppressed after first run:
		for(int k=10; k<200; k=k+40){
		var time=new Stopwatch();
		int n=k;
		matrix V = new matrix(n,n); vector e=new vector(n);
		matrix A = new matrix(n,n);
		for(int i=0; i<n; i=i+1){for(int j=i; j<n; j=j+1){if(i==j){A[i,j]=RandomDouble(-50,50);} else{A[i,j]=RandomDouble(-50,50); A[j,i]=A[i,j];}}}
		// Diagonalization
		time.Start();
		int rots=JacobiDiag(A,e,V);
		time.Stop();
		Write.WriteLine($"{n} {time.ElapsedMilliseconds} {rots} {Pow(n,2)/50} {7*n}");}


		
		}
	}
}
