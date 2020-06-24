using System; using static System.Console; using static System.Math;
using static vector;
using static RNG; // Secure RNG
public class Generation{

public static Tuple<int,matrix,matrix,matrix,double,double> Generate(int n){ // Generates inputs

// Defining the given variables:
int p=RandomInt(0,n-1); // Since the internal labelling of elements starts from 0 we define p internally as an integer from the interval [0,n-1]
matrix D=new matrix(n,n); matrix W=new matrix(n,n); matrix A=new matrix(n,n); 
matrix u=new matrix(n,1); matrix e=new matrix(n,1); // We store the vectors as nx1 matrices to utilize matrix library 
double a=-10; double b=10; // Declare interval of randomly generated entries
bool DegenerateEigenvalues;
do{
	DegenerateEigenvalues=false;
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
			u[i,0]=RandomDouble(1,10);  // Elements of e(p) and u (do not run over 0 here as per assumption)
		}

		for(int j=0; j<n; j=j+1)
		{
			if(i==j)
			{
				D[i,j]=RandomDouble(a,b);  // Elements of D(old eigenvalues)
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
				DegenerateEigenvalues=true;
			}
		 }
	}
}while(DegenerateEigenvalues); 

W=e*(u.T)+u*(e.T); // Constructing update matrix
A=D+W; // Constructing A






return Tuple.Create(p,u,D,A,a,b);

}}
