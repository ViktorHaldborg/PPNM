LIBDIR = ../../matlib
DIR = ../../Matrix_Diagonalization/A

all: Time.svg Time.txt MainAnswer.txt TimeVBV.txt TimeCyclic.txt TimeVBVfull.txt

Time.svg : Time.gpi Time.txt TimeVBV.txt TimeCyclic.txt TimeVBVfull.txt
	gnuplot Time.gpi


TimeVBV.txt: MainTimeVBV.exe
	mono  $< >$@

TimeVBVfull.txt: MainTimeVBVfull.exe
	mono  $< >$@

TimeCyclic.txt: MainTimeCyclic.exe
	mono  $< >$@

Time.txt: MainTime.exe
	mono  $< >$@

MainAnswer.txt: Main.exe
	mono  $< >$@

MainTimeVBVfull.exe : MainTimeVBVfull.cs matlib.dll
	mcs $< -reference:matlib.dll

MainTimeVBV.exe : MainTimeVBV.cs matlib.dll
	mcs $< -reference:matlib.dll

MainTimeCyclic.exe : MainTimeCyclic.cs matlib.dll
	mcs $< -reference:matlib.dll

MainTime.exe : MainTime.cs matlib.dll
	mcs $< -reference:matlib.dll

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs $(LIBDIR)/matrix/matrix.cs $(LIBDIR)/DataGeneration/RNG/RandomNumberGenerator.cs Jacobi_diagonalization.cs $(DIR)/Jacobi_diagonalization.cs Jacobi_diagonalization_cyclic.cs 
	mcs -target:library -out:$@ $^

clean:
	rm *.dll *.svg *.txt *.exe



