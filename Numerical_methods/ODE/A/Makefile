LIBDIR = ../../matlib

all: A.svg out.txt

A.svg : A.gpi out.txt
	gnuplot A.gpi

out.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs ODE.cs
	mcs -target:library -out:$@ $^

clean:
	rm *.txt *.dll *.svg *.exe
