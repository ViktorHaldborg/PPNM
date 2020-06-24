using System; using static System.Console; using static System.Math;
using static vector;

public class RootFinding{

public static vector NewtonUpdateMatrix(Func<vector,vector> f, Func<vector,vector> f1, vector x, int ε, int n){	// parameters
vector x0=new vector(n); 
x0[0]=x[0]; // Storing initial guess
int l=0;
// Tuned to specific scenario
do{
l=l+1;
x[0]=x[0]-((f(x)[0])/(f1(x)[0]));
x0[0]=x[0];
if(Double.IsNaN((x0).norm()) && l>5){break;}  // If we have gone some steps and are divergent we abort
if(Round(f(x).norm(),ε)==0 && !Double.IsNaN((x0).norm())){break;} 
if(l>500){ break;} // We cannot let it loop forever, there seems to be cases in which convergence is far from quadratic, however we still need to come sufficiently close. Scale parameter to needs
}while(true);
return x0;

}}
