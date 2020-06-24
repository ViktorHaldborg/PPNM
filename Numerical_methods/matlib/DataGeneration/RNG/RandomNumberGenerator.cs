using System;
using static vector;
using static System.Math;
using static System.Console;
using System.Diagnostics;
using System.Security.Cryptography; 

public class RNG{
// RNGCryptoServiceProvider gives initial seed value derived from entropy.
static Random fact=new Random(); // Pseudo is used for having transparency in the picked factor between [0,1].
// Since seed is random we can determine our randon number to be within desired bounds securely through the following algorithm, (which will then still yield a random number):
public static double RandomDouble(double a, double b){ //a and b specifies the range of the roll, input assumes a<=b
if(b<a)
{
	Error.WriteLine("[RNG]:Error in input arguments\nTry (a,b) with b>a"); WriteLine("NaN"); return b+1;
}

if(b==a)
{
	return b;
}

using (RNGCryptoServiceProvider rng=new RNGCryptoServiceProvider()) 
{
	byte[] rnd = new byte[2]; rng.GetBytes(rnd); int randomvalue=BitConverter.ToInt16(rnd, 0);
	double rndvalue=Convert.ToDouble(randomvalue);
	do
	{	
		if(rndvalue<a && Abs(rndvalue)<=Abs(b-a)) 
		{
			rndvalue=Abs(rndvalue)+a;
		}

		if(rndvalue>b && Abs(rndvalue)<=Abs(b-a))
		{
			rndvalue=-Abs(rndvalue)+b;
		}	

		if(rndvalue<a && Abs(rndvalue)>Abs(b-a))
		{
			rndvalue=rndvalue*fact.NextDouble(); // rndvalue=rndvalue*fact.NextDouble()
		}

		if(rndvalue>b && Abs(b-a)<Abs(rndvalue))
		{
			rndvalue=rndvalue*fact.NextDouble(); // rndvalue=rndvalue*fact.NextDouble()
		}
		//Error.WriteLine($"rndvalue={rndvalue}");
		if(a<=rndvalue && rndvalue<=b){break;}
	}while(b>a);
return rndvalue;}}


// Integer
static Random intstep=new Random();
public static int RandomInt(int a, int b){ //a and b specifies the range of the roll, input assumes a<=b
if(b<a)
{
	Error.WriteLine("[RNG]:Error in input arguments\nTry (a,b) with b>a"); WriteLine("NaN"); return b+1;
}

if(b==a){return b;}


using (RNGCryptoServiceProvider rng=new RNGCryptoServiceProvider())
{
	byte[] rnd = new byte[2]; rng.GetBytes(rnd); int rndvalue=BitConverter.ToInt16(rnd, 0);

	do
	{
		if(rndvalue<a) 	
		{
			rndvalue=rndvalue+intstep.Next(10);
		}

		if(rndvalue>b)
		{
			rndvalue=rndvalue-intstep.Next(10);
		}

		if(a<=rndvalue && rndvalue<=b){break;}
	}while(b>a);

return rndvalue;}}



// Return vector with random entries with a[i] and b[i] as scaling parameters
public static vector RandVector(vector a, vector b){
vector rndvector=new vector(a.size);
for(int i=0; i<a.size; i=i+1)
{
	rndvector[i]=a[i]+RandomDouble(1e-10,1)*(b[i]-a[i]);
}

return rndvector;}






}

// Something to do with random class:
//if(a==0 & b>0){res=random*b; return res;}
//if(a==0 & b<0){Write("Error: Wrong input arguments(returning b+1) "); return r;}
//if(b==0 & a<0){res=random*a; return res;}
//if(b==0 & a>0){if(a==0 & b<0){Write("Error: Wrong input arguments(returning b+1) "); return r;}}
//if(b==0 & a==0){return 0;}
//if(a>0 & b>0 & b>a){res=random; return res;} //{if(rnd.NextDouble()*b<a){k=k+1;} else
//if(a>0 & b>0 & a>b){Write("Error: Wrong input arguments(returning b+1) "); return r;}
//if(a<0 & b<0 & a<b){res=a*random; return res;} 
//if(a<0 & b<0 & a>b){Write("Error: Wrong input arguments(returning b+1) "); return r;}
//if(a>0 & b<0){Write("Error: Wrong input arguments(returning b+1) "); return r;}
//if(a<0 & b>0){if(Abs(a)==b){res=rndsgn*b*random; return res;} if(Abs(a)>b){if(random>(b/Abs(a))){res=random*b; return res;} else{res=random*a; return res;}}}
//else{return rnd.NextDouble();}

