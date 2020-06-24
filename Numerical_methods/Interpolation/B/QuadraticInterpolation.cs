using System; using static System.Math;
using static System.Console;	
using static BinarySearch;
public class QuadraticInterpolation{
vector x,y,b,c,dx,dy,c_down,c_up; 

public QuadraticInterpolation(vector xs,vector ys){ // Constructor for the class QuadraticInterpolation
int n=xs.size;
x=new vector(n); y=new vector(n); b=new vector(n-1);
dy=new vector(n-1); dx=new vector(n-1); vector p=new vector(xs.size-1);
c_down=new vector(n-1); c_up=new vector(n-1); c=new vector(n-1);

for(int i=0; i<n; i=i+1){x[i]=xs[i]; y[i]=ys[i];} // Assigning x and y
for(int i=0; i<p.size; i=i+1){dx[i]=xs[i+1]-xs[i]; dy[i]=ys[i+1]-ys[i]; p[i]=dy[i]/dx[i];}

// Running forward recursion 
c_up[0]=0;
for(int i=0; i<c_up.size-1; i=i+1){c_up[i+1]=(p[i+1]-p[i]-c_up[i]*dx[i])/dx[i+1];}

// Running backwards recursion 
c_down[c_down.size-2]=0;
for(int i=(c_down.size-2); i>0; i=i-1){c_down[i]=(p[i+1]-p[i]-c_down[i+1]*dx[i+1])/dx[i];}

for(int i=0; i<b.size; i=i+1){c[i]=(c_up[i]+c_down[i])/2;} // Averaging

for(int i=0; i<b.size; i=i+1){b[i]=p[i]-c[i]*dx[i];

//Revrieve b in txt: WriteLine($"b({i})={b[i]}");
}}

// Binary search and evaluation of the splinefunction
public double QuadSpline(double z){
int i= BinSearch(x, z);
double S=y[i]+b[i]*(z-x[i])+c[i]*(z-x[i])*(z-x[i]); // Ordinary quadratic spline form
return S;}

// Analytical form of the integral: ∫cx²+bx+y dx = (c/3)*x³+(b/2)*x²+yx (C=0) 
// Integration of the tabulated function S_[i]:
public double QuadSplineIntegrate(double z){
int z_i=BinSearch(x,z); double sum1=0; int i=0;
for(i=0;i<z_i; i=i+1){sum1=sum1+(c[i]/3)*Pow(x[i+1]-x[i],3)+(b[i]/2)*Pow(x[i+1]-x[i],2)+y[i]*(x[i+1]-x[i]);} // The integral of the splinefunction at x[i]
double sum2=(c[i]/3)*Pow(z-x[i],3)+(b[i]/2)*Pow(z-x[i],2)+y[i]*(z-x[i]); // The integral of the splinefunction for x[i]<z<x[i+1]
return sum1+sum2;} // Returns integral of S(x) with arbitrary precision

// Analytical form of the derivate: d/dx (cx²+bx+y) = 2*c*x+b 
// Derivative of the tabulated function S_[i]:
public double QuadDerivative(double z){
int z_i=BinSearch(x,z); 
return 2*c[z_i]*(z-x[z_i])+b[z_i]; // // Returns S'(x) with arbitrary precision

    }   

}
