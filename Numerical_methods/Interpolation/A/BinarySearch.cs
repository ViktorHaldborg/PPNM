using static System.Math;
using System;
public class BinarySearch{

// Half interval search on ordered array
public static int BinSearch(vector x, double z){
int i=0, j=x.size-1;
while(j-i>1){ int mid=(i+j)/2; if(z>x[mid]) i=mid; else j=mid;}
return i;}

}


