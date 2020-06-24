using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;

class main{static void Main(){
	double e=0.01;
	Func<double, vector, vector> 
	f= delegate(double x, vector y){return new vector(y[1],1+y[0]*(e*y[0]-1));};
	double a=0;
	double b=8*PI;
	vector ya= new vector(1,0.5);
	var xs=new List<double>();
	var ys=new List<vector>();

	ode.rk23(f,a,ya,b,xlist:xs,ylist:ys,acc:1e-4,eps:1e-4); //parameters chosen for the individual exercises as shown in the svg files.
	for(int i=0;i<xs.Count;i++){
        WriteLine($"{xs[i]} {ys[i][0]}");}
 }
}
