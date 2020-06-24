LIBDIR = ../../matlib

all: out.txt

out.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll


matlib.dll : $(LIBDIR)/matrix/vector.cs Minimization.cs NumericalGradient.cs $(LIBDIR)/matrix/matrix.cs
	mcs -target:library -out:$@ $^


clean:
	rm *.txt *.dll *.exe

