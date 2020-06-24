

  Welcome to my examination project

- I have structured the project in parts A,B,C and used subsequent subfolders, with the intention of displaying the different implementations clearly.
  Therefore the entire project will not make/clean in its entirety but individual makefiles are distributed in the given folders.

- I have presented my results in the corresponding out.txt files which i encourage you to look through.

- I have seperated the primary routines used to compile the project in two classes "Generation" and "IntervalSearch", the rest are sourched from the self written routines located under
  the corresponding numerical methods exercises or from the general library "matlib".
 
- Precision and convergence is ensured using the Round method from the Math clas, precision is therefore fed to the routines as integer parameter.

- Random number generation is done through a custom built random number generator, utilizing OS entropy for the seed value, and is located in the primary library "matlib".

- The Newton method is built on the self built multidimensional implementation and as such, many time a reusable vector will be constructed for which only the first entry will be used.

