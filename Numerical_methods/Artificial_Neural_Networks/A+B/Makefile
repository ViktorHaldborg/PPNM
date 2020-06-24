LIB = ../../matlib
DIR = ../..

all: TabulatedFunction.txt Out.txt AB.svg

AB.svg: AB.gpi Out.txt TabulatedFunction.txt
	gnuplot $<

Out.txt : Main.exe
	mono  $< >$@

TabulatedFunction.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll


matlib.dll : $(LIB)/matrix/vector.cs ArtificialNeuralNetwork.cs $(LIB)/matrix/matrix.cs $(LIB)/DataGeneration/RNG/RandomNumberGenerator.cs $(DIR)/Minimization/A/Minimization.cs  $(DIR)/Minimization/A/NumericalGradient.cs 
	mcs -target:library -out:$@ $^


clean:
	rm *.txt *.dll *.exe *.svg

