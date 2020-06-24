using System; using static System.Console; using static System.Math;
using static vector;
using System.IO;
using static RootFinding;
using static Generation;
using static RNG; // Secure RNG
public class IntervalSearch{

public static Tuple<matrix,matrix> Search(int n, int Points, int ε, int μ){ // Implemented search+ Newton Raphson search
// Convergence criterion is based on the built in Round function to a given decimal all precision(max 15) which is essentially the same for less or equal to criterions


// Randomly generated inputs by calling other routine
var Generated=Generate(n);
int p=Generated.Item1;
matrix u=Generated.Item2; // Vector however coded as a matrix
matrix D=Generated.Item3; matrix A=Generated.Item4;
double a=Generated.Item5; double b=Generated.Item6;




// Defining vector function, however we are only dealing with a one dimensional case here
vector secular=new vector(n);
Func<vector,vector> f2 = delegate(vector t){
secular[0]=0;
for(int k=0; k<n; k=k+1){if(k!=p){
secular[0]=secular[0]+(Pow(u[k,0],2)/(D[k,k]-t[0]));// Defining the elements of the sum
}} // Defining the elements of the sum
return new vector(((-D[p,p]+t[0]+secular[0])));}; // Returning full left hand side of the equation we wish to find the roots of. 

// Define the derivative of the characteristic polynomial

Func<vector,vector> f22 = delegate(vector z){
secular[0]=0;
for(int k=0; k<n; k=k+1){if(k!=p){secular[0]=secular[0]+(Pow(u[k,0],2)/(Pow(D[k,k]-z[0],2)));}} // Defining the elements of the sum
return new vector((1+secular[0]));}; // Returning full left hand side of the equation we wish to find the roots of. 


///////////
vector prod=new vector(n);
Func<vector,vector> f = delegate(vector t){
prod[0]=1;
secular[0]=0;
for(int k=0; k<n; k=k+1){if(k!=p){
secular[0]=secular[0]+(Pow(u[k,0],2)/(D[k,k]-t[0]));// Defining the elements of the sum
prod[0]=prod[0]*(D[k,k]-t[0]); // Rewriting the equation to retain information about 0'ed terms (i.e changing the function
}} // Defining the elements of the sum
return new vector(prod[0]*(-(D[p,p]-t[0])+secular[0]));}; // Returning full left hand side of the equation we wish to find the roots of. 

vector secular2=new vector(n);
Func<vector,vector> f1 = delegate(vector t){
prod[0]=1;
secular[0]=0;
secular2[0]=0;
for(int k=0; k<n; k=k+1)
{
	if(k!=p)
	{
		secular2[0]=secular2[0]+(1/(D[k,k]-t[0]));// Defining the elements of the sum
		secular[0]=secular[0]+(Pow(u[k,0],2)/(D[k,k]-t[0]));// Defining the elements of the sum
		prod[0]=prod[0]*(D[k,k]-t[0]); // Rewriting the equation to retain information about 0'ed terms (i.e changing the function
	}		
} // Defining the elements of the sum
return new vector(prod[0]*(f22(t)[0]-(secular2[0]*f2(t)[0])));}; // Returning full left hand side of the equation we wish to find the roots of. 




matrix A_d=new matrix(n,n); // nxn matrix with 0 in all entries to build diagonalized A



vector ii=new vector(n); 
vector x0=new vector(1); // Vector to store initial guess inside
int AddCounter=0;



double IntLow=-15;
double IntHigh=15;
double step=(IntHigh-IntLow)/Points;
int kk=0;

vector Candidates=new vector(Points);

for(ii[0]=IntLow; ii[0]<IntHigh; ii[0]=ii[0]+step)
{
	x0[0]=ii[0];
	x0[0]=NewtonUpdateMatrix(f,f1,x0,ε,n)[0];
	if(!Double.IsNaN(x0[0]))
	{
		Candidates[AddCounter]=x0[0];  AddCounter=AddCounter+1;
	}
	kk=kk+1; 
	if(kk==Points){break;}		
}


for(int i=0; i<AddCounter; i++)
{
	for(int j=i; j<AddCounter; j++)
	{
		x0[0]=Candidates[j];
		if(Round(Candidates[i],1)==Round(Candidates[j],1) && i!=j)
		{
			Candidates[j]=0;
		}
	}
}
// Remaining from multiplicities

double[] Uniques=new double[n];
int UniquesCount=0;
for(int j=0; j<Candidates.size; j++)
{
	if(Candidates[j]!=0)
	{
		Uniques[UniquesCount]=Candidates[j];
		UniquesCount++;
	}
}
vector delta=new vector(1);
delta[0]=1e-2;
int MultiplicityCount=0;
vector Multiplicity=new vector(n);
for(int j=0; j<UniquesCount; j++)
{
	x0[0]=Uniques[j];
	if(Round(f1(x0)[0],1)==0) // Higher multiplicity!
	{
		if(( f(x0+delta)[0]>0 && f(x0-delta)[0]<0 )||( f(x0+delta)[0]<0 && f(x0-delta)[0]>0 )) // Multiplicity 3
		{
			Multiplicity[j]=3;
		}

		else
		{
			Multiplicity[j]=2;
		}
	MultiplicityCount++;
	}
}

for(int j=0; j<n; j++)
{
	if(UniquesCount==n){break;}
	if(Multiplicity[j]!=0)
	{
		for(int k=0; k<Multiplicity[j]-1; k++)
		{	
			//if(UniquesCount==n-1){}
			Uniques[k+UniquesCount]=Uniques[j];
		}
	UniquesCount++;
	}
}


Array.Sort(Uniques);



for(int i=0; i<n; i++)
{
	A_d[i,i]=Uniques[i];
}




return Tuple.Create(A_d,A);
}}
