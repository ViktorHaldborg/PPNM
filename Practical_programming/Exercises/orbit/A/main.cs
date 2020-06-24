using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;

class main{static void Main(){
    
	Func<double, vector, vector> 
	f= delegate(double x, vector y){return new vector(y[0]*(1-y[0]),0);};
	double a=0;
	double b=3;
	vector ya= new vector(0.5,0);
	var xs=new List<double>();
	var ys=new List<vector>();

	ode.rk23(f,a,ya,b,xlist:xs,ylist:ys);
	for(int i=0;i<xs.Count;i++){
        double logistic=1/(1+Exp(-xs[i]));
        WriteLine($"{xs[i]} {ys[i][0]} {logistic}");}
 }
}
