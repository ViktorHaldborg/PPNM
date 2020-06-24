using System; using static System.Console; using static System.Math;
using static vector;
using System.IO;
using static RootFinding;
using static Generation;
using static RNG; // Secure RNG
public class IntervalSearch{

public static Tuple<matrix,matrix> Search(int n, int Points, int ε, int μ){ // Implemented search+ Newton Raphson search
// Convergence criterion is based on the built in Round function to a given decimal all precision(max 15) which is essentially the same for less or equal to criterions

using(StreamWriter Write1=new StreamWriter("Time.txt")){

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
////////////7



matrix A_d=new matrix(n,n); // nxn matrix with 0 in all entries to build diagonalized A



vector ii=new vector(n); 
vector x0=new vector(1); // Vector to store initial guess inside
int AddCounter=0;



double IntLow=-2;
double IntHigh=8;
double step=(IntHigh-IntLow)/Points;
int kk=0;

for(ii[0]=IntLow; ii[0]<IntHigh; ii[0]=ii[0]+step)
{	
x0[0]=ii[0];
Write1.WriteLine($"{ii[0]} {f2(x0)[0]} {f(x0)[0]} {f1(x0)[0]}");
}

// Return after writing, (A_d initialized by constructor call)
///////////////////////////
return Tuple.Create(A_d,A);
//////////////////////////


} // write
}}
