using System;
using static System.Console;
using static System.Math;
using System.IO;
using static OrdinaryLeastSquares;
class main{public static void Main(){
	
double[] time={1,2,3,4,6,9,10,13,15};vector t=new vector(time);
double[] activity={117,100,88,72,53,29.5,25.2,15.2,11.1};vector y=new vector(activity);
vector dy=0.05*y;
var f=new Func<double,double>[]{(x)=>1,(x)=>x};
int n=y.size; int m=f.Length;

using(StreamWriter Data=new StreamWriter("Data.txt")){
for(int i=0; i<t.size; i++){Data.WriteLine($"{t[i]}	{y[i]}	{dy[i]}");}}

// The decay of activity follows an exponential form y(t)=ae^(λt)
// Rewritten gives the form which shall be fitted: ln(y)=ln(a)+λt
// Coefficients a and λ is obtained through least square fitting using QR decomposition
vector logy=new vector(n); vector logdy=new vector(n); 
for(int i=0; i<n; i++){logy[i]=Log(y[i]); logdy[i]=dy[i]/y[i];}
var c=LeastSquaresFit(t,logy,logdy,f).Item1;
var c_unc=LeastSquaresFit(t,logy,logdy,f).Item2;
double thalf=((Log((Exp(c[0]+c[1]*(t[0])))/2)-c[0])/c[1])-t[0];
double thalf_unc=(((Log((Exp((c[0]+c_unc[0])+(c[1]+c_unc[1])*(t[0])))/2)-(c[0]+c_unc[0]))/(c[1]+c_unc[1]))-t[0])-thalf;

using(StreamWriter DataOut=new StreamWriter("DataOut.txt")){ 	
for(double x=t[0]; x<t[t.size-1]; x=x+0.15){
double c0p=Exp(c[0]+c_unc[0]+(c[1]*x)); double c0m=Exp(c[0]-c_unc[0]+(c[1]*x)); 
double c1p=Exp(c[0]+((c[1]+c_unc[1])*x)); double c1m=Exp(c[0]+((c[1]-c_unc[1])*x));
DataOut.WriteLine($"{x} {Exp(c[0]+c[1]*x)} {thalf} {thalf_unc} {c0p} {c0m} {c1p} {c1m}");
}}
	
using(StreamWriter answer=new StreamWriter("out.txt")){
answer.WriteLine($"The decay of activity follows an exponential form y(t)=ae^(λt).\nRewritten gives the form which shall be fitted: ln(y)=ln(a)+λt.\nCoefficients a and λ is obtained through least square fitting using QR decomposition");
answer.WriteLine($"\nHalf life of ThX determined to be {thalf} days with an uncertainty of ±{thalf_unc} days.");
answer.WriteLine($"\nThe half life of 224Ra is 3.6319(23) days, which is not within the estimated uncertainty of the half life of ThX.");
answer.WriteLine($"\nThe errors on the fitting coefficients is found to be c_{0}={c_unc[0]} and c_{1}={c_unc[1]}");}
}}
