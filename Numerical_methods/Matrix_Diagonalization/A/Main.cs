using System;
using System.IO;
using static System.Math;
using static System.Console;
using static JacobiDiagonalization1;
using static RNG;
class main{public static void Main(){
 		
		int n=RandomInt(3,5);
		matrix A = new matrix(n,n);
		for(int i=0; i<n; i=i+1){for(int j=i; j<n; j=j+1){if(i==j){A[i,j]=RandomDouble(5,20);} else{A[i,j]=RandomDouble(5,20); A[j,i]=A[i,j];}}}
		A.print("Randomly generated symmetric square matrix A=\n");
		matrix A_2=A.copy(); matrix V = new matrix(n,n); vector e=new vector(n);
		// Diagonalization
		int sweeps=JacobiDiag(A,e,V);
		A.print("\nD=\n");
		matrix A1=V.T*A_2*V;
		V.print("\nV=\n");
		A1.print("\nV(^T)AV=\n");
		e.print("\nObtained eigenvalues of A:\n\n");
		double sum=0;
		for(int i=0; i<n; i=i+1){if(Round(A1[i,i])==Round(e[i])){sum=sum+1;}}
		if(sum==n){Out.WriteLine($"\nDiagonalization succesfull: Completed in {sweeps} iterations");} 
		else{Out.WriteLine("\nDiagonalization failed");}

		
		}
	}

