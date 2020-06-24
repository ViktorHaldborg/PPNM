using System; using static System.Console; using static System.Math;
using static vector;
using static RootFinding;
using static Generation;
using static RNG; // Secure RNG
public class IntervalSearch{

public static Tuple<matrix,matrix> Search(int n, int Points, int ε, int δ){ 


// Randomly generated inputs by calling other routine
var Generated=Generate(n);
int p=Generated.Item1;
matrix u=Generated.Item2; // Vector however coded as a matrix
matrix D=Generated.Item3; matrix A=Generated.Item4;
double a=Generated.Item5; double b=Generated.Item6;


// Defining vector function, however we are only dealing with the one dimensional case here
vector secular=new vector(n);
Func<vector,vector> f = delegate(vector t){
secular[0]=0;
for(int k=0; k<n; k=k+1){if(k!=p){secular[0]=secular[0]+(Pow(u[k,0],2)/(D[k,k]-t[0]));}} // Defining the elements of the sum
return new vector((-D[p,p]+t[0]+secular[0]));}; // Returning full left hand side of the equation we wish to find the roots of. 


// Define the derivative of the characteristic polynomial
Func<vector,vector> f1 = delegate(vector z){
secular[0]=0;
for(int k=0; k<n; k=k+1){if(k!=p){secular[0]=secular[0]+(Pow(u[k,0],2)/(Pow(D[k,k]-z[0],2)));}} // Defining the elements of the sum
return new vector((1+secular[0]));}; // Returning full left hand side of the equation we wish to find the roots of. 


matrix A_d=new matrix(n,n); // nxn matrix with 0 in all entries to build diagonalized A
int SingularityCount=n-1; // From the assumptions made


// Store  n-1 off diagonal elements of D in a vector
double[] d=new double[SingularityCount];
int o=0;
for(int i=0; i<SingularityCount; i=i+1){if(o==p){o=o+1;} // Skipping p'th element
d[i]=D[o,o];o=o+1;}
Array.Sort(d);
// Lets convert this back to a vector
vector Singularity=new vector(SingularityCount);
for(int i=0; i<Singularity.size; i=i+1){Singularity[i]=d[i];}

vector ii=new vector(n); 
vector x0=new vector(1); // Vector to store initial guess inside
int AddCounter=0;


// Searching up until first singularity (Running backwards as is more effecient)
double IntLow=-4*Max(Abs(a),Abs(b));
double IntHigh=Singularity[0];
double step=(IntHigh-IntLow)/Points;
int kk=0;
step=(IntHigh-IntLow)/Points;
for(ii[0]=IntHigh; ii[0]>IntLow; ii[0]=ii[0]-step)
{
	x0[0]=ii[0];
	if(Round(f(NewtonUpdateMatrix(f,f1,x0,ε,n))[0],δ)==0 && NewtonUpdateMatrix(f,f1,x0,ε,n)[0]<Singularity[0])
	{
		A_d[AddCounter,AddCounter]=NewtonUpdateMatrix(f,f1,x0,ε,n)[0]; AddCounter=AddCounter+1; break;
	}	
	if(Round(f(x0)[0],δ)==0 && x0[0]<Singularity[0])
	{
		A_d[AddCounter,AddCounter]=x0[0]; AddCounter=AddCounter+1; break;
	}
	kk=kk+1; 
	if(kk==Points){break;}	
}


// Searching for roots in between the singularities
// Some definitions are overwritten and used again and again.
for(int jj=0; jj<SingularityCount-1; jj=jj+1)  // Loop for indexing.
{
	IntLow=Singularity[jj];
	IntHigh=Singularity[jj+1];
	step=(IntHigh-IntLow)/Points;
	kk=0; 
	do{ // allow to break
		x0[0]=(IntHigh-IntLow)/2; // Quickly try in the middle of both singuliarities before going into for loop
		if(Round(f(NewtonUpdateMatrix(f,f1,x0,ε,n))[0],δ)==0 && NewtonUpdateMatrix(f,f1,x0,ε,n)[0]>Singularity[jj] && NewtonUpdateMatrix(f,f1,x0,ε,n)[0]<Singularity[jj+1])
		{
			A_d[AddCounter,AddCounter]=NewtonUpdateMatrix(f,f1,x0,ε,n)[0]; AddCounter=AddCounter+1; break;
		}
		for(ii[0]=IntLow; ii[0]<IntHigh; ii[0]=ii[0]+step)
		{
			x0[0]=ii[0];
			if(Round(f(NewtonUpdateMatrix(f,f1,x0,ε,n))[0],δ)==0 && NewtonUpdateMatrix(f,f1,x0,ε,n)[0]>Singularity[jj]
			&& NewtonUpdateMatrix(f,f1,x0,ε,n)[0]<Singularity[jj+1])
			{
				A_d[AddCounter,AddCounter]=NewtonUpdateMatrix(f,f1,x0,ε,n)[0]; AddCounter=AddCounter+1; break;
			}

			if(Round(f(x0)[0],δ)==0 && x0[0]>Singularity[jj] && x0[0]<Singularity[jj+1])
			{
				A_d[AddCounter,AddCounter]=x0[0]; AddCounter=AddCounter+1; break;
			}
		kk=kk+1; 
		if(kk==Points){break;}		
		}
	}while(false);
}




// Searching after last singularity
IntLow=Singularity[SingularityCount-1]; 
IntHigh=IntLow+4*Max(Abs(a),Abs(b));
kk=0; 
step=(IntHigh-IntLow)/Points;
for(ii[0]=IntLow; ii[0]<IntHigh; ii[0]=ii[0]+step) 
{	
	x0[0]=ii[0];
		if(Round(f(NewtonUpdateMatrix(f,f1,x0,ε,n))[0],δ)==0 && NewtonUpdateMatrix(f,f1,x0,ε,n)[0]>Singularity[SingularityCount-1])
		{
			A_d[AddCounter,AddCounter]=NewtonUpdateMatrix(f,f1,x0,ε,n)[0]; AddCounter=AddCounter+1; break;
		}
			
		if(Round(f(x0)[0],δ)==0 && x0[0]>Singularity[SingularityCount-1])
		{
			A_d[AddCounter,AddCounter]=x0[0]; AddCounter=AddCounter+1; break;
		}
		kk=kk+1; 
		if(kk==Points){break;}	
}


return Tuple.Create(A_d,A);

}}
