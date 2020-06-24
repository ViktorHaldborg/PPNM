out.txt : epsilon.exe
	mono epsilon.exe > out.txt

epsilon.exe : epsilon.cs cmath.dll
	mcs -reference:cmath.dll epsilon.cs

cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:cmath.dll cmath.cs complex.cs

.PHONEY:clean
clean:
	rm --force out* *.dll *.exe
