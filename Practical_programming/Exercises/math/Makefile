out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:cmath.dll cmath.cs complex.cs

.PHONEY:clean
clean:
	rm --force out* *.dll *.exe
