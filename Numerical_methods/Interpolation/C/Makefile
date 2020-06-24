LIBDIR = ../../matlib

all: C.svg ManualValues.txt CubicSpline.txt

C.svg : C.gpi ManualValues.txt CubicSpline.txt
	gnuplot $<

CubicSpline.txt : Main.exe
	mono  $< >$@

ManualValues.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

CubicInterpolation.exe : matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs CubicInterpolation.cs  BinarySearch.cs
	mcs -target:library -out:$@ $^


clean:
	rm *.txt *.dll *.svg *.exe

