using System;
using static System.Math;
using static System.Console;
using System.IO;
using static CubicInterpolation;
class main{static void Main(){

// To test the cubic interpolation i will compare x and y values of the function sin(x) with the splined results (as shown in plot A)
//Generation of tabulated test values
int n=100; // N data points (Arbitrary precision)
vector x = new vector((int) n); vector y = new vector((int) n);
using (StreamWriter outputFile = new StreamWriter("ManualValues.txt")){
for(int i=0; i<n; i=i+1){
x[i]=i*(2*PI/n); y[i]=Sin(x[i]);
outputFile.WriteLine($"{x[i]} {y[i]} {1-Cos(x[i])} {Cos(x[i])}");}}
		
//Cubic interpolation
var CubicInterp=new CubicInterpolation(x,y); // Constructor call
using (StreamWriter CubicSplineOut = new StreamWriter("CubicSpline.txt")){
for(double z=0; z<x[x.size-1]; z=z+(x[x.size-1])/120){CubicSplineOut.WriteLine($"{z} {CubicInterp.CubicSpline(z)} {CubicInterp.CubicSplineIntegrate(z)} {CubicInterp.CubicSplineDerivative(z)}");}}
}}
