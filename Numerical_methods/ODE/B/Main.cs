using System;
using static ODE;
using System.IO;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
class main{public static void Main(){
double N=5800000; // Recompiled by changing T_r/T_c=2
double T_r=11; // Assumed 1.5 weeks of recovery time
double T_c=T_r/2; // Due to the incubation period being ~T_r/2, it is assumed that 0.5 people will be infected within the two weeks on average(due to all the precations).
double x0=0; double x1=80;

Func<double,vector,vector> SIR_ODEs=delegate(double x, vector y){
double I=y[1]; double S=y[0];
vector result= new vector(-I*S/(N*T_c),(I*S)/(N*T_c)-(I/T_r),I/T_r);
return result;};

vector y0=new vector(N, 800, 0); // Initial conditions(No herd immunity(0 recorded recovered), ~800(As of march 13th), 0 recorded deaths)
double acc=1e-3; double eps = 1e-3; double h=0.3;
var xlist=new List<double>(); var ylist=new List<vector>();
vector ys=RK12Driver(SIR_ODEs, x0, y0, x1, h, acc, eps, xlist, ylist);
using(StreamWriter Out=new StreamWriter("out.txt")){
for(int i=0; i<xlist.Count; i=i+1){Out.WriteLine($"{xlist[i]} {ylist[i][0]} {ylist[i][1]} {ylist[i][2]}");}
}}}
