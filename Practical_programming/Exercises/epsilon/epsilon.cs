using System;
using static System.Console;
using static System.Math;
class epsilon{static int Main(){

	WriteLine($"A)");
	int i=1; while(i+1>i) {i++;}
	WriteLine($"My max Z = {i} & int.MaxValue={int.MaxValue}");

	int k=1; while(k-1<k) {k--;}
	WriteLine($"My min Z = {k} & int.MinValue={int.MinValue}\n");
	WriteLine($"B)");
	double x=1; 
	while(1+x!=1){x/=2;} x*=2;
	WriteLine($"Machine double Ɛ = {x}");

	float y=1F; 
	while((float)(1F+y) != 1F){y/=2F;} y*=2F;
	WriteLine($"Machine float Ɛ = {y}\n");
	WriteLine($"C)");
	int max=int.MaxValue/3;
	float float_sum_up=1F;
	for(int h=2;h<max;h++)float_sum_up+=1F/h;
	WriteLine($"float_sum_up={float_sum_up}");

	float float_sum_down=1F/max;
	for(int j=max-1;j>0;j--)float_sum_down+=1F/j;
	WriteLine($"float_sum_down={float_sum_down}\n");
	WriteLine($"The harmonic series is divergent, but due to limitations of a computer, the sum will converge. The difference in the results of the two summations of real numbers using float based arithmetic is a direct consequence of the accumulated errors from rounding: When summing the computer rounds to the nearest representable number(with 32 bits for floats.");

	double double_sum_up=1D;
	for(int c=2;c<max;c++)double_sum_up+=1D/c;
	WriteLine($"double_sum_up={double_sum_up}");

	double double_sum_down=1D/max;
	for(int b=max-1;b>0;b--)double_sum_down+=1D/b;
	WriteLine($"double_sum_down={double_sum_down}\n");
	
	WriteLine($"For double precision the rounding errors are less prominent since the amount of bits used in its representation is higher than for floats(mantissa is 52 and 23 respectively");

		
return 0;}
}

