using System;
using static ODE;
using System.IO;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
class main{public static void Main(){

Func<double,vector,vector>ODE=delegate(double x, vector y){
double dy1dx=y[1]; double dy2dx = -y[0];
vector result= new vector(dy1dx,dy2dx);
return result;};

double x0=0; double x1=3*PI-0.5*PI;
vector y0=new vector(1,0); // Initial conditions
double acc=1e-3; double eps = 1e-3; double h=0.1;
var xlist=new List<double>(); var ylist=new List<vector>();
vector ys=RK12Driver(ODE, x0, y0, x1, h, acc, eps, xlist, ylist);
using(StreamWriter Out=new StreamWriter("out.txt")){	
for(int i=0; i<xlist.Count; i=i+1){Out.WriteLine($"{xlist[i]} {ylist[i][0]}");}}
}}
