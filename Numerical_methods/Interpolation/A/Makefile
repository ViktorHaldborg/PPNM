LIBDIR = ../../matlib

all: A.svg TabulatedValues.txt LinSpline.txt

A.svg : A.gpi TabulatedValues.txt LinSpline.txt
	gnuplot $<

LinSpline.txt : Main.exe
	mono  $< >$@

TabulatedValues.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

LinearInterpolation.exe : matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs LinearInterpolation.cs  BinarySearch.cs
	mcs -target:library -out:$@ $^


clean:
	rm *.txt *.dll *.svg *.exe

view: open A.svg
