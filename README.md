# Deutsch-Oracle
A simulation of quantum bits (more like "dual" bits since I'm not using imaginary numbers here) in the application of the Deutsch Oracle to prove the existence of problems where quantum computers take less iterations than regular computers.

The Deutsch Oracle is a problem where you are given a black box which contains one of the four possible operations on one bit (one of identity, inversion, set, unset).

In order to figure out whether or not the operation is constant (set and unset) or variable (invert or identity) a classical computer needs two executions of the function.
For example, if you input a 1 and get out a 1 you have to check whether it was set (a constant function) or identity (a variable function) by inputting a 0.

A Computer operating on quantum bits only requires one executions of the function, which you can see in Program.cs

The model is using a simplified version of QBits that rely on real numbers instead of imaginary ones. 
Quantum entanglement has not been implemented as this is where the simulation would reach exponential complexity.

*The actual point of the Deutsch Oracle isn't really present here. For the full deal [this Wikipedia article](https://en.wikipedia.org/wiki/Deutsch%E2%80%93Jozsa_algorithm) may be a nice starting point*.

# Source
- [Quantum Computing for Computer Scientists](https://www.youtube.com/watch?v=F_Riqjdh2oM)
- figuring out how to implement it myself
