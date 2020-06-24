using System; using static System.Console; using static System.Math;
using static vector;
public class JacobiMatrix{
public static matrix Jacobi(Func<vector,vector> f, vector x, double δx){
int n = x.size;
vector δfδx=new vector(n); vector x_step; vector Δx;
matrix J = new matrix(n, n);

for(int i=0; i<n; i=i+1){
x_step = x.copy();
x_step[i] = x_step[i] + δx;
δfδx = (f(x_step) - f(x))/δx; // Differential using finite differences 
for(int j=0; j<n; j=j+1){J[j,i] = δfδx[j];}} // Elements in Jacobian matrix	
return J;
}}

