using System;
using System.IO;
using static System.Math;
using static System.Console;
using static JacobiDiagonalizationVBV;
using static RNG;
class main{public static void Main(){
 		
		int n=RandomInt(4,8);
		matrix A = new matrix(n,n);
		for(int i=0; i<n; i=i+1){for(int j=i; j<n; j=j+1){if(i==j){A[i,j]=RandomDouble(5,20);} else{A[i,j]=RandomDouble(5,20); A[j,i]=A[i,j];}}}
		A.print("Randomly generated symmetric square matrix A=\n");
		matrix A_2=A.copy(); matrix V = new matrix(n,n); vector e=new vector(n);
		// Diagonalization
		int c=1; // Number of lowest eigenvalues
		int sweeps=JacobiDiag(A,e,V,c);
		A.print("\nD=\n");
		matrix A1=V.T*A_2*V;
		V.print("\nV=\n");
		A1.print("\nV(^T)AV=\n");
		//A.print("\nD=\n");
		if(Round(A[0,0])==Round(e[0]))
		{Out.WriteLine($"\nElimination of first row succesfull: Completed in {sweeps} iterations");} 
		else{Out.WriteLine("\nElimination failed");}
		WriteLine("A[p,p] and A[q,q] are analytically given and defined through recursion of their entries in the pre transformation matrix.");
WriteLine("Assumning an even weighing from s^2 and c^2 tt is evident that A'[p,p]<A'[q,q] by their definitions within the algorithm.");

WriteLine("\nAll comparisons are shown in the figure for a static matrix, along with the computation time of the sweep method for randomly generated matrices.\n");

WriteLine("\n To obtain the largest eigenvalue first instead of the lowest we use the analytical expression given for A'[p,p]=c^2A[p,p]-2scA[p,q]+s^2A[q,q] again. Since A'[p,p] for our given theta is minimal and is a composition of sin and cos functions and thus, have the periodicity of cos and sin functions we must conclude that a phaseshift of pi/2 will maximize the expression to yield the largest eigenvalue first and still diagonalize the matrix.");






		}
	}

