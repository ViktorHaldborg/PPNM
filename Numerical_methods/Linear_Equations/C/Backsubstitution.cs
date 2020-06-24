using System;
public class Backsubstitution{

public static vector Backsubstitute(vector b, matrix R){
for(int i=b.size-1; i>=0; i=i-1){double sum=0; for(int k=i+1; k<b.size; k=k+1){sum=sum+R[i,k]*b[k];}
b[i]=(b[i]-sum)/R[i,i];}
return b;}

}
