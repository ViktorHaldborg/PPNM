LIBDIR = ../../matlib
LIB = ../../Linear_Equations/B

all: A.svg C.svg Data.txt DataOut.txt out.txt

C.svg : C.gpi Data.txt DataOut.txt
	gnuplot C.gpi

A.svg : A.gpi Data.txt DataOut.txt
	gnuplot A.gpi

out.txt : Main.exe
	mono  $< >$@

DataOut.txt : Main.exe
	mono  $< >$@

Data.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs $(LIBDIR)/matrix/matrix.cs LeastSquares.cs $(LIB)/LinearEquations.cs
	mcs -target:library -out:$@ $^

clean:
	rm *.dll *.svg *.exe *.txt



