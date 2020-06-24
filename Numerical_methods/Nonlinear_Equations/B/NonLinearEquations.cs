using System; using static System.Console; using static System.Math;
using static vector;
using static JacobiMatrix;
using static QRGramSchmidtDecomposition;

public class RootFinding{
public static vector NewtonsStep(Func<vector,vector> f, vector x, double ε, double δx){	
int n=x.size; vector Δx;
matrix R = new matrix(n,n); matrix J=new matrix(n,n);
int l=1; double λ=1; double λ_min=1/64;

while(l>0){ l=l+1;
J=Jacobi(f,x,δx);
// Finding Δx through back substitution
Decomp(J,R); // R stored
Δx=Solve(Decomp(J,R),R,-1*f(x));
// Backtracking λ to find converging Δx step
while(f(x+λ*Δx).norm()>(1-(λ/2))*f(x).norm() & λ>λ_min){λ=λ*0.5;}
x=x+λ*Δx; // x_n+1
if(f(x).norm() < ε | max(abs(Δx)) < δx){WriteLine($"Completed in {l} steps"); break;} // Convergence criterium
if(l==1000000){Error.WriteLine("(ERROR1) Diverging Newton's step: Try different input parameters"); break;}} // Safe upper bound since x_n converges quadratically
return x;
        
}}

