using System; using static System.Math; using static System.Console;
using System.IO;
using static LinearInterpolation;
class MainA{static void Main(){

double n=20; //n values (arbitrary precision)
vector x = new vector((int) n);vector y = new vector((int) n);
using (StreamWriter outputFile = new StreamWriter("TabulatedValues.txt")){
for(int i = 0; i<n; i=i+1){
x[i]=i*(2*PI/n); y[i]=Sin(x[i]);
outputFile.WriteLine($"{x[i]}	{y[i]}	{1-Cos(x[i])}");}} //Generation of tabulated values

using (StreamWriter LinSplineOut = new StreamWriter("LinSpline.txt")){
double k = 100; //#of points used in interpolation
for(double z=0; z<x[x.size-1]; z=z+(x[x.size-1])/k){
LinSplineOut.WriteLine($"{z}	{LinSpline(x,y,z)}	{LinSplineIntegral(x,y,z)}");}
	}
}}
