using System; using static System.Console; using static System.Math;
using static vector;
using static RNG; // Secure RNG
public class Generation{

public static Tuple<int,matrix,matrix,matrix,double,double> Generate(int n){ // Generates inputs

// Defining the given variables:
int p=RandomInt(0,n-1); // Since the internal labelling of elements starts from 0 we define p internally as an integer from the interval [0,n-1]
matrix D=new matrix(n,n); matrix W=new matrix(n,n); matrix A=new matrix(n,n); 
matrix u=new matrix(n,1); matrix e=new matrix(n,1); // We store the vectors as nx1 matrices to utilize matrix library 
double a=-5; double b=5; // Declare interval of randomly generated entries
bool check;
int IDcounter=0;
do{
check=false;
	for(int i=0; i<n; i=i+1)
	{
		if(i==p)
		{
			e[i,0]=1; 
			u[i,0]=0; // u[p,0]=0 as per assumption
		}
		
		else
		{
			e[i,0]=0; 
			u[i,0]=RandomInt(-2,2);  // Elements of e(p) and u (do not run over 0 here as per assumption)
		}

		for(int j=0; j<n; j=j+1)
		{
			if(i==j)
			{
				D[i,j]=RandomInt(-1,1);  // Elements of D(old eigenvalues)
			}		
			
			else
			{
				D[i,j]=0; // Off diagonal elements of D
			}
		}
	}
	
	for(int j=0; j<n; j=j+1) 
	{	
		for(int i=0; i<n; i=i+1)
		{
			if(D[j,j]==D[i,i] && j!=i) // Testing for degeneracy of old eigenvalues
			{

			}
		 }
	}
	for(int i=0; i<n; i=i+1)
	{
		IDcounter=0;
		for(int j=0; j<n; j=j+1)
		{
			if(D[i,i]==D[j,j] && i!=j)
			{
				IDcounter++;
				if(IDcounter>3)
				{
					check=true;
				}
			}
		}
	}
}while(check);

W=e*(u.T)+u*(e.T); // Constructing update matrix
A=D+W; // Constructing A

Write($"\nOur initial parameters n and p are randomly generated to be: n={n} & p={p+1}\n");
e.print($"\nWith our direction vector e({p+1}) =\n");
u.print("\nOur update vector u =\n");
D.print("\nOur diagonal matrix D =\n");
W.print("\nOur update matrix W =\n");
Write("\nWe now obtain the matrix A=D+W, which we wish to diagonalize.\nCheck that A is symmetric:\n");
A.print("\nA =\n");
int sum=0; for(int i=0; i<n; i=i+1){for(int j=0; j<n; j=j+1){if(A[i,j]==A.T[i,j]){sum=sum+1;}}} // Testing to see if A is symmetric
if(sum==Pow(n,2)){Write("\nTest passed: A is symmetric\n");}
else{Write("\nTest failed: A is not symmetric\n\n");} 





return Tuple.Create(p,u,D,A,a,b);

}}
