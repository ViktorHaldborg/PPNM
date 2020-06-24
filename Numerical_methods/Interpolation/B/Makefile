LIBDIR = ../../matlib

all: B.svg ManualValues.txt QuadSpline.txt

B.svg : B.gpi ManualValues.txt QuadSpline.txt
	gnuplot $<

QuadSpline.txt : Main.exe
	mono  $< >$@

ManualValues.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

QuadraticInterpolation.exe : matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs QuadraticInterpolation.cs  BinarySearch.cs
	mcs -target:library -out:$@ $^


clean:
	rm *.txt *.dll *.svg *.exe

