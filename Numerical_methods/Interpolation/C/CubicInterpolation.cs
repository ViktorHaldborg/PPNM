using System;
using static System.Math;
using static BinarySearch;
public class CubicInterpolation{

vector x,y,b,c,dx,dy,d,B,D,Q; 

public CubicInterpolation(vector xs,vector ys){ // Constructor
int n=xs.size;
x=new vector(n); y=new vector(n); b=new vector(n); d=new vector(n-1);
dy=new vector(n-1); dx=new vector(n-1); vector p=new vector(xs.size-1);
c=new vector(n-1); D=new vector(n); Q=new vector(n-1); B=new vector(n);

for(int i=0; i<n; i=i+1){x[i]=xs[i]; y[i]=ys[i];} // Instantiating x and y
for(int i=0; i<p.size; i=i+1){dx[i]=xs[i+1]-xs[i]; dy[i]=ys[i+1]-ys[i]; p[i]=dy[i]/dx[i];}

// Tridiagonal system Ab=B
// With diagonal elements D in A:
D[0]=2; D[n-1]=2; // D[i+1]=2*(dx[i]/dx[i+1])+2
// And the other non zero off diagonal elements Q in the upper triangular part of A is:  
Q[0]=1; // Q[i+1]=dx[i]/dx[i+1]
for(int i=0;i<n-2;i=i+1){D[i+1]=2*dx[i]/dx[i+1]+2; Q[i+1]=dx[i]/dx[i+1];}

// Elements in B are: 
B[n-1]=3*p[n-2]; B[0]=3*p[0]; // B[1]=3*p[1], B[i+1]=3*(p[i]+p[i+1](dx[i]/dx[i+1])
for(int i=0;i<n-2;i=i+1){B[i+1]=3*(p[i]+p[i+1]*dx[i]/dx[i+1]);} 

// Row reduction
for(int i=1; i<n; i=i+1){D[i]=D[i]-(Q[i-1]/D[i-1]); B[i]=B[i]-(B[i-1]/D[i-1]);} // Overwriting D,B by D̃ and B̃  through recursion with (D̃[0]=D[0],B̃[0]=B[0])

// Finding the auxiliary b's using back substitution
b[n-1]=B[n-1]/D[n-1];
for(int i=n-2; i>=0; i=i-1){b[i]=(B[i]-Q[i]*b[i+1])/D[i];} 
// Having obtained b[i] we can define c[i] and d[i] in S(x)
// Given as the equations:
// c[i]*dx[i] = −2b[i]−b[i]+1+3p[i]
// d[i]*dx[i]^2=b[i]+b[i+1]-2*p[i]
for(int i=0; i<n-1; i=i+1){c[i]=(-2*b[i]-b[i+1]+3*p[i])/dx[i]; d[i]=(b[i]+b[i+1]-2*p[i])/Pow(dx[i],2);}}

// Binary search and evaluation of the splinefunction
public double CubicSpline(double z){
int z_i= BinSearch(x, z);
double S=y[z_i]+b[z_i]*(z-x[z_i])+c[z_i]*Pow((z-x[z_i]),2)+d[z_i]*Pow(z-x[z_i],3); // Ordinary cubic spline form
return S;}

// Analytical form of the integral: ∫dx³+cx²+bx+y dx = (d/4)x⁴*+(c/3)*x³+(b/2)*x²+yx (C=0) 
// Integration of the tabulated function S_[i]:
public double CubicSplineIntegrate(double z){
int z_i=BinSearch(x,z); double sum1=0; int i=0;
for(i=0;i<z_i; i=i+1){sum1=sum1+(d[i]/4)*Pow(x[i+1]-x[i],4)+(c[i]/3)*Pow(x[i+1]-x[i],3)+(b[i]/2)*Pow(x[i+1]-x[i],2)+y[i]*(x[i+1]-x[i]);} // The integral of the splinefunction at x[i]
double sum2=(d[i]/3)*Pow(z-x[i],4)+(c[i]/3)*Pow(z-x[i],3)+(b[i]/2)*Pow(z-x[i],2)+y[i]*(z-x[i]); // The integral of the splinefunction for x[i]<z<x[i+1]
return sum1+sum2;} // Returns integral of S(x) with arbitrary precision

// Analytical form of the derivate: d/dx (dx³+cx²+bx+y) = 3dx²+2*c*x+b 
// Derivative of the tabulated function S_[i]:
public double CubicSplineDerivative(double z){
int z_i=BinSearch(x,z); 
return 3*d[z_i]*Pow((z-x[z_i]),2)+2*c[z_i]*(z-x[z_i])+b[z_i]; // // Returns S'(x) with arbitrary precision

    }   

}
