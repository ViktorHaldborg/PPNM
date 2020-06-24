using System;
using System.IO;
using static System.Math;
using static System.Console;
using static JacobiDiagonalization1;
class main{public static void Main(){
 		

// Quantum particle in a box (approximated by the three point finite difference formula) 

int n_1=120;
double s=1.0/(n_1+1);
matrix H=new matrix(n_1,n_1);
for(int i=0; i<n_1-1;i=i+1){matrix.set(H,i,i,-2); matrix.set(H,i,i+1,1); matrix.set(H,i+1,i,1);}
matrix.set(H,n_1-1,n_1-1,-2);
matrix.scale(H,-1/Pow(s,2));

matrix J=new matrix(n_1,n_1);
vector eigenvalues=new vector(n_1);
int rotations=JacobiDiag(H,eigenvalues,J);
using(StreamWriter Write=new StreamWriter("ParticleInABox.txt")){
Write.WriteLine($"Diagonalization of H completed in {rotations} iterations\n");

// Eigenenergies	
for(int k=0; k<n_1/4; k=k+1){
double exact=PI*PI*Pow(k+1.0,2); double calculated=eigenvalues[k];
Write.WriteLine($"{k} {calculated} {exact}");}
			
Write.WriteLine($"\nPercentage of the k'th=n-1 approximated eigenenergies compared to the exact energies:\n");
for(int k=0; k<n_1/4; k=k+1){double exact=PI*PI*Pow(k+1.0,2); double calculated=eigenvalues[k];
Write.WriteLine($"{k} {calculated/(exact*0.01)} %");}}
		
// Eigenfunctions
using(StreamWriter Eigenfunctions=new StreamWriter("Eigenfunctions.txt")){;
for(int k=0; k<3; k=k+1){for(int i=0; i<n_1; i=i+1){double x=(i+1.0)/(n_1+1.0);
Eigenfunctions.WriteLine($"{x} {(1/Sqrt(s))*J[i,k]*Sign(J[0,k])} {Sqrt(2)*Sin((k+1)*PI*x)}"); // Analytical eigenfunctions
}Eigenfunctions.Write("\n");
			}
	
		}
	}
}

